using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace modernui
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        public Form2()
        {

            
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            /* Form1 frm = new Form1();
             if(textBox1.Text =="Emre")
             {
                 frm.Show();
                 this.Hide();
             }
            */

            string user = textBox1.Text;
            string password = textBox2.Text;
            con = new SqlConnection(@"Data Source=DESKTOP-GS8Q206;Initial Catalog=Kutuphane;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText="Select * from Adminlogin where Username='"+textBox1.Text+"'And Password='" + textBox2.Text + "' ";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                AnaSayfa frm = new AnaSayfa();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı giriş yaptınız");

            }



        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#3fd0dd");
            textBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#3fd0dd");

        }

        

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';
                textBox2.Text = "";
            }
        }

       
    }
}
