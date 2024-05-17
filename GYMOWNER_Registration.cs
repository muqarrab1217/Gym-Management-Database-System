using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Admin_Interface
{
    public partial class GYMOWNER_Registration : Form
    {
        int ownerid;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public GYMOWNER_Registration()
        {
            InitializeComponent();
            ownerid = Program.loginID;
            LoadTrainerRegistrations();
        }

        private void LoadTrainerRegistrations()
        {
            DataTable trainerRegistrationDataTable = new DataTable();

            trainerRegistrationDataTable.Columns.Add("RegistrationID", typeof(int));
            trainerRegistrationDataTable.Columns.Add("TrainerID", typeof(int));
            trainerRegistrationDataTable.Columns.Add("GymID", typeof(int));
            trainerRegistrationDataTable.Columns.Add("Status", typeof(string));

                string query = @"SELECT R.RegistrationID, T.TrainerID ,T.GymID, R.Status 
                                FROM Registration R 
                                INNER JOIN Form F ON R.FormID = F.FormID 
                                INNER JOIN Trainer T ON F.UserID = T.TrainerID 
                                WHERE T.GymID IN (SELECT GymID FROM Gym WHERE OwnerID = @ownerid)";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ownerid", ownerid);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trainerRegistrationDataTable.Rows.Add(reader["RegistrationID"], reader["TrainerID"], reader["GymID"], reader["Status"]);
                }

                conn.Close();
            dataGridView2.DataSource = trainerRegistrationDataTable;

            foreach (DataRow row in trainerRegistrationDataTable.Rows)
            {
                comboBox1.Items.Add(row["RegistrationID"]);
            }
        }

        private void UpdateStatusToAdded(int registrationID)
        {
                conn.Open();

                string query = "UPDATE Registration SET Status = 'Approved' WHERE RegistrationID = @registrationID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@registrationID", registrationID);
                command.ExecuteNonQuery();

                conn.Close();

                LoadTrainerRegistrations();
        }

        private void UpdateStatusToRejected(int registrationID)
        {
                conn.Open();

                string query = "UPDATE Registration SET Status = 'Rejected' WHERE RegistrationID = @registrationID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@registrationID", registrationID);
                command.ExecuteNonQuery();

                conn.Close();

                LoadTrainerRegistrations();
        }

        private void ShowRequestsByStatus(string status)
        {
            DataTable requestsDataTable = new DataTable();

                string query = @"SELECT R.RegistrationID, T.TrainerID, T.GymID, R.Status 
                         FROM Registration R 
                         INNER JOIN Form F ON R.FormID = F.FormID 
                         INNER JOIN Trainer T ON F.UserID = T.TrainerID 
                         WHERE R.Status = @status AND T.GymID IN (SELECT GymID FROM Gym WHERE OwnerID = @ownerid)";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@ownerid", ownerid);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                requestsDataTable.Load(reader);

                conn.Close();

            dataGridView2.DataSource = requestsDataTable;
        }

        private void ShowRequestsForGym(int gymID)
        {
            DataTable requestsDataTable = new DataTable();

                string query = @"SELECT R.RegistrationID, T.TrainerID, T.GymID, A.GymName,R.Status 
                         FROM Registration R 
                         INNER JOIN Form F ON R.FormID = F.FormID 
                         INNER JOIN Trainer T ON F.UserID = T.TrainerID
                         INNER JOIN GYM A on T.GymID = A.GymID
                         WHERE T.GymID = @gymID AND T.GymID IN (SELECT GymID FROM Gym WHERE OwnerID = @ownerid)";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@gymID", gymID);
                command.Parameters.AddWithValue("@ownerid", ownerid);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                requestsDataTable.Load(reader);

                conn.Close();

            dataGridView2.DataSource = requestsDataTable;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (searchText == string.Empty)
            {
                dataGridView2.DataSource = null;
                return;
            }

            if (int.TryParse(searchText, out int gymID))
            {
                ShowRequestsForGym(gymID);
                return;
            }

            string status = searchText.ToLower();
            if (status == "approved" || status == "rejected" || status == "pending")
            {
                ShowRequestsByStatus(status);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int selectedRegistrationID = (int)comboBox1.SelectedItem;

                UpdateStatusToAdded(selectedRegistrationID);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int selectedRegistrationID = (int)comboBox1.SelectedItem;

                UpdateStatusToRejected(selectedRegistrationID);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
