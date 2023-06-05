using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuzikMarket
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            FormPersonel frm = new FormPersonel();
            frm.ShowDialog();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            FormMusteri frm = new FormMusteri();
            frm.ShowDialog();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            FormKategori frm = new FormKategori();
            frm.ShowDialog();
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            FormUrunler frm = new FormUrunler();
            frm.ShowDialog();
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            FormStok frm = new FormStok();
            frm.ShowDialog();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            FormSatis frm = new FormSatis();
            frm.ShowDialog();
        }

        private void btnFatura_Click(object sender, EventArgs e)
        {
            FormFatura frm = new FormFatura();
            frm.ShowDialog();
        }
    }
}
