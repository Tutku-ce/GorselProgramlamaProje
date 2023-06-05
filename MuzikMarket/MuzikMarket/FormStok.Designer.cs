namespace MuzikMarket
{
    partial class FormStok
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAdet = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbUrun = new System.Windows.Forms.ComboBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAzalt = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCikis = new System.Windows.Forms.Button();
            this.grpDecrease = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpDecrease.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(596, 551);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAdet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbUrun);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(602, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 137);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stok";
            // 
            // txtAdet
            // 
            this.txtAdet.Culture = new System.Globalization.CultureInfo("tr-TR");
            this.txtAdet.Location = new System.Drawing.Point(311, 50);
            this.txtAdet.Mask = "0000";
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.PromptChar = ' ';
            this.txtAdet.Size = new System.Drawing.Size(121, 20);
            this.txtAdet.TabIndex = 22;
            this.txtAdet.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Adet";
            // 
            // cbbUrun
            // 
            this.cbbUrun.FormattingEnabled = true;
            this.cbbUrun.Location = new System.Drawing.Point(33, 49);
            this.cbbUrun.Name = "cbbUrun";
            this.cbbUrun.Size = new System.Drawing.Size(272, 21);
            this.cbbUrun.TabIndex = 20;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(33, 76);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(189, 54);
            this.btnEkle.TabIndex = 19;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürün";
            // 
            // btnAzalt
            // 
            this.btnAzalt.Location = new System.Drawing.Point(137, 19);
            this.btnAzalt.Name = "btnAzalt";
            this.btnAzalt.Size = new System.Drawing.Size(204, 54);
            this.btnAzalt.TabIndex = 23;
            this.btnAzalt.Text = "Azalt";
            this.btnAzalt.UseVisualStyleBackColor = true;
            this.btnAzalt.Click += new System.EventHandler(this.btnAzalt_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(603, 496);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "label9";
            // 
            // btnCikis
            // 
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCikis.Location = new System.Drawing.Point(904, 465);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(136, 74);
            this.btnCikis.TabIndex = 14;
            this.btnCikis.Text = "Kapat";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // grpDecrease
            // 
            this.grpDecrease.Controls.Add(this.maskedTextBox1);
            this.grpDecrease.Controls.Add(this.btnAzalt);
            this.grpDecrease.Controls.Add(this.label3);
            this.grpDecrease.Location = new System.Drawing.Point(602, 155);
            this.grpDecrease.Name = "grpDecrease";
            this.grpDecrease.Size = new System.Drawing.Size(438, 81);
            this.grpDecrease.TabIndex = 24;
            this.grpDecrease.TabStop = false;
            this.grpDecrease.Text = "Stok";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Culture = new System.Globalization.CultureInfo("tr-TR");
            this.maskedTextBox1.Location = new System.Drawing.Point(10, 53);
            this.maskedTextBox1.Mask = "0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PromptChar = ' ';
            this.maskedTextBox1.Size = new System.Drawing.Size(121, 20);
            this.maskedTextBox1.TabIndex = 22;
            this.maskedTextBox1.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Adet";
            // 
            // FormStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 551);
            this.Controls.Add(this.grpDecrease);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormStok";
            this.Load += new System.EventHandler(this.FormStok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpDecrease.ResumeLayout(false);
            this.grpDecrease.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtAdet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbUrun;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAzalt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.GroupBox grpDecrease;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label3;
    }
}