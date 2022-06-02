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
    public partial class EmanetEkle : Form
    {

        SqlConnection baglanti =
      new SqlConnection(@"Data Source=DESKTOP-GS8Q206;Initial Catalog=Kutuphane;Integrated Security=True");
        public EmanetEkle()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            buttonEmanetVer.Region= Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonEmanetVer.Width, buttonEmanetVer.Height , 30, 30));
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

        private void EmanetEkle_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(131, 189, 117);
            dateTimePickerEmanetVerEmanetVermeTarih.Value = DateTime.Today;
            dateTimePickerEmanetVerEmanetAlmaTarih.Value = DateTime.Today.AddDays(1);
            dateTimePickerEmanetVerEmanetVermeTarih.Value.ToString("MM/dd/yyyy");


            //combox üyeleri listelemek için
            SqlDataAdapter adp = new SqlDataAdapter("SELECT UyeNo,(UyeAd + ' ' + UyeSoyad + ' TEL: ' + UyeTelefon ) AS UyeBilgi FROM Uyeler ORDER BY UyeAd ASC", baglanti);
            DataTable ComboboxUyeAd = new DataTable();
            adp.Fill(ComboboxUyeAd);

            CB_Emanet_U_AD.DataSource = ComboboxUyeAd;

            CB_Emanet_U_AD.DisplayMember = "UyeBilgi";// Combobox ta görünecek olan hücre
            CB_Emanet_U_AD.ValueMember = "UyeNo"; // Arka Planda tutulacak olan hücre
            
            //Combobox kitapları listemek için
            SqlDataAdapter EmanetListele = new SqlDataAdapter("SELECT KitapNo,(KitapAd + ' - ' + KitapYazari  + ' - ' + KitapYayinEvi ) AS KitapBilgi FROM Kitaplar ORDER BY KitapAd ASC", baglanti);
            DataTable ComboboxKitapAd = new DataTable();
            EmanetListele.Fill(ComboboxKitapAd);

            CB_EmanetKitap.DataSource = ComboboxKitapAd;

            CB_EmanetKitap.DisplayMember = "KitapBilgi";// Combobox ta görünecek olan hücre
            CB_EmanetKitap.ValueMember = "KitapNo"; // Arka Planda tutulacak olan hücre
            

        }

        private void buttonEmanetVer_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show(comboBoxEmanetVerUyeAd.SelectedValue.ToString());
            //  MessageBox.Show(comboBoxEmanetVerKitapAd.SelectedValue.ToString());

            try
            {
                DateTime dtime1 = dateTimePickerEmanetVerEmanetVermeTarih.Value;
                DateTime dtime2 = dateTimePickerEmanetVerEmanetAlmaTarih.Value;
                dateTimePickerEmanetVerEmanetVermeTarih.Value.ToString("MM/dd/yyyy");
                dateTimePickerEmanetVerEmanetAlmaTarih.Value.ToString("MM/dd/yyyy");


                DateTime simdikizaman = DateTime.Now;
                int sonuc = DateTime.Compare(dtime1, dtime2);

                if (sonuc == 1)

                {
                    MessageBox.Show("Emanet Geri Alma Tarihi Emanet Vermeden Önce Olamaz");
                }

                else
                {


                    SqlCommand komut = new SqlCommand("INSERT INTO Emanetler (UyeNo,KitapNo,EmanetVermeTarih,EmanetGeriAlmaTarih,EmanetIslemTarih,EmanetNot) VALUES (@UyeNo,@KitapNo,@EmanetVermeTarih,@EmanetGeriAlmaTarih,@EmanetIslemTarih,@EmanetNot)", baglanti);
                    komut.Parameters.Add("@UyeNo", SqlDbType.Int).Value = CB_Emanet_U_AD.SelectedValue.ToString();
                    komut.Parameters.Add("@KitapNo", SqlDbType.Int).Value = CB_EmanetKitap.SelectedValue.ToString();
                    komut.Parameters.Add("@EmanetVermeTarih", SqlDbType.DateTime).Value = dateTimePickerEmanetVerEmanetVermeTarih.Value;
                    komut.Parameters.Add("@EmanetGeriAlmaTarih", SqlDbType.DateTime).Value = dateTimePickerEmanetVerEmanetAlmaTarih.Value;
                    komut.Parameters.Add("@EmanetIslemTarih", SqlDbType.DateTime).Value = simdikizaman;
                    komut.Parameters.Add("@EmanetNot", SqlDbType.NVarChar).Value = TXT_EMANET_NOT.Text;

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Emanet Başarıyla Eklendi");

                    baglanti.Close();

                }


            }
            catch (Exception)
            {

                MessageBox.Show("Bir Hata Oluştu");
            }
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
