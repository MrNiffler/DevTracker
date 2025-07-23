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
    public partial class FrmDeveloper : Form
    {
        //<<<<<<< HEAD
        private string conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Bethel\\Documents\\@NWU\\SECOND SEMESTER\\CMPG223\\final project\\cmpg223 project\\DevTrackerDB.mdf\";Integrated Security=True"; // Replace with your actual connection string
                                                                                                                                                                                                                                    //=======
                                                                                                                                                                                                                                    // private string conStr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Bethel\Documents\@NWU\SECOND SEMESTER\CMPG223\final project\cmpg223 project\DevTrackerDB.mdf"";Integrated Security = True"; 
                                                                                                                                                                                                                                    //>>>>>>> 7a7bea8e3e5e09a638ff8e69f4f566a9ce4322a9
        SqlConnection conn;
        SqlDataReader reader;
        SqlCommand cmd;

        public FrmDeveloper()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int phaseIdToUpdate;

            // Try to parse the Phase ID from the textbox
            if (!int.TryParse(tbProjectDateToUpdate.Text, out phaseIdToUpdate))
            {
                MessageBox.Show("Invalid Phase ID. Please enter a valid Phase ID.");
                return;
            }

            DateTime startDate = dtmStart.Value;
            DateTime dueDate = dtmDue.Value;

            // Ask for confirmation before updating
            DialogResult result = MessageBox.Show($"Are you sure you want to update dates for Phase ID {phaseIdToUpdate}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // User canceled the update
            }

            try
            {
                conn = new SqlConnection(conStr);
                conn.Open();

                // Define the SQL update query
                string updateQuery = "UPDATE PROJECTSCHEDULES SET ScheduleStartDate = @StartDate, " +
                    "ScheduleDueDate = @DueDate " +
                                     "WHERE PhaseID = @PhaseID";

                cmd = new SqlCommand(updateQuery, conn);

                // Add parameters to the SQL query
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;
                cmd.Parameters.Add("@PhaseID", SqlDbType.Int).Value = phaseIdToUpdate;

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Update successful!");
                }
                else
                {
                    MessageBox.Show("No records updated. Phase ID not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Close the current FrmDeveloper form
            this.Close();
            // Show the Login form
            Login loginForm = new Login();
            loginForm.Show();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            {
                int loggedInEmployeeID = Login.LoggedInEmployeeID;
                int currentMonth = DateTime.Now.Month;

                try
                {
                    conn = new SqlConnection(conStr);
                    conn.Open();

                    string reportQuery = "SELECT P.ProjectID, P.ProjectDescription, C.ClientCompanyName, " +
                                         "PH.PhaseName, PS.ScheduleStartDate, PS.ScheduleDueDate " +
                                         "FROM PROJECTS P " +
                                         "INNER JOIN CLIENTS C ON P.ClientID = C.ClientID " +
                                         "INNER JOIN PROJECTSCHEDULES PS ON P.ScheduleID = PS.ScheduleID " +
                                         "INNER JOIN PHASES PH ON P.PhaseID = PH.PhaseID " +
                                         "INNER JOIN PROJECTASSIGNMENTS PA ON P.AssignmentID = PA.AssignmentID " +
                                         "WHERE MONTH(PS.ScheduleDueDate) = @CurrentMonth " +
                                         "AND PA.EmployeeID = @EmployeeID";

                    cmd = new SqlCommand(reportQuery, conn);
                    cmd.Parameters.AddWithValue("@CurrentMonth", currentMonth);
                    cmd.Parameters.AddWithValue("@EmployeeID", loggedInEmployeeID);
                    reader = cmd.ExecuteReader();

                    rtbReport.Clear();
                    rtbReport.AppendText($"UPCOMING PROJECTS FOR Employee: {loggedInEmployeeID}\n");
                    rtbReport.AppendText("----------------------------------------------------------------\n");
                    rtbReport.AppendText($"Dear {GetEmployeeName(loggedInEmployeeID)}, here is a list of your upcoming due projects for {DateTime.Now.ToString("MMMM")}:\n\n");

                    int projectCounter = 1;
                    while (reader.Read())
                    {
                        int projectID = reader.GetInt32(0);
                        string projectDescription = reader.GetString(1);
                        string clientCompanyName = reader.GetString(2);
                        string phaseName = reader.GetString(3);
                        DateTime startDate = reader.GetDateTime(4);
                        DateTime dueDate = reader.GetDateTime(5);

                        string projectInfo = $"{projectCounter}.) Project: {projectID}\n" +
                                             $"\t{projectDescription} for {clientCompanyName}.\n" +
                                             $"\tCurrently in phase {phaseName}.\n" +
                                             $"\tDate started: {startDate}.\n" +
                                             $"\tDate due: {dueDate}.\n\n";

                        rtbReport.AppendText(projectInfo);
                        projectCounter++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Close the SqlDataReader and SqlConnection in the finally block.
                    if (reader != null)
                    {
                        reader.Close();
                    }

                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private string GetEmployeeName(int employeeID)
        {
            try
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string query = "SELECT employeeFirstName, employeeLastName FROM " +
                    "EMPLOYEES WHERE employeeID = @EmployeeID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string firstName = reader.GetString(0);
                    string lastName = reader.GetString(1);
                    reader.Close(); // Close the SqlDataReader.
                    return $"{firstName} {lastName}";
                }

                reader.Close(); // Close the SqlDataReader.
                conn.Close(); // Close the SqlConnection.
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching the employee name: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "EmployeeNamePlaceholder";
        }
    }
                
            
           
        
    
}
    
