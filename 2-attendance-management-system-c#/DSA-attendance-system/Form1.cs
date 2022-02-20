using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DSA_attendance_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.password.AutoSize = false;
            this.password.Size = new Size(this.password.Size.Width, 38);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
     
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Red;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            curd_functions curd1 = new curd_functions();
            string sql = "SELECT username, password FROM user_account";
            MySqlDataReader data = curd1.SelectQ(sql);


            string server_username = "";
            string server_password = "";

            while (data.Read())
            {

                server_username = data.GetString("username");
                server_password = data.GetString("password");

            }


            string entered_username = username.Text;
            string entered_password = password.Text;


            if (entered_username == server_username && entered_password == server_password)
            {

                loading_screen LS = new loading_screen();
                LS.Show();
                this.Hide();

            }
            else
            {

                MessageBox.Show("Password or username is invalid", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.Clear();
                password.Clear();
                username.Focus();
            }


        }
    }
}
