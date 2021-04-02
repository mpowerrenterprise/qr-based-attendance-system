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
    public partial class remarks_text : Form
    {
        public remarks_text()
        {
            InitializeComponent();
        }

        curd_functions curd = new curd_functions();
        string selected_cell_item = "";


        private void student_management_Load(object sender, EventArgs e)
        {
            data_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataViwer();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void clearboxes() {

            student_id_box.Clear();
            firstname_box.Clear();
            lastname_box.Clear();
            batch_no_box.Clear();
            male_button.Checked = false;
            female_button.Checked = false;
            email__box.Clear();
            phone__box.Clear();
            department_box.Text = "";
            remarks__box.Clear();
        }


        public void DataViwer()
        {

            DataTable tab = new DataTable();
            tab.Columns.Add("Student ID");
            tab.Columns.Add("Firstname");
            tab.Columns.Add("Lastname");
            tab.Columns.Add("Department");
            tab.Columns.Add("Batch No");
            tab.Columns.Add("Date of Birth");
            tab.Columns.Add("Gender");
            tab.Columns.Add("Email");
            tab.Columns.Add("Phone No");
            tab.Columns.Add("Remarks");
            
            string sqlcode = "SELECT * FROM student_data";
            MySqlDataReader data = curd.SelectQ(sqlcode);
            
            while (data.Read())
            {

                tab.Rows.Add(data.GetString("student_id"), data.GetString("firstname"), data.GetString("lastname"), data.GetString("department"), data.GetString("batch_no"), data.GetString("dob"), data.GetString("gender"), data.GetString("email") , data.GetString("phone_no"), data.GetString("remarks"));

            }
            
            data_view.DataSource = tab;
            
        }

        public void DataViwerForSearch(string query)
        {

            DataTable tab = new DataTable();
            tab.Columns.Add("Student ID");
            tab.Columns.Add("Firstname");
            tab.Columns.Add("Lastname");
            tab.Columns.Add("Department");
            tab.Columns.Add("Batch No");
            tab.Columns.Add("Date of Birth");
            tab.Columns.Add("Gender");
            tab.Columns.Add("Email");
            tab.Columns.Add("Phone No");
            tab.Columns.Add("Remarks");
            
            MySqlDataReader data = curd.SelectQ(query);
            
            while (data.Read())
            {

                tab.Rows.Add(data.GetString("student_id"), data.GetString("firstname"), data.GetString("lastname"), data.GetString("department"), data.GetString("batch_no"), data.GetString("dob"), data.GetString("gender"), data.GetString("email") , data.GetString("phone_no"), data.GetString("remarks"));

            }
            
            data_view.DataSource = tab;
            
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {

            string gender = "";

            if (male_button.Checked == true) {

                gender = "Male";

            } else {

                gender = "Female";
            }

            string check_data_exit = "SELECT student_id from student_data where student_id = '" + student_id_box.Text + "'";
            MySqlDataReader data = curd.SelectQ(check_data_exit);

            string student_id_exits = "";

            while (data.Read())
            {
                student_id_exits = data.GetString(0);
            }

            if (student_id_exits == "")
            {

                string sqlcode = "INSERT INTO student_data VALUES('','" + student_id_box.Text + "', '" + firstname_box.Text + "','" + lastname_box.Text + "','" + dateTimePicker1.Text + "','" + gender + "','" + email__box.Text + "','" + phone__box.Text + "','" + department_box.Text + "','" + batch_no_box.Text + "','" + remarks__box.Text + "')";
                curd.CUD(sqlcode);
                clearboxes();
                gender = "";
                MessageBox.Show("Data inserted successfully");

            }
            else {

                MessageBox.Show("This student ID '"+student_id_exits+"' already exits!.", "Insertion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                student_id_box.Clear();
            }

            student_id_exits = "";
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchquery = "";

            if (textBox1.Text == "")
            {

                DataViwer();

            }
            else {

                if (comboBox1.Text == "Student ID")
                {

                    searchquery = "SELECT * FROM student_data WHERE student_id like'" + textBox1.Text + "%'";
                    DataViwerForSearch(searchquery);

                }
                else if (comboBox1.Text == "Firstname")
                {

                    searchquery = "SELECT * FROM student_data WHERE firstname like'" + textBox1.Text + "%'";
                    DataViwerForSearch(searchquery);
                }
                else if (comboBox1.Text == "Email")
                {

                    searchquery = "SELECT * FROM student_data WHERE email like'" + textBox1.Text + "%'";
                    DataViwerForSearch(searchquery);

                }
                else {

                    MessageBox.Show("Please select an option from searching types", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                }

            }

        }

        private void data_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int rowindex = data_view.CurrentCell.RowIndex;
            selected_cell_item = data_view.Rows[rowindex].Cells[0].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete student ID ("+selected_cell_item+")?", "Are you sure?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                string sqlcode = "DELETE FROM student_data WHERE student_id = '" + selected_cell_item + "'";
                curd.CUD(sqlcode);
                DataViwer();
                MessageBox.Show("Deletion Successfull ("+selected_cell_item+")");
                selected_cell_item = "";
            }
        }
    }
}
