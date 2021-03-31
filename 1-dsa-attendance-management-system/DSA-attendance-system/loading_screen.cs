using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DSA_attendance_system
{
    public partial class loading_screen : Form
    {
        public loading_screen()
        {
            InitializeComponent();
        }


        
        private void loading_screen_Load(object sender, EventArgs e)
        {
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Start();


        }

        int per = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            per++;

            if (per == 100)
            {

                this.Hide();
                timer1.Stop();

                dashboard DB = new dashboard();
                DB.Show();
                this.Hide();
            }
            else
            {

                xuiFlatProgressBar1.Value = per;

            }

        }
    }
    
}
