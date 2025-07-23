using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cmpg223_project
{
    public partial class Form3 : Form
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand command;
        
        public int clientID;
        public string cleintFname;
        public string clientLName;
        public string clientCellnr;
        public string companyname;
        public string clientEmail;

        public int projectId;
        public int phaseId;
        public int scheduleId;
        public int assignmentId;
        public string projectDesctription;

        public int roleId;
        public int empId;

        public Form3()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var random2 = new Random();
            clientID = random2.Next(1001, 2000);

            cleintFname = tbFname.Text;
            clientLName = tbLname.Text;
            companyname = tbCompName.Text;
            clientCellnr = tbPhone.Text;
            clientEmail = tbEmail.Text;

            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();
                command = new SqlCommand("Insert into Clients Values(" + clientID + ", ' " + companyname + "', '" + clientEmail + "', '" + clientCellnr + "', '" + cleintFname + "' , '" + clientLName + "') ", conn);

                adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Add Successful");

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();

                string updateQuery = "UPDATE Clients SET ClientCompanyName = @compName, ClientEmail = @email, " +
                    "ClientFirstName = @fName, ClientSurname = @sName, ClientPhoneNumber = @phoneNum " +
                                     "WHERE ClientId = @clientId";

                command = new SqlCommand(updateQuery, conn);

                command.Parameters.Add("@compName", SqlDbType.VarChar).Value = tbCompUpdate.Text;
                command.Parameters.Add("@email", SqlDbType.DateTime).Value = tbEmailUpdate.Text;
                command.Parameters.Add("@fName", SqlDbType.VarChar).Value = tbFnameUpdate.Text;
                command.Parameters.Add("@sName", SqlDbType.VarChar).Value = tbLnameUpdate.Text;
                command.Parameters.Add("@phoneNum", SqlDbType.VarChar).Value = tbPhoneUpdate.Text;
                command.Parameters.Add("@clientId", SqlDbType.Int).Value = tbIdUpdate.Text;

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Update successful!");
                }
                else
                {
                    MessageBox.Show("No records updated. Client ID not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();

                string del = "DELETE from Clients WHERE ClientId = @clientId";
                command.Parameters.Add("@clientId", SqlDbType.VarChar).Value = tbIdRemove.Text;

                command = new SqlCommand(del, conn);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Delete successful!");
                }
                else
                {
                    MessageBox.Show("No records deleted. Client ID not found.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProjectAdd_Click(object sender, EventArgs e)
        {
            var random2 = new Random();
            projectId = random2.Next(1001, 2000);
            clientID = Convert.ToInt32(tbClientIdAdd.Text);
            phaseId = Convert.ToInt32(tbPhaseIdAdd.Text);
            scheduleId = Convert.ToInt32(tbScheduleIdAdd.Text);
            assignmentId = Convert.ToInt32(tbAssignmentAddId.Text);
            projectDesctription = tbProjectDesc.Text;

            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();
                command = new SqlCommand("Insert into Projects Values(" + projectId + ", ' " + clientID + "', " +
                    "" + phaseId + "', '" + scheduleId + "', '" + assignmentId + "' , '" + projectDesctription + "') ", conn);

                adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Add Successful");

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProjectRemove_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();

                string del = "DELETE from Projects WHERE ProjectID = @id";
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = tbProjectIdRemove.Text;

                command = new SqlCommand(del, conn);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Delete successful!");
                }
                else
                {
                    MessageBox.Show("No records deleted. Project ID not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProjectUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();

                string updateQuery = "UPDATE Projects SET ClientId = @cId, PhaseId = @pId, ScheduleId = @sId, " +
                    "AssignmentId = @aId, ProjectDescription = @desc " +
                                     "WHERE Projects = @projectId";

                command = new SqlCommand(updateQuery, conn);

                command.Parameters.Add("@cId", SqlDbType.Int).Value = Convert.ToInt32(tbClientIdAdd.Text);
                command.Parameters.Add("@pId", SqlDbType.Int).Value = Convert.ToInt32(tbPhaseIdUpdate.Text);
                command.Parameters.Add("@sId", SqlDbType.Int).Value = Convert.ToInt32(tbScheduleUpdate.Text);
                command.Parameters.Add("@aId", SqlDbType.Int).Value = Convert.ToInt32(tbAssignemntUpdate.Text);
                command.Parameters.Add("@desc", SqlDbType.VarChar).Value = tbProjectDescUpdate.Text;
                command.Parameters.Add("@projectId", SqlDbType.Int).Value = Convert.ToInt32(tbProjectIdUpdate.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Update successful!");
                }
                else
                {
                    MessageBox.Show("No records updated. Project ID not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveProjectAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();

                string del = "DELETE from ProjectAssignments WHERE AssignmentId = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(tbAssignmentDel.Text);

                command = new SqlCommand(del, conn);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Delete successful!");
                }
                else
                {
                    MessageBox.Show("No records deleted. Assignment ID not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProjectAssignment_Click(object sender, EventArgs e)
        {
            var random2 = new Random();
            assignmentId = random2.Next(1001, 2000);
            roleId = Convert.ToInt32(tbRoleID.Text);
            empId = Convert.ToInt32(tbEmpId.Text);
            projectId = Convert.ToInt32(tbProjId.Text);

            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security=True");
                conn.Open();
                command = new SqlCommand("Insert into ProjectAssignments Values(" + assignmentId + ", ' " + roleId + "', '" + empId + "', '" + projectId +"') ", conn);

                adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Add Successful");

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login back = new Login();
            back.ShowDialog();
        }
    }
}
