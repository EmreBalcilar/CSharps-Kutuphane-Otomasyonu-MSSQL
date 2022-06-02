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
    public partial class UyeListeleDuzenle : Form
    {
        public UyeListeleDuzenle()
        {
            InitializeComponent();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,    
            int nTopRect,      
            int nRightRect,    
            int nBottomRect,   
            int nWidthEllipse, 
            int nHeightEllipse 
        );

        SqlConnection baglanti =
       new SqlConnection(@"Data Source=DESKTOP-GS8Q206;Initial Catalog=Kutuphane;Integrated Security=True");
        private void UyeListeleDuzenle_Load(object sender, EventArgs e)
        {

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            string secilen = UyeListele.UyeListeleSecilen.ToString();
            baglanti.Open();
            SqlCommand UyeListeleDuzenle = new SqlCommand("SELECT *  FROM Uyeler WHERE UyeNo = @secilen  ", baglanti);
            UyeListeleDuzenle.Parameters.Add("@secilen", SqlDbType.Int).Value = UyeListele.UyeListeleSecilen.ToString();
            SqlDataReader sonuclar = UyeListeleDuzenle.ExecuteReader();
            while (sonuclar.Read())
            {
                labelUyeListeleDuzenleSecilen.Text = sonuclar["UyeNo"].ToString();
                textBoxUyeListeleDuzenleAd.Text = sonuclar["UyeAd"].ToString();
                textBoxUyeListeleDuzenleSoyad.Text = sonuclar["UyeSoyad"].ToString();
                maskedTextBoxUyeListeleDuzenleTelefon.Text = sonuclar["UyeTelefon"].ToString();
                textBoxUyeListeleDuzenleEposta.Text = sonuclar["UyeEposta"].ToString();
                textBoxUyeListeleDuzenleAdres.Text = sonuclar["UyeAdres"].ToString();


            }
            baglanti.Close();
        }

        private void buttonUyeListeleDuzenleKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komutUyeListeleDuzenle = new SqlCommand("UPDATE Uyeler SET UyeAd=@UyeAd,UyeSoyad=@UyeSoyad,UyeTelefon=@UyeTelefon,UyeEposta=@UyeEposta,UyeAdres=@UyeAdres WHERE UyeNo = @secilen  ", baglanti);
                komutUyeListeleDuzenle.Parameters.Add("@secilen", SqlDbType.Int).Value = UyeListele.UyeListeleSecilen.ToString();
                komutUyeListeleDuzenle.Parameters.Add("@UyeAd", SqlDbType.NVarChar).Value = textBoxUyeListeleDuzenleAd.Text;
                komutUyeListeleDuzenle.Parameters.Add("@UyeSoyad", SqlDbType.NVarChar).Value = textBoxUyeListeleDuzenleSoyad.Text;
                komutUyeListeleDuzenle.Parameters.Add("@UyeTelefon", SqlDbType.NVarChar).Value = maskedTextBoxUyeListeleDuzenleTelefon.Text.ToString();
                komutUyeListeleDuzenle.Parameters.Add("@UyeEposta", SqlDbType.NVarChar).Value = textBoxUyeListeleDuzenleEposta.Text;
                komutUyeListeleDuzenle.Parameters.Add("@UyeAdres", SqlDbType.NVarChar).Value = textBoxUyeListeleDuzenleAdres.Text;



                baglanti.Open();
                komutUyeListeleDuzenle.ExecuteNonQuery();
                MessageBox.Show("Üye Düzenlendi");
                baglanti.Close();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("hata");
            }
            UyeListele frm = new UyeListele();
            frm.Show();
        }

        private void buttonUyeListeleDuzenleSil_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Üyeyi silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                try
                {
                    string secilen = UyeListele.UyeListeleSecilen.ToString();

                    baglanti.Open();
                    SqlCommand KayitSil = new SqlCommand("DELETE FROM Uyeler WHERE UyeNo=@secilen  ", baglanti);
                    KayitSil.Parameters.Add("@secilen", SqlDbType.Int).Value = UyeListele.UyeListeleSecilen.ToString();
                    KayitSil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt başarıyla silindi");
                    this.Hide();
                }
                catch (Exception)
                {

                    MessageBox.Show("Bir hata oluştu");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            UyeListele frm = new UyeListele();
            frm.Show();

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
