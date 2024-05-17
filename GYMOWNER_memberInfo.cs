using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Admin_Interface.Resources
{
    public partial class GYMOWNER_memberInfo : Form
    {
        int ownerid;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public GYMOWNER_memberInfo()
        {
            InitializeComponent();
            ownerid = Program.loginID;
            LoadMemberData();
        }

        private void GYMOWNER_memberInfo_Load(object sender, EventArgs e)
        {
            // Add any additional initialization code here
        }

        private void LoadMemberData()
        {
            DataTable memberDataTable = new DataTable();

            memberDataTable.Columns.Add("MemberID", typeof(int));
            memberDataTable.Columns.Add("GymID", typeof(int));
            memberDataTable.Columns.Add("GymName", typeof(string));
            memberDataTable.Columns.Add("WorkoutID", typeof(int));
            memberDataTable.Columns.Add("DietID", typeof(int));
            memberDataTable.Columns.Add("Height", typeof(string));
            memberDataTable.Columns.Add("Weight", typeof(double));
            memberDataTable.Columns.Add("Goal", typeof(string));
            memberDataTable.Columns.Add("Membership_type", typeof(string));
            memberDataTable.Columns.Add("Account_status", typeof(string));

                string query = "SELECT M.MemberID, M.GymID,G.GymName, M.WorkoutID, M.DietID, M.Height, M.Weight, M.Goal, M.Membership_type, M.Account_status " +
                               "FROM Member M " +
                               "INNER JOIN Gym G ON M.GymID = G.GymID " +
                               "WHERE G.OwnerID = @ownerid ";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ownerid", ownerid);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    memberDataTable.Rows.Add(reader["MemberID"], reader["GymID"], reader["GymName"], reader["WorkoutID"], reader["DietID"], reader["Height"], reader["Weight"], reader["Goal"], reader["Membership_type"], reader["Account_status"]);
                }

                conn.Close();

            dataGridView1.DataSource = memberDataTable;
            foreach (DataRow row in memberDataTable.Rows)
            {
                comboBox1.Items.Add(row["MemberID"]);
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle combo box selection if needed
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Handle button click event if needed
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if needed
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (searchText == string.Empty)
            {
                // If the textbox is empty, do nothing
                dataGridView1.DataSource = null;
                return;
            }

            // Check if the input is a number (GymID)
            if (int.TryParse(searchText, out int gymID))
            {
                ShowMembersByGymID(gymID);
                return;
            }

            // Check if the input is a valid height
            if (IsValidHeight(searchText))
            {
                ShowMembersByHeight(searchText);
                return;
            }

            // Check if the input is a valid goal
            if (IsValidGoal(searchText))
            {
                ShowMembersByGoal(searchText);
                return;
            }

            // Check if the input is a valid membership type
            if (IsValidMembershipType(searchText))
            {
                ShowMembersByMembershipType(searchText);
                return;
            }

            // Invalid input, show error message or handle as needed
            //MessageBox.Show("Invalid input. Please enter a valid GymID, Height, Weight, Goal, or Membership Type.");
        }


        private void ShowMembersByGymID(int gymID)
        {
            DataTable membersDataTable = new DataTable();

                string query = @"SELECT * FROM Member  INNER JOIN Gym G ON Member.GymID = G.GymID  WHERE G.GYMID = @gymid AND G.OwnerID = @ownerid";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@gymID", gymID);
                command.Parameters.AddWithValue("@ownerid", ownerid);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                membersDataTable.Load(reader);

                conn.Close();

            dataGridView1.DataSource = membersDataTable;
        }

        private bool IsValidHeight(string height)
        {
            if (Regex.IsMatch(height, @"^\d+'\d+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ShowMembersByHeight(string height)
        {
            DataTable membersDataTable = new DataTable();

                string query = @"SELECT M.* FROM Member M 
                        INNER JOIN Gym G ON M.GymID = G.GymID  
                        WHERE M.Height = @height AND G.OwnerID = @ownerid";


                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@height", height);
                command.Parameters.AddWithValue("@ownerid", ownerid);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                membersDataTable.Load(reader);

                conn.Close();

            dataGridView1.DataSource = membersDataTable;
        }

        private bool IsValidGoal(string goal)
        {
            List<string> validGoals = new List<string> { "Cutting", "Weight loss", "Bulking" };
            return validGoals.Contains(goal);
        }

        private void ShowMembersByGoal(string goal)
        {
            DataTable membersDataTable = new DataTable();

                string query = @"SELECT M.* FROM Member M 
                        INNER JOIN Gym G ON M.GymID = G.GymID  
                        WHERE M.Goal = @goal AND G.OwnerID = @ownerid";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@goal", goal);
                command.Parameters.AddWithValue("@ownerid", ownerid);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                membersDataTable.Load(reader);

                conn.Close();

            dataGridView1.DataSource = membersDataTable;
        }
        private bool IsValidMembershipType(string membershipType)
        {
            List<string> validMembershipTypes = new List<string> { "Standard", "Premium", "Gold" };
            return validMembershipTypes.Contains(membershipType);
        }

        private void ShowMembersByMembershipType(string membershipType)
        {
            DataTable membersDataTable = new DataTable();

                string query = @"SELECT M.* FROM Member M 
                        INNER JOIN Gym G ON M.GymID = G.GymID  
                        WHERE M.Membership_type = @membershipType AND G.OwnerID = @ownerid";


                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@membershipType", membershipType);
                command.Parameters.AddWithValue("@ownerid", ownerid);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                membersDataTable.Load(reader);

                conn.Close();

            dataGridView1.DataSource = membersDataTable;


        }

        private void UpdateAppointmentMemberID(int memberID)
        {
                string query = "UPDATE Appointment SET MemberID = NULL WHERE MemberID = @memberID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@memberID", memberID);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
        }

        private void UpdateFeedbackMemberID(int memberID)
        {
                string query = "UPDATE Feedback SET MemberID = NULL WHERE MemberID = @memberID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@memberID", memberID);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
        }

        private void UpdateMemberAllergiesMemberID(int memberID)
        {
                string query = "UPDATE Member_Allergies SET MemberID = NULL WHERE MemberID = @memberID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@memberID", memberID);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
        }

        private void UpdateMemberReportMemberID(int memberID)
        {
                string query = "UPDATE Member_Report SET MemberID = NULL WHERE MemberID = @memberID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@memberID", memberID);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
        }

        private void DeleteMember(int memberID)
        {
                string memberQuery = "DELETE FROM Member WHERE MemberID = @memberID";
                SqlCommand memberCommand = new SqlCommand(memberQuery, conn);
                memberCommand.Parameters.AddWithValue("@memberID", memberID);

                string userQuery = "DELETE FROM Users WHERE UserID = @memberID";
                SqlCommand userCommand = new SqlCommand(userQuery, conn);
                userCommand.Parameters.AddWithValue("@memberID", memberID);

                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    memberCommand.Transaction = transaction;
                    memberCommand.ExecuteNonQuery();

                    userCommand.Transaction = transaction;
                    userCommand.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error deleting member: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
        }


        private void UpdateWorkoutPlanCreatorID(int memberID)
        {
                string query = "UPDATE WorkoutPlan SET CreatorID = NULL WHERE CreatorID = @memberID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@memberID", memberID);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int memberIDToDelete = Convert.ToInt32(comboBox1.SelectedItem);

                UpdateAppointmentMemberID(memberIDToDelete);
                UpdateFeedbackMemberID(memberIDToDelete);
                UpdateMemberAllergiesMemberID(memberIDToDelete);
                UpdateMemberReportMemberID(memberIDToDelete);
                UpdateWorkoutPlanCreatorID(memberIDToDelete);
                DeleteMember(memberIDToDelete);

                LoadMemberData();
            }
            else
            {
                MessageBox.Show("Please select a MemberID to delete.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LOGIN_createAccount acc = new LOGIN_createAccount();
            acc.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
