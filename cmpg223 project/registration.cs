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

namespace cmpg223_project
{
    public partial class registration : Form
    {

        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        SqlCommand command; 
        public registration()
        {
            InitializeComponent();
        }


        //Employee detail variables 
        public int employeeID;
        public string employeeFname ;
        public string employeeLName;
        public string employeeCellnr;
        public string empEmail;


        //client detail variables
        public int clientID;
        public string cleintFname;
        public string clientLName;
        public string clientCellnr;
        public string companyname;
        public string clientEmail;

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                groupBox2.Show();
            }
            else
            {
                groupBox2.Hide();
            }
        }

        private void registration_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox1.Show();
            }
            else
            {
                groupBox1.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            employeeFname = eFName.Text;
            employeeLName = eLName.Text;
            employeeCellnr = eNr.Text;
            empEmail = eEmail.Text;

            // employee signup button 
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();
                command = new SqlCommand("Insert into Emplyees Values(" + employeeID + "," +
                    " ' " + employeeFname+ "', '" + employeeLName + "', '" + employeeCellnr + "', " +
                    "'" + empEmail + "') ", conn);

                adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Sign UP Successful");

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eName_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void clientsSignUP_Click(object sender, EventArgs e)
        {
            cleintFname = cFName.Text;
            clientLName = cLName.Text;
            companyname = cCompanyname.Text;
            clientCellnr = cNr.Text;
            clientEmail = cEmail.Text;


            // cleints/company sign up
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();
                command = new SqlCommand("Insert into Clients Values(" + clientID + ", ' " + companyname + "'," +
                    " '" + clientEmail + "', '" + clientCellnr+ "', '" +cleintFname+ "' , '" +clientLName+ "') ", conn);

                adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Sign UP Successful");

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void generateID_Click(object sender, EventArgs e)
        {
            var random = new Random();
            employeeID = random.Next(1,1000);

            var random2 = new Random();
            clientID = random2.Next(1001, 2000);

            if (checkBox1.Checked)
            {
                IDtxt.Text = employeeID.ToString();
            }
            else
            {
                IDtxt.Text= clientID.ToString();
            }
        }
    }
}
