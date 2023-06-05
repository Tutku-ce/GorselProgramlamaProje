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
    public partial class FormKategori : Form
    {
        private SqlConnection connection;
        private int kategoriId = 0;
        private int islem = 0;
        private List<Kategori> kategoriList = new List<Kategori>();

        public FormKategori()
        {
            InitializeComponent();
            connection = new SqlConnection("server=DESKTOP-HLAQMOO\\SQLEXPRESS;database=MuzikMarket;user=tutku;password=123456;");
            connection.Open();
        }

        private void FormKategori_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Kategori_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr =cmd.ExecuteReader();
            while (dr.Read())
            {
                kategoriList.Add(KategoriYukle(dr));
            }
            dr.Close();
            dr.Dispose();

            dataGridView1.DataSource = kategoriList;
            string[] headers = { "id", "Ad", "Kod", "Açıklama", "Gorunen Ad", "Durum" };
            int[] visibles = { 0 };
            MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
        }

        private Kategori KategoriYukle(SqlDataReader dr)
        {
            Kategori kategori = new Kategori()
            {
                kategoriAd = dr["kategoriAd"].ToString(),
                kategoriKod = dr["kategoriKod"].ToString(),
                kategoriGorunum = dr["kategoriGorunum"].ToString(),
                kategoriAciklama = dr["kategoriAciklama"].ToString(),
                kategoriId = Convert.ToInt32(dr["kategoriId"]),
                kategoriDurum = Convert.ToBoolean(dr["kategoriDurum"])
            };
            return kategori;
        }

        private void TextboxClear()
        {
            txtAd.Text = "";
            txtKod.Text = "";
            txtAciklama.Text = "";
            txtGorunenAd.Text = "";
            islem = 0;
            kategoriId = 0;
            label9.Text = kategoriId.ToString();
            btnEkle.Text = "Ekle";
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (islem == 0)
            {
                SqlCommand cmd = new SqlCommand("Kategori_Add", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("kategoriAd", txtAd.Text);
                cmd.Parameters.AddWithValue("kategoriKod", txtKod.Text);
                cmd.Parameters.AddWithValue("kategoriAciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("kategoriGorunum", txtGorunenAd.Text);
                cmd.Parameters.AddWithValue("kategoriDurum", true);
                SqlParameter prm = new SqlParameter();
                prm.ParameterName = "kategoriId";
                prm.DbType = DbType.Int32;
                prm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(prm);
                cmd.ExecuteNonQuery();

                Kategori kategori = new Kategori();
                kategori.kategoriAd = txtAd.Text;
                kategori.kategoriKod = txtKod.Text;
                kategori.kategoriAciklama = txtAciklama.Text;
                kategori.kategoriGorunum = txtGorunenAd.Text;
                kategori.kategoriDurum = true;
                kategori.kategoriId = Convert.ToInt32(prm.Value);

                kategoriList.Add(kategori);
                dataGridView1.DataSource = kategoriList;
                TextboxClear();
                MessageBox.Show("Kategori Basariyla Eklenmistir.");
            }
            else if (islem == 1)
            {
                SqlCommand cmd = new SqlCommand("Kategori_Update",connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("kategoriAd", txtAd.Text);
                cmd.Parameters.AddWithValue("kategoriKod", txtKod.Text);
                cmd.Parameters.AddWithValue("kategoriAciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("kategoriGorunum", txtGorunenAd.Text);
                cmd.Parameters.AddWithValue("kategoriDurum", kategoriList.Find(x=>x.kategoriId == kategoriId).kategoriDurum);
                cmd.Parameters.AddWithValue("kategoriId", kategoriId);
                cmd.ExecuteNonQuery();
                TextboxClear();
                MessageBox.Show("Kategori Basariyla Güncellenmiştir.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (kategoriId != 0)
            {
                var data = kategoriList.Find(x => x.kategoriId == kategoriId);
                txtAd.Text = data.kategoriAd;
                txtKod.Text = data.kategoriKod;
                txtAciklama.Text = data.kategoriAciklama;
                txtGorunenAd.Text = data.kategoriGorunum;
                islem = 1;
                btnEkle.Text = "Guncelle";
            }
            else
            {
                MessageBox.Show("Satir Secilmedi.");
            }
        }

        private void btnYeniPersonel_Click(object sender, EventArgs e)
        {
            TextboxClear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("kategori_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("kategoriId", kategoriId);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kategori Silinmistir.");
            TextboxClear();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            kategoriId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["kategoriId"].Value);
            label9.Text = kategoriId.ToString();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
