using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    //added namespace

namespace cmpg223_project
{
    public partial class clientF : Form
    {
        public clientF()
        {
            InitializeComponent();
        }

        //// Global connection string
        public string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True";

        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapt;
        SqlDataReader reader;
        DataSet ds;

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // for the search bar which will use the projectID of the client

            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                string sql = "SELECT * FROM ProjectAssignments WHERE projectID LIKE '%" + "'{txtSearch.Text}'" +"%'" ;
                command = new SqlCommand(sql, conn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lstOut.Items.Add("AssignmentID: " +reader.GetValue(0) + "\tRoleID: " +reader.GetValue(1) + "\tEmployeeID: " +reader.GetValue(2));
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();

        }

        private void lstOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
