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
    public partial class KitapListeleDuzenle : Form
    {
        public KitapListeleDuzenle()
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
        private void KitapListeleDuzenle_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

            List<string> KitapYayinEvleri = new List<string>();
            List<string> KitapDil = new List<string>();

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
                comboBoxKitapDuzenleKitapYayinEvi.Items.Add(dr["KitapYayinEvi"]);

            }
            baglanti.Close();
            #region deneme2
            //kitap yayın evlerini listele
            //baglanti.Open();
            //SqlCommand komut2 = new SqlCommand("SELECT KitapYayinEvi  FROM kitaplar", baglanti);

            //SqlDataReader sonuclar2 = komut2.ExecuteReader();
            //while (sonuclar2.Read())
            //{
            //    string gelendeger = sonuclar2["KitapYayinEvi"].ToString();
            //    if (KitapYayinEvleri.Contains(gelendeger))
            //    { }
            //    else
            //    { KitapYayinEvleri.Add(sonuclar2["KitapYayinEvi"].ToString()); }
            //}
            //baglanti.Close();



            //yayın evlerini combox ekle
            //for (int i = 0; i < KitapYayinEvleri.Count; i++)
            //{
            //    comboBoxKitapDuzenleKitapYayinEvi.Items.Add(KitapYayinEvleri[i].ToString());
            //}


            ////kitap dilini göster
            //baglanti.Open();
            //SqlCommand komutKitapDil = new SqlCommand("SELECT KitapDil  FROM kitaplar", baglanti);

            //SqlDataReader sonuclarKitapDil = komutKitapDil.ExecuteReader();
            //while (sonuclarKitapDil.Read())
            //{
            //    string gelendeger = sonuclarKitapDil["KitapDil"].ToString();
            //    if (KitapDil.Contains(gelendeger)) //Contains koleksiyonda bulunan verilerin, belirlenen koşula göre olup olmadığını kontrol eder
            //    { }
            //    else
            //    { KitapDil.Add(sonuclarKitapDil["KitapDil"].ToString()); }
            //}
            //baglanti.Close();



            ////kitap dilleri combox ekle
            //for (int i = 0; i < KitapDil.Count; i++)
            //{
            //    comboBoxKitapDuzenleKitapDil.Items.Add(KitapDil[i].ToString());
            //}
            #endregion
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("SELECT DISTINCT KitapDil  FROM kitaplar", baglanti);

            // SqlDataReader sonuclar2 = komut2.ExecuteReader();
            //SqlCommand komut3 = new SqlCommand();
            komut3.Connection = baglanti;
            komut3.CommandType = CommandType.Text;

            

            dr = komut3.ExecuteReader();
            while (dr.Read())
            {
                comboBoxKitapDuzenleKitapDil.Items.Add(dr["KitapDil"]);

            }
            baglanti.Close();
            //Seçilen kitabı listele formundan index numarasını alıp stringe çeviriyoruz
            string secilen = kitaplistele.KitapListeleSecilen.ToString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *  FROM kitaplar WHERE KitapNo = @secilen  ", baglanti);
            //aşağıda ise secilem olarak aldığımız kitabın bilgilerini sayfa içindeki yönergelere eklenmesini sağlıyoruz
            komut.Parameters.Add("@secilen", SqlDbType.Int).Value = kitaplistele.KitapListeleSecilen.ToString();
            SqlDataReader sonuclar = komut.ExecuteReader();
            while (sonuclar.Read())
            {
                labelKitapDuzenleKitapNoSecilen.Text = sonuclar["KitapNo"].ToString();
                textBoxKitapDuzenleKitapAd.Text = sonuclar["KitapAd"].ToString();
                numericUpDownKitapDuzenleKitapBaskiYil.Value = Convert.ToInt32(sonuclar["KitapBaskiYil"].ToString());
                numericUpDownKitapDuzenleKitapSayfaSayi.Value = Convert.ToInt32(sonuclar["KitapSayfaSayi"].ToString());
                comboBoxKitapDuzenleKitapDil.Text = sonuclar["KitapDil"].ToString();
                comboBoxKitapDuzenleKitapYayinEvi.Text = sonuclar["KitapYayinEvi"].ToString();
                textBoxKitapDuzenleKitapAciklama.Text = sonuclar["KitapAciklama"].ToString();


            }
            baglanti.Close();
                    
        }
   
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Close();
        }

        private void buttonKitapDuzenleKaydet_Click_1(object sender, EventArgs e)
        {
            //Update komutu ile kitaplar tablosundaki bilgileri güncelliyoruz kitaplisesecilen den alınan index numarasına göre
            SqlCommand komut = new SqlCommand("UPDATE Kitaplar  SET KitapAd=@KitapAd,KitapBaskiYil=@KitapBaskiYil,KitapSayfaSayi=@KitapSayfaSayi,KitapDil=@KitapDil,KitapYayinEvi=@KitapYayinEvi,KitapAciklama=@KitapAciklama WHERE KitapNo = @secilen  ", baglanti);

            komut.Parameters.Add("@secilen", SqlDbType.Int).Value = kitaplistele.KitapListeleSecilen.ToString();
            komut.Parameters.Add("@KitapAd", SqlDbType.NVarChar).Value = textBoxKitapDuzenleKitapAd.Text;
            komut.Parameters.Add("@KitapBaskiYil", SqlDbType.NChar).Value = numericUpDownKitapDuzenleKitapBaskiYil.Value;
            komut.Parameters.Add("@KitapSayfaSayi", SqlDbType.NChar).Value = numericUpDownKitapDuzenleKitapSayfaSayi.Value;
            komut.Parameters.Add("@KitapDil", SqlDbType.NVarChar).Value = comboBoxKitapDuzenleKitapDil.Text;
            komut.Parameters.Add("@KitapYayinEvi", SqlDbType.NVarChar).Value = comboBoxKitapDuzenleKitapYayinEvi.Text;
            komut.Parameters.Add("@KitapAciklama", SqlDbType.Text).Value = textBoxKitapDuzenleKitapAciklama.Text;



            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kitap Düzenlendi");
            baglanti.Close();
            this.Close();
            kitaplistele klistele = new kitaplistele();
            klistele.Show();
        }

        private void buttonKitapDuzenleSil_Click_1(object sender, EventArgs e)
        {
          
                    //secilen değerinde kitaplistele sayfasından alınan static değer kitaplistesecilen string olarak atıyoruz
                    string secilen = kitaplistele.KitapListeleSecilen.ToString();

                    baglanti.Open();
                    SqlCommand KayitSil = new SqlCommand("DELETE FROM kitaplar WHERE KitapNo=@secilen  ", baglanti);
                    KayitSil.Parameters.Add("@secilen", SqlDbType.Int).Value = kitaplistele.KitapListeleSecilen.ToString();
                    KayitSil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt başarıyla silindi");
                    this.Hide();
                    kitaplistele klistele = new kitaplistele();
                    klistele.Show();


        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            kitaplistele klistele = new kitaplistele();
            klistele.Show();
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
