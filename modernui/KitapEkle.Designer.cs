
namespace modernui
{
    partial class KitapEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitapEkle));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxKitapEkleYazar = new System.Windows.Forms.ComboBox();
            this.textBoxKitapEkleAd = new System.Windows.Forms.TextBox();
            this.labelKitapEkleAd = new System.Windows.Forms.Label();
            this.labelKitapEkleBaskiYil = new System.Windows.Forms.Label();
            this.labelKitapEkleSayfaSayi = new System.Windows.Forms.Label();
            this.labelKitapEkleDil = new System.Windows.Forms.Label();
            this.labelKitapEkleYayinEvi = new System.Windows.Forms.Label();
            this.labelKitapEkleAciklama = new System.Windows.Forms.Label();
            this.textBoxKitapEkleAciklama = new System.Windows.Forms.TextBox();
            this.buttonKitapEkle = new System.Windows.Forms.Button();
            this.numericUpDownKitapEkleBaskiYil = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKitapEkleSayfaSayi = new System.Windows.Forms.NumericUpDown();
            this.comboBoxKitapEkleDil = new System.Windows.Forms.ComboBox();
            this.comboBoxKitapEkleYayinEvi = new System.Windows.Forms.ComboBox();
            this.labelKitapYazar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKitapEkleBaskiYil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKitapEkleSayfaSayi)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(546, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // comboBoxKitapEkleYazar
            // 
            this.comboBoxKitapEkleYazar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxKitapEkleYazar.FormattingEnabled = true;
            this.comboBoxKitapEkleYazar.Location = new System.Drawing.Point(120, 100);
            this.comboBoxKitapEkleYazar.Name = "comboBoxKitapEkleYazar";
            this.comboBoxKitapEkleYazar.Size = new System.Drawing.Size(157, 21);
            this.comboBoxKitapEkleYazar.TabIndex = 1;
            this.comboBoxKitapEkleYazar.Text = "Bilinmiyor";
            // 
            // textBoxKitapEkleAd
            // 
            this.textBoxKitapEkleAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxKitapEkleAd.Location = new System.Drawing.Point(120, 74);
            this.textBoxKitapEkleAd.Name = "textBoxKitapEkleAd";
            this.textBoxKitapEkleAd.Size = new System.Drawing.Size(157, 20);
            this.textBoxKitapEkleAd.TabIndex = 0;
            // 
            // labelKitapEkleAd
            // 
            this.labelKitapEkleAd.AutoSize = true;
            this.labelKitapEkleAd.BackColor = System.Drawing.Color.Transparent;
            this.labelKitapEkleAd.Location = new System.Drawing.Point(89, 74);
            this.labelKitapEkleAd.Name = "labelKitapEkleAd";
            this.labelKitapEkleAd.Size = new System.Drawing.Size(25, 13);
            this.labelKitapEkleAd.TabIndex = 1;
            this.labelKitapEkleAd.Text = "Adı:";
            // 
            // labelKitapEkleBaskiYil
            // 
            this.labelKitapEkleBaskiYil.AutoSize = true;
            this.labelKitapEkleBaskiYil.BackColor = System.Drawing.Color.Transparent;
            this.labelKitapEkleBaskiYil.Location = new System.Drawing.Point(62, 126);
            this.labelKitapEkleBaskiYil.Name = "labelKitapEkleBaskiYil";
            this.labelKitapEkleBaskiYil.Size = new System.Drawing.Size(52, 13);
            this.labelKitapEkleBaskiYil.TabIndex = 2;
            this.labelKitapEkleBaskiYil.Text = "Baskı Yılı:";
            // 
            // labelKitapEkleSayfaSayi
            // 
            this.labelKitapEkleSayfaSayi.AutoSize = true;
            this.labelKitapEkleSayfaSayi.BackColor = System.Drawing.Color.Transparent;
            this.labelKitapEkleSayfaSayi.Location = new System.Drawing.Point(50, 152);
            this.labelKitapEkleSayfaSayi.Name = "labelKitapEkleSayfaSayi";
            this.labelKitapEkleSayfaSayi.Size = new System.Drawing.Size(64, 13);
            this.labelKitapEkleSayfaSayi.TabIndex = 3;
            this.labelKitapEkleSayfaSayi.Text = "Sayfa Sayısı";
            // 
            // labelKitapEkleDil
            // 
            this.labelKitapEkleDil.AutoSize = true;
            this.labelKitapEkleDil.BackColor = System.Drawing.Color.Transparent;
            this.labelKitapEkleDil.Location = new System.Drawing.Point(90, 178);
            this.labelKitapEkleDil.Name = "labelKitapEkleDil";
            this.labelKitapEkleDil.Size = new System.Drawing.Size(24, 13);
            this.labelKitapEkleDil.TabIndex = 4;
            this.labelKitapEkleDil.Text = "Dili:";
            // 
            // labelKitapEkleYayinEvi
            // 
            this.labelKitapEkleYayinEvi.AutoSize = true;
            this.labelKitapEkleYayinEvi.BackColor = System.Drawing.Color.Transparent;
            this.labelKitapEkleYayinEvi.Location = new System.Drawing.Point(60, 204);
            this.labelKitapEkleYayinEvi.Name = "labelKitapEkleYayinEvi";
            this.labelKitapEkleYayinEvi.Size = new System.Drawing.Size(54, 13);
            this.labelKitapEkleYayinEvi.TabIndex = 5;
            this.labelKitapEkleYayinEvi.Text = "Yayın Evi:";
            // 
            // labelKitapEkleAciklama
            // 
            this.labelKitapEkleAciklama.AutoSize = true;
            this.labelKitapEkleAciklama.BackColor = System.Drawing.Color.Transparent;
            this.labelKitapEkleAciklama.Location = new System.Drawing.Point(302, 71);
            this.labelKitapEkleAciklama.Name = "labelKitapEkleAciklama";
            this.labelKitapEkleAciklama.Size = new System.Drawing.Size(53, 13);
            this.labelKitapEkleAciklama.TabIndex = 6;
            this.labelKitapEkleAciklama.Text = "Açıklama:";
            // 
            // textBoxKitapEkleAciklama
            // 
            this.textBoxKitapEkleAciklama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxKitapEkleAciklama.Location = new System.Drawing.Point(361, 71);
            this.textBoxKitapEkleAciklama.Multiline = true;
            this.textBoxKitapEkleAciklama.Name = "textBoxKitapEkleAciklama";
            this.textBoxKitapEkleAciklama.Size = new System.Drawing.Size(196, 120);
            this.textBoxKitapEkleAciklama.TabIndex = 6;
            // 
            // buttonKitapEkle
            // 
            this.buttonKitapEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonKitapEkle.Location = new System.Drawing.Point(361, 199);
            this.buttonKitapEkle.Name = "buttonKitapEkle";
            this.buttonKitapEkle.Size = new System.Drawing.Size(196, 23);
            this.buttonKitapEkle.TabIndex = 15;
            this.buttonKitapEkle.Text = "Kitap Ekle";
            this.buttonKitapEkle.UseVisualStyleBackColor = true;
            this.buttonKitapEkle.Click += new System.EventHandler(this.buttonKitapEkle_Click);
            // 
            // numericUpDownKitapEkleBaskiYil
            // 
            this.numericUpDownKitapEkleBaskiYil.Location = new System.Drawing.Point(120, 126);
            this.numericUpDownKitapEkleBaskiYil.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numericUpDownKitapEkleBaskiYil.Name = "numericUpDownKitapEkleBaskiYil";
            this.numericUpDownKitapEkleBaskiYil.Size = new System.Drawing.Size(157, 20);
            this.numericUpDownKitapEkleBaskiYil.TabIndex = 2;
            this.numericUpDownKitapEkleBaskiYil.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            // 
            // numericUpDownKitapEkleSayfaSayi
            // 
            this.numericUpDownKitapEkleSayfaSayi.Location = new System.Drawing.Point(120, 153);
            this.numericUpDownKitapEkleSayfaSayi.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownKitapEkleSayfaSayi.Name = "numericUpDownKitapEkleSayfaSayi";
            this.numericUpDownKitapEkleSayfaSayi.Size = new System.Drawing.Size(157, 20);
            this.numericUpDownKitapEkleSayfaSayi.TabIndex = 3;
            // 
            // comboBoxKitapEkleDil
            // 
            this.comboBoxKitapEkleDil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxKitapEkleDil.FormattingEnabled = true;
            this.comboBoxKitapEkleDil.Location = new System.Drawing.Point(120, 179);
            this.comboBoxKitapEkleDil.Name = "comboBoxKitapEkleDil";
            this.comboBoxKitapEkleDil.Size = new System.Drawing.Size(157, 21);
            this.comboBoxKitapEkleDil.TabIndex = 4;
            this.comboBoxKitapEkleDil.Text = "Türkçe";
            // 
            // comboBoxKitapEkleYayinEvi
            // 
            this.comboBoxKitapEkleYayinEvi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxKitapEkleYayinEvi.FormattingEnabled = true;
            this.comboBoxKitapEkleYayinEvi.Location = new System.Drawing.Point(120, 205);
            this.comboBoxKitapEkleYayinEvi.Name = "comboBoxKitapEkleYayinEvi";
            this.comboBoxKitapEkleYayinEvi.Size = new System.Drawing.Size(157, 21);
            this.comboBoxKitapEkleYayinEvi.TabIndex = 5;
            this.comboBoxKitapEkleYayinEvi.Text = "Bilinmiyor";
            // 
            // labelKitapYazar
            // 
            this.labelKitapYazar.AutoSize = true;
            this.labelKitapYazar.BackColor = System.Drawing.Color.Transparent;
            this.labelKitapYazar.Location = new System.Drawing.Point(77, 100);
            this.labelKitapYazar.Name = "labelKitapYazar";
            this.labelKitapYazar.Size = new System.Drawing.Size(37, 13);
            this.labelKitapYazar.TabIndex = 13;
            this.labelKitapYazar.Text = "Yazar:";
            // 
            // KitapEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(607, 315);
            this.Controls.Add(this.labelKitapYazar);
            this.Controls.Add(this.comboBoxKitapEkleYayinEvi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxKitapEkleDil);
            this.Controls.Add(this.textBoxKitapEkleAciklama);
            this.Controls.Add(this.numericUpDownKitapEkleSayfaSayi);
            this.Controls.Add(this.comboBoxKitapEkleYazar);
            this.Controls.Add(this.numericUpDownKitapEkleBaskiYil);
            this.Controls.Add(this.textBoxKitapEkleAd);
            this.Controls.Add(this.buttonKitapEkle);
            this.Controls.Add(this.labelKitapEkleAd);
            this.Controls.Add(this.labelKitapEkleBaskiYil);
            this.Controls.Add(this.labelKitapEkleAciklama);
            this.Controls.Add(this.labelKitapEkleSayfaSayi);
            this.Controls.Add(this.labelKitapEkleYayinEvi);
            this.Controls.Add(this.labelKitapEkleDil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KitapEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KitapEkle";
            this.Load += new System.EventHandler(this.KitapEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKitapEkleBaskiYil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKitapEkleSayfaSayi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxKitapEkleYazar;
        private System.Windows.Forms.TextBox textBoxKitapEkleAd;
        private System.Windows.Forms.Label labelKitapEkleAd;
        private System.Windows.Forms.Label labelKitapEkleBaskiYil;
        private System.Windows.Forms.Label labelKitapEkleSayfaSayi;
        private System.Windows.Forms.Label labelKitapEkleDil;
        private System.Windows.Forms.Label labelKitapEkleYayinEvi;
        private System.Windows.Forms.Label labelKitapEkleAciklama;
        private System.Windows.Forms.TextBox textBoxKitapEkleAciklama;
        private System.Windows.Forms.Button buttonKitapEkle;
        private System.Windows.Forms.NumericUpDown numericUpDownKitapEkleBaskiYil;
        private System.Windows.Forms.NumericUpDown numericUpDownKitapEkleSayfaSayi;
        private System.Windows.Forms.ComboBox comboBoxKitapEkleDil;
        private System.Windows.Forms.ComboBox comboBoxKitapEkleYayinEvi;
        private System.Windows.Forms.Label labelKitapYazar;
    }
}