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
    public partial class FormFatura : Form
    {
        private SqlConnection connection;
        private List<Fatura> faturaList = new List<Fatura>();
        private int faturaId = 0;
        public FormFatura()
        {
            InitializeComponent();
            connection = new SqlConnection("server=DESKTOP-HLAQMOO\\SQLEXPRESS;database=MuzikMarket;user=tutku;password=123456;");
            connection.Open();
        }

        private void FormFatura_Load(object sender, EventArgs e)
        {
            FaturaDetayStatus();
            SqlCommand cmd = new SqlCommand("Fatura_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                faturaList.Add(FaturaYukle(dr));
            }
            dr.Close();
            dr.Dispose();

            dataGridView1.DataSource = faturaList;
            string[] headers = { "id", "Fatura No", "Toplam Tutar", "id", "Müşteri Adı", "Durum" };
            int[] visibles = { 0, 3 };
            MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
        }

        private Fatura FaturaYukle(SqlDataReader dr)
        {
            Fatura fatura = new Fatura()
            {
                faturaId = Convert.ToInt32(dr["faturaId"]),
                musteriId = Convert.ToInt32(dr["musteriId"]),
                musteriAd = dr["musteriAd"].ToString(),
                faturaNo = dr["faturaNo"].ToString(),
                toplamTutar = Convert.ToDecimal(dr["toplamTutar"]),
                faturaDurum = Convert.ToBoolean(dr["faturaDurum"])
            };
            return fatura;
        }

        private void FaturaDetayStatus()
        {
            if (faturaId != 0)
            {
                grpFaturaDetay.Visible = true;
            }
            else
            {
                grpFaturaDetay.Visible = false;
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.DataSource = null;
            faturaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["faturaId"].Value);
            if (faturaId != 0)
            {
                List<Satislar> satisList = new List<Satislar>();
                SqlCommand cmd = new SqlCommand("SatisGetByFatura_List", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("faturaId", faturaId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    satisList.Add(SatisYukle(dr));
                }

                dr.Close();
                dr.Dispose();

                dataGridView2.DataSource = satisList;
                string[] headers = { "id", "id", "Ürün Adı", "Adet", "Birim Fiyat", "Toplam Fiyat", "id", "Durum" };
                int[] visibles = { 0, 1, 6 };
                MyDataGridView.createDataGridView(dataGridView2, headers, visibles);

                SqlCommand cmd1 = new SqlCommand("Musteri_Get", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("musteriId",
                    Convert.ToInt32(dataGridView1.CurrentRow.Cells["musteriId"].Value));
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    dr1.Read();
                    lblAd.Text = dr1["musteriAd"].ToString();
                    lblSoyad.Text = dr1["musteriSoyad"].ToString();
                    lblTelefon.Text = dr1["musteriTelefon"].ToString();
                    lblMail.Text = dr1["musteriMail"].ToString();
                    lblAdres.Text = dr1["musteriAdres"].ToString();
                }
                dr1.Close();
                dr1.Dispose();
            }
            
            FaturaDetayStatus();
        }

        private Satislar SatisYukle(SqlDataReader dr)
        {
            Satislar satis = new Satislar()
            {
                satisId = Convert.ToInt32(dr["satisId"]),
                urunId = Convert.ToInt32(dr["urunId"]),
                urunAd = dr["urunAd"].ToString(),
                faturaId = Convert.ToInt32(dr["faturaId"]),
                toplamFiyat = Convert.ToDecimal(dr["toplamFiyat"]),
                birimFiyat = Convert.ToDecimal(dr["birimFiyat"]),
                urunAdet = Convert.ToInt32(dr["urunAdet"]),
                satisDurum = Convert.ToBoolean(dr["satisDurum"])
            };
            return satis;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
