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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do You Really Want to Close the System? ", "Exit", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                dashboard d = new dashboard();
                d.Show();
                this.Hide();
            }
            
        }

        private void employeeManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            remarks_text sm = new remarks_text();
            sm.MdiParent = this;
            sm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings set = new settings();
            set.MdiParent = this;
            set.Show();
        } 
    }
}