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
    public partial class FormUrunler : Form
    {
        private SqlConnection connection;
        private List<Urunler> urunList = new List<Urunler>();
        private List<Kategori> kategoriList = new List<Kategori>();
        private int urunId = 0;
        private int islem = 0;
        public FormUrunler()
        {
            InitializeComponent();
            connection = new SqlConnection("server=DESKTOP-HLAQMOO\\SQLEXPRESS;database=MuzikMarket;user=tutku;password=123456;");
            connection.Open();
        }

        private void FormUrunler_Load(object sender, EventArgs e)
        {
            
            SqlCommand cmd1 = new SqlCommand("Kategori_List", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                kategoriList.Add(KategoriYukle(dr1));
            }

            dr1.Close();
            dr1.Dispose();
            

            var dictionary = new Dictionary<int, string>();
            for (int i = 0; i < kategoriList.Count; i++)
            {
                dictionary.Add(kategoriList[i].kategoriId, kategoriList[i].kategoriAd);
            }

            cbbKategori.DataSource = new BindingSource(dictionary,null);
            cbbKategori.DisplayMember = "Value";
            cbbKategori.ValueMember = "Key";



            SqlCommand cmd = new SqlCommand("Urunler_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                urunList.Add(UrunYukle(dr));
            }
            dr.Close();
            dr.Dispose();
            
            dataGridView1.DataSource = urunList;
            string[] headers = { "id", "Ad", "Kod", "Açıklama", "Fiyat", "id", "Kategori", "Durum" };
            int[] visibles = { 0, 5 };
            MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
        }

        private Kategori KategoriYukle(SqlDataReader dr1)
        {
            Kategori kategori = new Kategori()
            {
                kategoriId = Convert.ToInt32(dr1["kategoriId"]),
                kategoriAd = dr1["kategoriAd"].ToString()
            };
            return kategori;
        }

        private void TextboxClear()
        {
            txtAd.Text = "";
            txtKod.Text = "";
            txtAciklama.Text = "";
            txtFiyat.Text = "";
            cbbKategori.SelectedIndex = 0;
            urunId = 0;
            islem = 0;
            label9.Text = urunId.ToString();
            btnEkle.Text = "Ekle";
        }
        private Urunler UrunYukle(SqlDataReader dr)
        {
            Urunler urun = new Urunler()
            {
                urunId = Convert.ToInt32(dr["urunId"]),
                urunAd = dr["urunAd"].ToString(),
                urunKodu = dr["urunKodu"].ToString(),
                urunAciklama = dr["urunAciklama"].ToString(),
                urunFiyati = Convert.ToDecimal(dr["urunFiyati"]),
                kategoriId = Convert.ToInt32(dr["kategoriId"]),
                kategoriAd = dr["kategoriAd"].ToString(),
                urunDurum = Convert.ToBoolean(dr["urunDurum"])
            };
            return urun;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (islem == 0)
            {
                SqlCommand cmd = new SqlCommand("Urunler_Add", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("urunAd", txtAd.Text);
                cmd.Parameters.AddWithValue("urunKodu", txtKod.Text);
                cmd.Parameters.AddWithValue("urunAciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("urunFiyati", Convert.ToDecimal(txtFiyat.Text));
                cmd.Parameters.AddWithValue("kategoriId", Convert.ToInt32(cbbKategori.SelectedValue));
                cmd.Parameters.AddWithValue("urunDurum", true);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@urunId";
                parameter.DbType = DbType.Int32;
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
                cmd.ExecuteNonQuery();

                Urunler urun = new Urunler()
                {
                    urunId = Convert.ToInt32(parameter.Value),
                    urunKodu = txtKod.Text,
                    urunAciklama = txtAciklama.Text,
                    kategoriId = Convert.ToInt32(cbbKategori.SelectedValue),
                    urunAd = txtAd.Text,
                    urunFiyati = Convert.ToDecimal(txtFiyat.Text),
                    urunDurum = true
                };

                urunList.Add(urun);
                dataGridView1.DataSource = urunList;
                TextboxClear();
                MessageBox.Show("Urun Basariyla Eklenmistir.");

            }
            else if (islem == 1)
            {
                SqlCommand cmd = new SqlCommand("Urunler_Update", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("urunAd", txtAd.Text);
                cmd.Parameters.AddWithValue("urunKodu", txtKod.Text);
                cmd.Parameters.AddWithValue("urunAciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("urunFiyati", Convert.ToDecimal(txtFiyat.Text));
                cmd.Parameters.AddWithValue("kategoriId", Convert.ToInt32(cbbKategori.SelectedValue));
                cmd.Parameters.AddWithValue("urunDurum", urunList.Find(x=>x.urunId == urunId).urunDurum);
                cmd.Parameters.AddWithValue("urunId", urunId);
                cmd.ExecuteNonQuery();
                TextboxClear();
                MessageBox.Show("Urun Basariyla Guncellendi.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (urunId != 0)
            {
                var data = urunList.Find(x => x.urunId == urunId);
                txtAd.Text = data.urunAd;
                txtKod.Text = data.urunKodu;
                txtAciklama.Text = data.urunAciklama;
                txtFiyat.Text = data.urunFiyati.ToString();
                cbbKategori.SelectedValue = data.kategoriId;
                islem = 1;
                btnEkle.Text = "Guncelle";

            }
            else
            {   
                MessageBox.Show("Satir Seciniz.");
            }
        }

        private void btnYeniPersonel_Click(object sender, EventArgs e)
        {
            TextboxClear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Urunler_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("urunId", urunId);
            cmd.ExecuteNonQuery();
            TextboxClear();
            MessageBox.Show("Urun Basariyla Silindi.");
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            urunId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["urunId"].Value);
            label9.Text = urunId.ToString();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
