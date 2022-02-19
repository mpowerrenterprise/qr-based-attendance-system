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
    public partial class leave_management : Form
    {
        public leave_management()
        {
            InitializeComponent();
        }

        curd_functions curd = new curd_functions();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Text.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            string sqlcode = "SELECT DISTINCT batch_no FROM student_data where department = '"+comboBox1.Text+"'";

            MySqlDataReader data = curd.SelectQ(sqlcode);

            while (data.Read())
            {
                comboBox2.Items.Add(data.GetString(0));
            }
        }
        public void getDataForLeaveManagement(string sqlcode1, string sqlcode2)
        {


            DataTable tab = new DataTable();
            tab.Columns.Add("Student ID");
            tab.Columns.Add("Firstname");
            tab.Columns.Add("Lastname");
            tab.Columns.Add("Department");
            tab.Columns.Add("Batch No");
            tab.Columns.Add("Gender");
            tab.Columns.Add("Phone No");
            tab.Columns.Add("Attendance");

            MySqlDataReader data = curd.SelectQ(sqlcode1);

            while (data.Read())
            {

                tab.Rows.Add(data.GetString("student_id"), data.GetString("firstname"), data.GetString("lastname"), data.GetString("department"), data.GetString("batch_no"), data.GetString("gender"), data.GetString("phone_no"), "PRESENT");

            }

            data_view.DataSource = tab;

        }
        private void leave_management_Load(object sender, EventArgs e)
        {
            data_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            string sqlcode1 = "SELECT student_data.*  FROM attendance_data, student_data WHERE student_data.student_id = attendance_data.student_id AND student_data.batch_no = '" + comboBox2.Text + "' and attendance_data._date = '" + dateTimePicker1.Text + "' AND student_data.department = '"+comboBox1.Text+"'";
            
            getDataForLeaveManagement(sqlcode1, "");


        }
    }
}
