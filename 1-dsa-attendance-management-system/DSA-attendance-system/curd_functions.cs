using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DSA_attendance_system
{
    class curd_functions
    {

        public void CUD(string q)
        {

            try
            {
                using (MySqlConnection myConnect = new MySqlConnection("SERVER=localhost;DATABASE=dsa_attendance_system;UID=root;PASSWORD="))
                {
                    myConnect.Open();
                    MySqlCommand myCommand = new MySqlCommand(q, myConnect);
                    myCommand.ExecuteNonQuery();
                    myConnect.Close();

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }

        }

        public MySqlDataReader SelectQ(string q)
        {

            try
            {
                MySqlConnection myConnect = new MySqlConnection("SERVER=localhost;DATABASE=dsa_attendance_system;UID=root;PASSWORD=");
                myConnect.Open();
                MySqlCommand myCommand = new MySqlCommand(q, myConnect);
                MySqlDataReader data = myCommand.ExecuteReader();
                return data;
                myConnect.Close();
                
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
                throw Ex;
            }

        }
    }
}
