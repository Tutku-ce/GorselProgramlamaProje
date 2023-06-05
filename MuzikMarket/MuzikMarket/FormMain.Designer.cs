namespace MuzikMarket
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPersonel = new System.Windows.Forms.Button();
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnUrunler = new System.Windows.Forms.Button();
            this.btnStok = new System.Windows.Forms.Button();
            this.btnSatis = new System.Windows.Forms.Button();
            this.btnFatura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPersonel
            // 
            this.btnPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonel.Location = new System.Drawing.Point(12, 12);
            this.btnPersonel.Name = "btnPersonel";
            this.btnPersonel.Size = new System.Drawing.Size(201, 91);
            this.btnPersonel.TabIndex = 0;
            this.btnPersonel.Text = "Personel";
            this.btnPersonel.UseVisualStyleBackColor = true;
            this.btnPersonel.Click += new System.EventHandler(this.btnPersonel_Click);
            // 
            // btnMusteri
            // 
            this.btnMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusteri.Location = new System.Drawing.Point(219, 12);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(201, 91);
            this.btnMusteri.TabIndex = 1;
            this.btnMusteri.Text = "Müşteri";
            this.btnMusteri.UseVisualStyleBackColor = true;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnKategori
            // 
            this.btnKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKategori.Location = new System.Drawing.Point(426, 12);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(201, 91);
            this.btnKategori.TabIndex = 2;
            this.btnKategori.Text = "Kategori";
            this.btnKategori.UseVisualStyleBackColor = true;
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // btnUrunler
            // 
            this.btnUrunler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUrunler.Location = new System.Drawing.Point(633, 12);
            this.btnUrunler.Name = "btnUrunler";
            this.btnUrunler.Size = new System.Drawing.Size(201, 91);
            this.btnUrunler.TabIndex = 3;
            this.btnUrunler.Text = "Ürünler";
            this.btnUrunler.UseVisualStyleBackColor = true;
            this.btnUrunler.Click += new System.EventHandler(this.btnUrunler_Click);
            // 
            // btnStok
            // 
            this.btnStok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStok.Location = new System.Drawing.Point(840, 12);
            this.btnStok.Name = "btnStok";
            this.btnStok.Size = new System.Drawing.Size(201, 91);
            this.btnStok.TabIndex = 4;
            this.btnStok.Text = "Stok";
            this.btnStok.UseVisualStyleBackColor = true;
            this.btnStok.Click += new System.EventHandler(this.btnStok_Click);
            // 
            // btnSatis
            // 
            this.btnSatis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSatis.Location = new System.Drawing.Point(12, 109);
            this.btnSatis.Name = "btnSatis";
            this.btnSatis.Size = new System.Drawing.Size(201, 91);
            this.btnSatis.TabIndex = 5;
            this.btnSatis.Text = "Satış";
            this.btnSatis.UseVisualStyleBackColor = true;
            this.btnSatis.Click += new System.EventHandler(this.btnSatis_Click);
            // 
            // btnFatura
            // 
            this.btnFatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFatura.Location = new System.Drawing.Point(219, 109);
            this.btnFatura.Name = "btnFatura";
            this.btnFatura.Size = new System.Drawing.Size(201, 91);
            this.btnFatura.TabIndex = 6;
            this.btnFatura.Text = "Fatura";
            this.btnFatura.UseVisualStyleBackColor = true;
            this.btnFatura.Click += new System.EventHandler(this.btnFatura_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 551);
            this.Controls.Add(this.btnFatura);
            this.Controls.Add(this.btnSatis);
            this.Controls.Add(this.btnStok);
            this.Controls.Add(this.btnUrunler);
            this.Controls.Add(this.btnKategori);
            this.Controls.Add(this.btnMusteri);
            this.Controls.Add(this.btnPersonel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPersonel;
        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Button btnKategori;
        private System.Windows.Forms.Button btnUrunler;
        private System.Windows.Forms.Button btnStok;
        private System.Windows.Forms.Button btnSatis;
        private System.Windows.Forms.Button btnFatura;
    }
}