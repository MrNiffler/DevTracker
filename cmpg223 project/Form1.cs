using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace cmpg223_project
{
    public partial class Login : Form
    {



        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        SqlCommand command;

        public static int LoggedInEmployeeID { get; private set; }
        // Method to set the logged-in employee ID when authentication succeeds
        private void SetLoggedInEmployeeID(int employeeID)
        {
            LoggedInEmployeeID = employeeID;
        }
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*private bool EmployeeExists(int employeeID)
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT * FROM EMPLOYEES WHERE EmployeeID = @Employee", conn);
            command.Parameters.AddWithValue("@EmployeeID", employeeID);
            int count = (int)command.ExecuteScalar();
            conn.Close();
            return count > 0;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            if (adminCheckBox.Checked & userIDTextBox.Text == "1992" & passTextBox.Text == "DevTracker")
            {
                Form3 admin = new Form3();
                admin.ShowDialog();
            }
            else if (client.Checked)
            {

            }
            else if (Employee.Checked)
            {
               /* int employeeID;
                if (int.TryParse(Employee.Text, out employeeID))
                {
                    if (EmployeeExists(employeeID))
                    {*/

                        //SetLoggedInEmployeeID((int)employeeID);
                        FrmDeveloper employee = new FrmDeveloper();
                        employee.ShowDialog();

                   /* }
                    else
                    {
                        //MessageBox.Show("Invalid employee ID. Please enter a valid employee ID.");
                    }*/
               /* }
                else
                {
                   // MessageBox.Show("Invalid employee ID. Please enter a valid employee ID.");
                }*/


                //FrmDeveloper employee = new FrmDeveloper();
              //employee.ShowDialog();

            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            registration reg = new registration();
            reg.ShowDialog();
            this.Close();
        }
    }
}
