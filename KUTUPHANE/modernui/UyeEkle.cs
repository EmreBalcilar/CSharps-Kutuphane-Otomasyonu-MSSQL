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
    public partial class UyeEkle : Form
    {
        public UyeEkle()
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

        private void buttonUyeEkle_Click(object sender, EventArgs e)
        {
            
                SqlCommand komutUyeEkle = new SqlCommand("INSERT INTO Uyeler (UyeAd,UyeSoyad,UyeTelefon,UyeEposta,UyeAdres) VALUES (@UyeAd,@UyeSoyad,@UyeTelefon,@UyeEposta,@UyeAdres)", baglanti);
                komutUyeEkle.Parameters.Add("@UyeAd", SqlDbType.NVarChar).Value = textBoxUyeEkleAd.Text;
                komutUyeEkle.Parameters.Add("@UyeSoyad", SqlDbType.NVarChar).Value = textBoxUyeEkleSoyad.Text;
                komutUyeEkle.Parameters.Add("@UyeTelefon", SqlDbType.NVarChar).Value = maskedTextBoxUyeEkleTelefon.Text.ToString();
                komutUyeEkle.Parameters.Add("@UyeEposta", SqlDbType.NVarChar).Value = textBoxUyeEkleEposta.Text;
                komutUyeEkle.Parameters.Add("@UyeAdres", SqlDbType.NVarChar).Value = textBoxUyeEkleAdres.Text;

                

                baglanti.Open();
                komutUyeEkle.ExecuteNonQuery();
                MessageBox.Show("Üye Başarıyla Eklendi");
                baglanti.Close();
                // Üye eklendikten sonra textboxları içi boş yapıyor
                
                textBoxUyeEkleAd.Text = "";
                textBoxUyeEkleSoyad.Text = "";
                maskedTextBoxUyeEkleTelefon.Text = "";
                textBoxUyeEkleEposta.Text = "";
                textBoxUyeEkleAdres.Text = "";



            
            
        }

        private void UyeEkle_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            this.BackColor = Color.FromArgb(192, 192, 192);

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

        private void labelUyeEkleAdres_Click(object sender, EventArgs e)
        {

        }
    }
}
