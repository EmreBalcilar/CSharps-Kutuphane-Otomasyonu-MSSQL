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
    public partial class UyeListele : Form
    {
        public UyeListele()
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
        private void UyeListele_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            baglanti.Open();
            SqlCommand UyeListele = new SqlCommand("SELECT *  FROM Uyeler", baglanti);
            SqlDataAdapter veri = new SqlDataAdapter(UyeListele);
            System.Data.DataTable dt = new System.Data.DataTable();
            veri.Fill(dt);
            dataGridViewUyeListele.DataSource = dt;
            baglanti.Close();
        }
        public static string UyeListeleSecilen;
        
        private void dataGridViewUyeListele_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UyeListeleSecilen = dataGridViewUyeListele.Rows[dataGridViewUyeListele.CurrentRow.Index].Cells["UyeNo"].Value.ToString();

            UyeListeleDuzenle FormUyeListeleDuzenle = new UyeListeleDuzenle();
            FormUyeListeleDuzenle.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Close();
        }

        private void dataGridViewUyeListele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UyeListele_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile("back_hover.png");
        }

        private void UyeListele_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile("back.png");
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
            for (int i = 0; i < dataGridViewUyeListele.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sayfa.Cells[1, i + 1];
                myRange.Value2 = dataGridViewUyeListele.Columns[i].HeaderText;

            }
            for (int i = 0; i < dataGridViewUyeListele.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridViewUyeListele.Rows.Count; j++)
                {

                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sayfa.Cells[j + 2, i + 1];
                    myRange.Value2 = dataGridViewUyeListele[i, j].Value;



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
