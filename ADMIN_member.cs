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

namespace Admin_Interface
{
    public partial class ADMIN_member : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public ADMIN_member()
        {
            InitializeComponent();
        }

        private void member_Load(object sender, EventArgs e)
        {
            fillcomboMember();
            LoadMemberData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadMemberData()
        {
            DataTable memberDataTable = new DataTable();

            memberDataTable.Columns.Add("ID", typeof(int));
            memberDataTable.Columns.Add("Name", typeof(string));
            memberDataTable.Columns.Add("Height", typeof(string));
            memberDataTable.Columns.Add("Weight", typeof(int));
            memberDataTable.Columns.Add("Goal", typeof(string));
            memberDataTable.Columns.Add("Gym Name", typeof(string));
            memberDataTable.Columns.Add("Workout Plan", typeof(string));
            memberDataTable.Columns.Add("Diet Plan", typeof(string));
            memberDataTable.Columns.Add("Membership_type", typeof(string));
            memberDataTable.Columns.Add("Account_status", typeof(string));

            string query = "SELECT m.memberID, u.Username, m.Height, m.Weight, m.Goal, g.Gymname, w.Name AS workout, d.Type AS diet, m.Membership_type, m.Account_status " +
               "FROM Member m " +
               "INNER JOIN Users u ON m.MemberID = u.UserID " +
               "LEFT OUTER JOIN Gym g ON m.GymID = g.GymID " +
               "LEFT OUTER JOIN WorkoutPlan w ON m.WorkoutID = w.WorkoutID " +
               "LEFT OUTER JOIN DietPlan d ON m.DietID = d.DietID";


            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                memberDataTable.Rows.Add(reader["memberID"], reader["Username"], reader["Height"], reader["Weight"], reader["Goal"], reader["Gymname"], reader["workout"], reader["diet"], reader["Membership_type"], reader["Account_status"]);
            }

            conn.Close();
            dataGridView1.DataSource = memberDataTable;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.loginID = Convert.ToInt32(comboBox1.SelectedItem);
            MEMBER_memberForm Form = new MEMBER_memberForm();
            Form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN_createAccount form = new LOGIN_createAccount();
            form.Show();
        }

        private void fillcomboMember()
        {
            comboBox1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT MemberID " +
                              "FROM Member";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["MemberID"].ToString());
            }

            conn.Close();
        }


        private void SearchfromMember(string searchWord)
        {
            dataGridView1.DataSource = null;

            string baseQuery = "SELECT m.memberID, u.Username, m.Height, m.Weight, m.Goal, g.Gymname, w.Name AS workout, d.Type AS diet, m.Membership_type, m.Account_status " +
                "FROM Member m " +
                "INNER JOIN Users u ON m.MemberID = u.UserID " +
                "LEFT OUTER JOIN Gym g ON m.GymID = g.GymID " +
                "LEFT OUTER JOIN WorkoutPlan w ON m.WorkoutID = w.WorkoutID " +
                "LEFT OUTER JOIN DietPlan d ON m.DietID = d.DietID";


            List<string> searchColumns = new List<string> { "m.memberID", "u.username", "m.height", "m.weight", "m.Goal", "g.Gymname", "w.Name", "d.Type", "m.Membership_type", "m.Account_status" };
            string whereClause = string.Join(" OR ", searchColumns.Select(col => $"{col} LIKE @searchWord"));
            string query = $"{baseQuery} WHERE {whereClause}";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@searchWord", searchWord + "%");
                conn.Open();

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string word = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(word))
                LoadMemberData();
            else
                SearchfromMember(word);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            // Delete from Member table
            string memberQuery = "DELETE FROM Member WHERE MemberID = @memberID";
            SqlCommand memberCommand = new SqlCommand(memberQuery, conn);
            memberCommand.Parameters.AddWithValue("@memberID", memberID);

            // Delete from Users table
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


        private void button3_Click(object sender, EventArgs e)
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
    }
}
