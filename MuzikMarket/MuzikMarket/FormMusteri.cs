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
    public partial class FormMusteri : Form
    {
        private SqlConnection connection;
        private int musteriId;
        private int islem = 0;
        private List<Musteri> musteriList = new List<Musteri>();
        public FormMusteri()
        {
            InitializeComponent();
            connection = new SqlConnection("server=DESKTOP-HLAQMOO\\SQLEXPRESS;database=MuzikMarket;user=tutku;password=123456;");
            connection.Open();
        }

        
        private void FormMusteri_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Musteri_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                musteriList.Add(MusteriYukle(dr));
            }
            dr.Close();
            dr.Dispose();

            dataGridView1.DataSource = musteriList;
            string[] headers =
                { "musteriId", "Ad", "Soyad", "Kimlik No", "Dogum Tarih", "Telefon", "Mail", "Adres", "Durum" };
            int[] visibles = { 0 };
            MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
        }

        private Musteri MusteriYukle(SqlDataReader dr)
        {
            Musteri musteri = new Musteri()
            {
                musteriAd = dr["musteriAd"].ToString(),
                musteriSoyad = dr["musteriSoyad"].ToString(),
                musteriId = Convert.ToInt32(dr["musteriId"]),
                musteriAdres = dr["musteriAdres"].ToString(),
                musteriDogumTarih = Convert.ToDateTime(dr["musteriDogumTarih"]),
                musteriKimlikNo = dr["musteriKimlikNo"].ToString(),
                musteriDurum = Convert.ToBoolean(dr["musteriDurum"]),
                musteriMail = dr["musteriMail"].ToString(),
                musteriTelefon = dr["musteriTelefon"].ToString()
            };
            return musteri;
        }

        private void TextboxClear()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtKimlikNo.Text = "";
            dtpDogumTarih.Value = DateTime.Now;
            txtTelefon.Text = "";
            txtMail.Text = "";
            txtAdres.Text = "";
            musteriId = 0;
            islem = 0;
            label9.Text = musteriId.ToString();
            btnEkle.Text = "Ekle";

        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (islem == 0)
            {
                SqlCommand cmd = new SqlCommand("Musteri_Add", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("musteriAd", txtAd.Text);
                cmd.Parameters.AddWithValue("musteriSoyad", txtSoyad.Text);
                cmd.Parameters.AddWithValue("musteriKimlikNo", txtKimlikNo.Text);
                cmd.Parameters.AddWithValue("musteriDogumTarih", dtpDogumTarih.Value);
                cmd.Parameters.AddWithValue("musteriTelefon", txtTelefon.Text);
                cmd.Parameters.AddWithValue("musteriMail", txtMail.Text);
                cmd.Parameters.AddWithValue("musteriAdres", txtAdres.Text);
                cmd.Parameters.AddWithValue("musteriDurum", true);
                SqlParameter prm = new SqlParameter();
                prm.ParameterName = "@musteriId";
                prm.DbType = DbType.Int32;
                prm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(prm);

                cmd.ExecuteNonQuery();

                Musteri musteri = new Musteri()
                {
                    musteriAd = txtAd.Text,
                    musteriSoyad = txtSoyad.Text,
                    musteriKimlikNo = txtKimlikNo.Text,
                    musteriDogumTarih = dtpDogumTarih.Value,
                    musteriTelefon = txtTelefon.Text,
                    musteriMail = txtMail.Text,
                    musteriAdres = txtAdres.Text,
                    musteriId = Convert.ToInt32(prm.Value),
                    musteriDurum = true
                };

                musteriList.Add(musteri);
                dataGridView1.DataSource = musteriList;
                TextboxClear();
            }
            else if (islem == 1)
            {
                SqlCommand cmd = new SqlCommand("Musteri_Update", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("musteriAd", txtAd.Text);
                cmd.Parameters.AddWithValue("musteriSoyad", txtSoyad.Text);
                cmd.Parameters.AddWithValue("musteriKimlikNo", txtKimlikNo.Text);
                cmd.Parameters.AddWithValue("musteriDogumTarih", dtpDogumTarih.Value);
                cmd.Parameters.AddWithValue("musteriTelefon", txtTelefon.Text);
                cmd.Parameters.AddWithValue("musteriMail", txtMail.Text);
                cmd.Parameters.AddWithValue("musteriAdres", txtAdres.Text);
                cmd.Parameters.AddWithValue("musteriDurum", musteriList.Find(x=>x.musteriId == musteriId).musteriDurum);
                cmd.Parameters.AddWithValue("musteriId", musteriId);
                cmd.ExecuteNonQuery();
                TextboxClear();
                MessageBox.Show("Müşteri Başarıyla Güncellendi.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (musteriId != 0)
            {
                var data = musteriList.Find(x => x.musteriId == musteriId);
                txtAd.Text = data.musteriAd;
                txtSoyad.Text = data.musteriSoyad;
                txtKimlikNo.Text = data.musteriKimlikNo;
                txtTelefon.Text = data.musteriTelefon;
                txtMail.Text = data.musteriMail;
                txtAdres.Text = data.musteriAdres;
                dtpDogumTarih.Value = data.musteriDogumTarih;
                islem = 1;
                btnEkle.Text = "Güncelle";
            }
            else
            {
                MessageBox.Show("Satir Seciniz.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Musteri_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("musteriId", musteriId);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Musteri Basariyla Silidndi.");
        }

        private void btnYeniPersonel_Click(object sender, EventArgs e)
        {
            TextboxClear();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            musteriId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["musteriId"].Value);
            label9.Text = musteriId.ToString();
        }
    }
}
