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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace MuzikMarket
{
    public partial class FormSatis : Form
    {
        private SqlConnection connection;
        private Dictionary<int, string> kategoriList;
        private List<Urunler> urunList;
        private List<Satislar> satisList = new List<Satislar>();
        public FormSatis()
        {
            InitializeComponent();
            connection = new SqlConnection("server=DESKTOP-HLAQMOO\\SQLEXPRESS;database=MuzikMarket;user=tutku;password=123456;");
            connection.Open();
        }

        private void MusteriList()
        {
            var dictionary = new Dictionary<int, string>();
            SqlCommand cmd = new SqlCommand("Musteri_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dictionary.Add(Convert.ToInt32(dr["musteriId"]), $"{dr["musteriAd"]} {dr["musteriSoyad"]}");
            }
            dr.Close();
            dr.Dispose();

            cbbMusteri.DataSource = new BindingSource(dictionary, null);
            cbbMusteri.DisplayMember = "Value";
            cbbMusteri.ValueMember = "Key";
        }
        private void FormSatis_Load(object sender, EventArgs e)
        {
            MusteriList();
            dataGridView1.DataSource = satisList;
            kategoriList = new Dictionary<int, string>();
            SqlCommand cmd = new SqlCommand("Kategori_List", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kategoriList.Add(Convert.ToInt32(dr["kategoriId"]), dr["kategoriAd"].ToString());
            }
            dr.Close();
            dr.Dispose();

            foreach (var item in kategoriList)
            {
                Button buttonKategori = new Button();
                buttonKategori.Text = item.Value;
                buttonKategori.Tag = item.Key;
                buttonKategori.Width = 197;
                buttonKategori.Height = 60;
                buttonKategori.Click += (senders, args) =>
                {
                    flowLayoutPanel2.Controls.Clear();
                    List<Urunler> urunList = new List<Urunler>();
                    SqlCommand cmd1 = new SqlCommand("UrunlerGetByCategory_List", connection);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("kategoriId", item.Key);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        urunList.Add(UrunYukle(dr1));
                    }

                    dr1.Close();
                    dr1.Dispose();

                    foreach (var urunler in urunList)
                    {
                        Button btnUrun = new Button();
                        btnUrun.Text = urunler.urunAd;
                        btnUrun.Tag = urunler.urunId;
                        btnUrun.Width = 150;
                        btnUrun.Height = 60;
                        btnUrun.Click += (senders1, args1) =>
                        {
                            Satislar satis = new Satislar()
                            {
                                urunId = urunler.urunId,
                                urunAd = urunler.urunAd,
                                birimFiyat = urunler.urunFiyati,
                                satisDurum = true,
                                urunAdet = 1,
                                toplamFiyat = urunler.urunFiyati,
                                satisId = 0,
                                faturaId = 0
                            };
                            SatisListAdd(satis);
                            GridSatisList();
                        };
                        flowLayoutPanel2.Controls.Add(btnUrun);
                    }
                };
                flowLayoutPanel1.Controls.Add(buttonKategori);

            }
        }

        private void SatisListAdd(Satislar satis)
        {
            var data = satisList.Find(x => x.urunId == satis.urunId);
            if (data != null)
            {
                data.urunAdet = data.urunAdet + satis.urunAdet;
                data.toplamFiyat = data.urunAdet * data.birimFiyat;
            }
            else
            {
                satisList.Add(satis);
            }

            lblToplamTutar.Text = (Convert.ToDecimal(lblToplamTutar.Text) + satis.birimFiyat).ToString();

        }

        private void GridSatisList()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = satisList;
            string[] headers = { "id", "id", "Urun Ad", "Adet", "Birim Fiyat", "Toplam Fiyat", "id", "Durum" };
            int[] visibles = { 0, 1, 6, 7 };
            MyDataGridView.createDataGridView(dataGridView1, headers, visibles);

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

        private void btnSatis_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Fatura_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("faturaNo", Guid.NewGuid());
            cmd.Parameters.AddWithValue("toplamTutar", Convert.ToDecimal(lblToplamTutar.Text));
            cmd.Parameters.AddWithValue("musteriId", cbbMusteri.SelectedValue);
            cmd.Parameters.AddWithValue("faturaDurum", true);
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = "@faturaId";
            prm.DbType = DbType.Int32;
            prm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(prm);
            cmd.ExecuteNonQuery();


            for (int i = 0; i < satisList.Count; i++)
            {
                SqlCommand cmd1 = new SqlCommand("Satislar_Add", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("urunId", satisList[i].urunId);
                cmd1.Parameters.AddWithValue("urunAdet", satisList[i].urunAdet);
                cmd1.Parameters.AddWithValue("birimFiyat", satisList[i].birimFiyat);
                cmd1.Parameters.AddWithValue("toplamFiyat", satisList[i].toplamFiyat);
                cmd1.Parameters.AddWithValue("faturaId", prm.Value);
                cmd1.Parameters.AddWithValue("satisDurum", true);
                SqlParameter prm1 = new SqlParameter();
                prm1.ParameterName = "@satisId";
                prm1.DbType = DbType.Int32;
                prm1.Direction = ParameterDirection.Output;
                cmd1.Parameters.Add(prm1);
                cmd1.ExecuteNonQuery();
            }

            MessageBox.Show("Satis Islemi Basariyla Gerceklestirilmistir.");
            this.Close();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int urunId = 0;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                urunId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["urunId"].Value);
                label4.Text = urunId.ToString();
            }
            catch (Exception exception)
            {
                label4.Text = 0.ToString();
            }

        }

        //private void btnArti_Click(object sender, EventArgs e)
        //{
        //    ButtonStatus();
        //    var data = satisList.Find(x => x.urunId == urunId);
        //    data.urunAdet += 1;
        //    data.toplamFiyat = data.urunAdet * data.birimFiyat;
        //    GridSatisList();
        //}

        //private void btnEksi_Click(object sender, EventArgs e)
        //{
        //    ButtonStatus();
        //    var data = satisList.Find(x => x.urunId == urunId);
        //    data.urunAdet -= 1;
        //    data.toplamFiyat = data.urunAdet * data.birimFiyat;
        //    GridSatisList();
        //}

        //private void btnSil_Click(object sender, EventArgs e)
        //{
        //    ButtonStatus();
        //    var data = satisList.Find(x => x.urunId == urunId);
        //    satisList.Remove(data);
        //    GridSatisList();
        //    urunId = 0;
        //    ButtonStatus();
        //}
    }
}
