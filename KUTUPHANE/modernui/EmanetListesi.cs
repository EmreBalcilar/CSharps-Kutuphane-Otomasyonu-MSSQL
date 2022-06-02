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
using Microsoft.Office.Interop.Excel;


namespace modernui
{
    public partial class EmanetListesi : Form
    {
        public EmanetListesi()
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
        private void EmanetListesi_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            baglanti.Open();
           // SqlCommand komutEmanetleriListele = new SqlCommand("SELECT * from emanetler", baglanti);

           SqlCommand komutEmanetleriListele = new SqlCommand("SELECT EmanetNo, UyeAd,UyeSoyad,UyeTelefon,KitapAd,EmanetVermeTarih,EmanetGeriAlmaTarih,EmanetNot FROM Emanetler INNER JOIN Uyeler ON Emanetler.UyeNo = Uyeler.UyeNo INNER JOIN Kitaplar ON Kitaplar.KitapNo=Emanetler.KitapNo WHERE EmanetTeslimEdildi='Hayır'", baglanti);


            SqlDataAdapter veri = new SqlDataAdapter(komutEmanetleriListele);

            System.Data.DataTable dt = new System.Data.DataTable();
            veri.Fill(dt);
            dataGridViewEmanetleriListele.DataSource = dt;
            baglanti.Close();




        }
        public static string EmanetListeleSecilenEmanetNo;

        private void dataGridViewEmanetleriListele_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            EmanetListeleSecilenEmanetNo = dataGridViewEmanetleriListele.Rows[dataGridViewEmanetleriListele.CurrentRow.Index].Cells["EmanetNo"].Value.ToString();

            EmanetListeleDetay FormEmanetListeleDetay = new EmanetListeleDetay();
            FormEmanetListeleDetay.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Close();
        }

        private void groupBoxEmanettekiKitaplarListele_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewEmanetleriListele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
            uyg.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sayfa = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
            for (int i = 0; i < dataGridViewEmanetleriListele.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sayfa.Cells[1, i + 1];
                myRange.Value2 = dataGridViewEmanetleriListele.Columns[i].HeaderText;

            }
            for (int i = 0; i < dataGridViewEmanetleriListele.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridViewEmanetleriListele.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sayfa.Cells[j + 2, i + 1];
                    myRange.Value2 = dataGridViewEmanetleriListele[i, j].Value;




                }
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = Image.FromFile("excel_hover.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = Image.FromFile("excel.png");
        }
    }
}
        
    
