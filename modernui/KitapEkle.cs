using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
namespace modernui
{
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        SqlConnection baglanti =
       new SqlConnection(@"Data Source=DESKTOP-GS8Q206;Initial Catalog=Kutuphane;Integrated Security=True");
        private void buttonKitapEkle_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> KitapYayinEvleri = new List<string>();
                List<string> KitapDil = new List<string>();
                List<string> KitapYazar = new List<string>();



                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("SELECT KitapYayinEvi  FROM kitaplar", baglanti);

                SqlDataReader sonuclar2 = komut2.ExecuteReader();

                    
                
                baglanti.Close();
                SqlCommand komut = new SqlCommand("INSERT INTO Kitaplar (KitapAd,KitapYazari,KitapBaskiYil,KitapSayfaSayi,KitapDil,KitapYayinEvi,KitapAciklama) VALUES (@KitapAd,@KitapYazari,@KitapBaskiYil,@KitapSayfaSayi,@KitapDil,@KitapYayinEvi,@KitapAciklama)", baglanti);
                komut.Parameters.Add("@KitapAd", SqlDbType.NVarChar).Value = textBoxKitapEkleAd.Text;
                komut.Parameters.Add("@KitapYazari", SqlDbType.NVarChar).Value = comboBoxKitapEkleYazar.Text;
                komut.Parameters.Add("@KitapBaskiYil", SqlDbType.Int).Value = numericUpDownKitapEkleBaskiYil.Value;
                komut.Parameters.Add("@KitapSayfaSayi", SqlDbType.Int).Value = numericUpDownKitapEkleSayfaSayi.Value;
                komut.Parameters.Add("@KitapDil", SqlDbType.NVarChar).Value = comboBoxKitapEkleDil.Text;
                komut.Parameters.Add("@KitapYayinEvi", SqlDbType.NVarChar).Value = comboBoxKitapEkleYayinEvi.Text;
                komut.Parameters.Add("@KitapAciklama", SqlDbType.Text).Value = textBoxKitapEkleAciklama.Text;


                
                baglanti.Open();
                komut.ExecuteNonQuery();
                MessageBox.Show("Kitap Başarıyla Eklendi");
                textBoxKitapEkleAd.Text = null;
                numericUpDownKitapEkleBaskiYil.Value = 2022;
                numericUpDownKitapEkleSayfaSayi.Value = 0;
                comboBoxKitapEkleDil.Text = "Türkçe";
                comboBoxKitapEkleYayinEvi.Text = "Bilinmiyor";
                textBoxKitapEkleAciklama.Text = null;



                baglanti.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Bir Hata Oluştu");
            }



        }

        private void KitapEkle_Load(object sender, EventArgs e)
        {
            //textBoxKitapEkleAd.BackColor = System.Drawing.ColorTranslator.FromHtml("#3fd0dd");
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            comboBoxKitapEkleDil.Items.Clear();
            comboBoxKitapEkleYayinEvi.Items.Clear();
            comboBoxKitapEkleYazar.Items.Clear();
            //String tipinde liste oluşturuyoruz ce altt kısımda while kısmında bunları ekliyoruz
            //List<string> KitapYayinEvleri = new List<string>();
            //List<string> KitapDil = new List<string>();
            //List<string> KitapYazar = new List<string>();



            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT DISTINCT KitapYayinEvi  FROM kitaplar", baglanti);

            // SqlDataReader sonuclar2 = komut2.ExecuteReader();
            //SqlCommand komut3 = new SqlCommand();
            komut2.Connection = baglanti;
            komut2.CommandType = CommandType.Text;

            SqlDataReader dr;
            
            dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                comboBoxKitapEkleYayinEvi.Items.Add(dr["KitapYayinEvi"]);

            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komutKitapDil = new SqlCommand("SELECT DISTINCT KitapDil  FROM kitaplar", baglanti);
            dr = komutKitapDil.ExecuteReader();
            while (dr.Read())
            {
                comboBoxKitapEkleDil.Items.Add(dr["KitapDil"]);

            }
            baglanti.Close();
            baglanti.Open();

            SqlCommand komutKitapYazar = new SqlCommand("SELECT DISTINCT KitapYazari  FROM kitaplar", baglanti);

            dr = komutKitapYazar.ExecuteReader();
            
            while (dr.Read())
            {
                comboBoxKitapEkleYazar.Items.Add(dr["KitapYazari"]);

            }
            baglanti.Close();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile("back_hover.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile("back.png");
        }
    }
    }

