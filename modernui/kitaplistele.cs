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
    public partial class kitaplistele : Form
    {
        public kitaplistele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =
new SqlConnection(@"Data Source=DESKTOP-GS8Q206;Initial Catalog=Kutuphane;Integrated Security=True");
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
        private void kitaplistele_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT  *  FROM kitaplar", baglanti);


            SqlDataAdapter veri = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            veri.Fill(dt);

            dataGridViewKitapListele.DataSource = dt;

            baglanti.Close();
        }
        public static string KitapListeleSecilen;

        private void dataGridViewKitapListele_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            KitapListeleSecilen = dataGridViewKitapListele.Rows[dataGridViewKitapListele.CurrentRow.Index].Cells["KitapNo"].Value.ToString();
            KitapListeleDuzenle FormKitapListeleDuzenle = new KitapListeleDuzenle();
            FormKitapListeleDuzenle.Show();
            this.Close();
            
            
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
