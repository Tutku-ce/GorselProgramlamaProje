using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MuzikMarket_Ell.Concrete;

namespace MuzikMarket
{
    public partial class FormPersonel : Form
    {
        public FormPersonel()
        {
            InitializeComponent();
            connection = new SqlConnection("server=DESKTOP-HLAQMOO\\SQLEXPRESS;database=MuzikMarket;user=tutku;password=123456;");
            connection.Open();
        }

        private SqlConnection connection;
        private List<Personel> personelList = new List<Personel>();


        private void FormPersonel_Load(object sender, EventArgs e)
        {
            

            SqlCommand cmd = new SqlCommand("Personel_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                personelList.Add(PersonelYukle(dr));
            }
            dr.Close();
            dr.Dispose();


            dataGridView1.DataSource = personelList;
            string[] headers =
            {
                "id", "Ad", "Soyad", "Kullanici Adi", "Kullanici Sifre", "Dogum Tarih", "Telefon", "Kod", "Adres",
                "Durum"
            };
            int[] visibles = { 0, 4 };
            MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
        }

        private Personel PersonelYukle(SqlDataReader dr)
        {
            Personel personel = new Personel();
            personel.personelId = Convert.ToInt32(dr["personelId"]);
            personel.personelAd = dr["personelAd"].ToString();
            personel.personelSoyad = dr["personelSoyad"].ToString();
            personel.personelKullaniciAdi = dr["personelKullaniciAdi"].ToString();
            personel.personelKullaniciSifre = dr["personelKullaniciSifre"].ToString();
            personel.personelDogumTarihi = Convert.ToDateTime(dr["personelDogumTarihi"]);
            personel.personelTelefon = dr["personelTelefon"].ToString();
            personel.personelKod = dr["personelKod"].ToString();
            personel.personelAdres = dr["personelAdres"].ToString();
            personel.personelDurum = Convert.ToBoolean(dr["personelDurum"]);

            return personel;
        }

        private void TextboxClear()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtKullaniciSifre.Text = "";
            txtKullaniciAd.Text = "";
            txtTelefon.Text = "";
            txtKod.Text = "";
            txtAdres.Text = "";
            islem = 0;
            personelId = 0;
            label9.Text = personelId.ToString();
            btnEkle.Text = "Ekle";
        }
        private int islem = 0;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (islem == 0)
            {
                SqlCommand cmd = new SqlCommand("Personel_Add", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("personelAd", txtAd.Text);
                cmd.Parameters.AddWithValue("personelSoyad", txtSoyad.Text);
                cmd.Parameters.AddWithValue("personelKullaniciAdi", txtKullaniciAd.Text);
                cmd.Parameters.AddWithValue("personelKullaniciSifre", txtKullaniciSifre.Text);
                cmd.Parameters.AddWithValue("personelDogumTarihi", Convert.ToDateTime(dtpDogumTarih.Value));
                cmd.Parameters.AddWithValue("personelTelefon", txtTelefon.Text);
                cmd.Parameters.AddWithValue("personelKod", txtKod.Text);
                cmd.Parameters.AddWithValue("personelAdres", txtAdres.Text);
                cmd.Parameters.AddWithValue("personelDurum", true);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@personelId";
                parameter.DbType = DbType.Int32;
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();

                Personel personel = new Personel();
                personel.personelId = Convert.ToInt32(parameter.Value);
                personel.personelAd = txtAd.Text;
                personel.personelSoyad = txtSoyad.Text;
                personel.personelKullaniciAdi = txtKullaniciAd.Text;
                personel.personelKullaniciSifre = txtKullaniciSifre.Text;
                personel.personelDogumTarihi = dtpDogumTarih.Value;
                personel.personelTelefon = txtTelefon.Text;
                personel.personelKod = txtKod.Text;
                personel.personelAdres = txtAdres.Text;
                personel.personelDurum = true;

                personelList.Add(personel);
                dataGridView1.DataSource = personelList;
                TextboxClear();
                MessageBox.Show("Personel Basariyla Eklenmistir.");
            }
            else if (islem == 1)
            {
                SqlCommand cmd = new SqlCommand("Personel_Update", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("personelAd", txtAd.Text);
                cmd.Parameters.AddWithValue("personelSoyad", txtSoyad.Text);
                cmd.Parameters.AddWithValue("personelKullaniciAdi", txtKullaniciAd.Text);
                cmd.Parameters.AddWithValue("personelKullaniciSifre", txtKullaniciSifre.Text);
                cmd.Parameters.AddWithValue("personelDogumTarihi", Convert.ToDateTime(dtpDogumTarih.Value));
                cmd.Parameters.AddWithValue("personelTelefon", txtTelefon.Text);
                cmd.Parameters.AddWithValue("personelKod", txtKod.Text);
                cmd.Parameters.AddWithValue("personelAdres", txtAdres.Text);
                cmd.Parameters.AddWithValue("personelId", personelId);
                cmd.Parameters.AddWithValue("personelDurum",
                    personelList.FirstOrDefault(x => x.personelId == personelId).personelDurum);
                cmd.ExecuteNonQuery();
                TextboxClear();
                MessageBox.Show("Personel Basariyla Güncellenmiştir.");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (personelId != 0)
            {
                var data = personelList.FirstOrDefault(x => x.personelId == personelId);
                txtAd.Text = data.personelAd;
                txtSoyad.Text = data.personelSoyad;
                txtKullaniciAd.Text = data.personelKullaniciAdi;
                txtKullaniciSifre.Text = data.personelKullaniciSifre;
                dtpDogumTarih.Value = data.personelDogumTarihi;
                txtTelefon.Text = data.personelTelefon;
                txtKod.Text = data.personelKod;
                txtAdres.Text = data.personelAdres;
                islem = 1;
                btnEkle.Text = "Güncelle";
            }
            else
            {
                MessageBox.Show("Satir Secilmedi.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Personel_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("personelId", personelId);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Personel Başarıyla Silinmiştir.");
            TextboxClear();
        }

        private int personelId;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            personelId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["personelId"].Value);
            label9.Text = personelId.ToString();
        }

        private void btnYeniPersonel_Click(object sender, EventArgs e)
        {
            TextboxClear();
        }
    }
}
