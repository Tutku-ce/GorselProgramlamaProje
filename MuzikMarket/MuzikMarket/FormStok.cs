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
    public partial class FormStok : Form
    {
        private SqlConnection connection;
        private List<UrunStok> urunStokList=new List<UrunStok>();
        private int urunStokId =0;
        public FormStok()
        {
            InitializeComponent();
            connection = new SqlConnection("server=DESKTOP-HLAQMOO\\SQLEXPRESS;database=MuzikMarket;user=tutku;password=123456;");
            connection.Open();
        }

        private void FormStok_Load(object sender, EventArgs e)
        {
            grpDecrease.Visible = false;

            SqlCommand cmd1 = new SqlCommand("Urunler_List", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr1 = cmd1.ExecuteReader();
            var dictionary = new Dictionary<int, string>();
            while (dr1.Read())
            {
                dictionary.Add(Convert.ToInt32(dr1["urunId"]), dr1["urunAd"].ToString());
            }
            dr1.Close();
            dr1.Dispose();

            cbbUrun.DataSource = new BindingSource(dictionary,null);
            cbbUrun.DisplayMember = "Value";
            cbbUrun.ValueMember = "Key";



            SqlCommand cmd = new SqlCommand("UrunStok_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                urunStokList.Add(UrunStokYukle(dr));
            }
            dr.Close();
            dr.Dispose();

            dataGridView1.DataSource = urunStokList;
            string[] headers = { "id", "id", "Urun", "Adet", "Durum" };
            int[] visibles = { 0, 1 };
            MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
        }

        private UrunStok UrunStokYukle(SqlDataReader dr)
        {
            UrunStok stok = new UrunStok()
            {
                urunStokId = Convert.ToInt32(dr["urunStokId"]),
                urunId = Convert.ToInt32(dr["urunId"]),
                urunAd = dr["urunAd"].ToString(),
                stokAdet = Convert.ToInt32(dr["stokAdet"]),
                urunStokDurum = Convert.ToBoolean(dr["urunStokDurum"])
            };
            return stok;
        }

        private void TextboxClear()
        {
            txtAdet.Text = "";
            cbbUrun.SelectedIndex = 0;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UrunStok_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("urunId", cbbUrun.SelectedValue);
            cmd.Parameters.AddWithValue("stokAdet", txtAdet.Text);
            cmd.Parameters.AddWithValue("urunStokDurum", true);
            cmd.ExecuteNonQuery();
            TextboxClear();
            MessageBox.Show("Stok Eklenmistir.");
        }

        private void btnAzalt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UrunStok_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("urunStokId", urunStokId);
            cmd.Parameters.AddWithValue("stokAdet", txtAdet.Text);
            cmd.ExecuteNonQuery();
            TextboxClear();
            MessageBox.Show("Stok Azalmistir.");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            urunStokId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["urunStokId"].Value);
            grpDecrease.Visible = true;
            label9.Text = urunStokId.ToString();
        }
    }
}
