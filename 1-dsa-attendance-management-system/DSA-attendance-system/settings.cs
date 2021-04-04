using MySql.Data.MySqlClient;
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
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        dashboard dashboardf;
        curd_functions curd = new curd_functions();

        private void insert_btn_Click(object sender, EventArgs e)
        {
            string selectCurrrentPassowrdSQL = "SELECT password from user_account";
            MySqlDataReader data = curd.SelectQ(selectCurrrentPassowrdSQL);

            string current_password_from_server = "";

            while (data.Read())
            {
                current_password_from_server = data.GetString(0);
            }

            string current_password_from_user = current_password.Text;

            if (new_password.Text.Length >= 8)
            {

                if (current_password_from_user == current_password_from_server)
                {

                    string NewPassword = new_password.Text;
                    string ConfirmPassowrd = confirm_password.Text;
                    
                    if (NewPassword == ConfirmPassowrd)
                    {
                        
                        string update_code = "UPDATE user_account SET password = '" + NewPassword + "'";
                        curd.CUD(update_code);
                        MessageBox.Show("Password has been updated successfully.");
                        current_password.Clear();
                        new_password.Clear();
                        confirm_password.Clear();
                        this.Hide();
                    
                    }
                    else
                    {

                        MessageBox.Show("Confirm password does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        current_password.Clear();
                        new_password.Clear();
                        confirm_password.Clear();

                    }

                }
                else
                {

                    MessageBox.Show("Current password is wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    current_password.Clear();
                    new_password.Clear();
                    confirm_password.Clear();

                }
            }
            else {


                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                current_password.Clear();
                new_password.Clear();
                confirm_password.Clear();

            }

        }
    }
}
