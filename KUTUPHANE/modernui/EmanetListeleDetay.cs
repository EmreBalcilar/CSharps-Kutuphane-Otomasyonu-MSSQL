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
    public partial class EmanetListeleDetay : Form
    {
        public EmanetListeleDetay()
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
        private void EmanetListeleDetay_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            baglanti.Open();
            // Emanetler deki üye no Uyeler Üye no eşle kitaplar tablosundaki kitapno ile emanetler tablosundaki kitapno eşle where nerede emanetlerdeki emanetno tıklanıp seçilen seçilen emanet no su ise
            SqlCommand EmanetListeleDetay = new SqlCommand("SELECT * FROM Emanetler INNER JOIN Uyeler ON Emanetler.UyeNo = Uyeler.UyeNo INNER JOIN Kitaplar ON Kitaplar.KitapNo=Emanetler.KitapNo WHERE Emanetler.EmanetNo = @secilenEmanetNo", baglanti);
            EmanetListeleDetay.Parameters.Add("@secilenEmanetNo", SqlDbType.Int).Value = EmanetListesi.EmanetListeleSecilenEmanetNo.ToString();

            SqlDataReader sonuclar = EmanetListeleDetay.ExecuteReader();
            while (sonuclar.Read())
            {
                labelEmanetNoVeri.Text = sonuclar["EmanetNo"].ToString();
                labelEmanetVermeTarihVeri.Text = sonuclar["EmanetVermeTarih"].ToString();
                labelEmanetAlmaVeri.Text = sonuclar["EmanetGeriAlmaTarih"].ToString();
                labelEmanetIslemTarihVeri.Text = sonuclar["EmanetIslemTarih"].ToString();
                labelEmanetNotVeri.Text = sonuclar["EmanetNot"].ToString();

                labelUyeNoVeri.Text = sonuclar["UyeNo"].ToString();
                labelUyeAdVeri.Text = sonuclar["UyeAd"].ToString();
                labelUyeSoyadVeri.Text = sonuclar["UyeSoyad"].ToString();
                labelUyeTelefonVeri.Text = sonuclar["UyeTelefon"].ToString();
                labelUyeEpostaVeri.Text = sonuclar["UyeEposta"].ToString();
                labelUyeAdresVeri.Text = sonuclar["UyeAdres"].ToString();

                labelKitapNoVeri.Text = sonuclar["KitapNo"].ToString();
                labelKitapAdVeri.Text = sonuclar["KitapAd"].ToString();
                labelKitapYazarVeri.Text = sonuclar["KitapYazari"].ToString();
                labelKitapBaskiYilVeri.Text = sonuclar["KitapBaskiYil"].ToString();
                labelKitapSayfaSayiVeri.Text = sonuclar["KitapSayfaSayi"].ToString();
                labelKitapDilVeri.Text = sonuclar["KitapDil"].ToString();
                labelKitapYayinEviVeri.Text = sonuclar["KitapYayinEvi"].ToString();
                labelKitapAciklamaVeri.Text = sonuclar["KitapAciklama"].ToString();


            }

            baglanti.Close();

        }

        private void buttonKitapTeslimAlindi_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Kitabın Teslim Alındı mı?", "Uyarı", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                try
                {


                    baglanti.Open();
                    //GÜncelle emanetler tablosundaki emanet teslim edildi bloğunu EVET  olarak değiştir 
                    SqlCommand EmanetTeslimEdildi = new SqlCommand("UPDATE Emanetler SET EmanetTeslimEdildi='Evet' WHERE EmanetNo = @secilen   ", baglanti);
                    EmanetTeslimEdildi.Parameters.Add("@secilen", SqlDbType.Int).Value = EmanetListesi.EmanetListeleSecilenEmanetNo.ToString();
                    EmanetTeslimEdildi.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kitap Teslim Alındı");
                    this.Hide();
                }
                catch (Exception)
                {

                    MessageBox.Show("Bir hata oluştu");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
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
