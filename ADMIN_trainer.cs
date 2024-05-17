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
    public partial class ADMIN_trainer : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public ADMIN_trainer()
        {
            InitializeComponent();
        }

        private void trainer_Load(object sender, EventArgs e)
        {
            fillcomboTrainer();
            LoadTrainerData();
            // TODO: This line of code loads data into the 'final_ProjectDataSet.Trainer' table. You can move, or remove it, as needed.
            this.trainerTableAdapter.Fill(this.final_ProjectDataSet.Trainer);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN_createAccount form = new LOGIN_createAccount();
            form.Show();
        }
        private void LoadTrainerData()
        {
            DataTable trainerDataTable = new DataTable();

            trainerDataTable.Columns.Add("ID", typeof(int));
            trainerDataTable.Columns.Add("Name", typeof(string));
            trainerDataTable.Columns.Add("Email", typeof(string));
            trainerDataTable.Columns.Add("Gender", typeof(string));
            trainerDataTable.Columns.Add("Gym Name", typeof(string));
            trainerDataTable.Columns.Add("Specialization", typeof(string));
            trainerDataTable.Columns.Add("Experience", typeof(int));
            trainerDataTable.Columns.Add("Acc_status", typeof(string));

                string query = "SELECT t.TrainerID, u.Username, u.Email, u.Gender, g.GymName, s.Specialization, t.Experience, t.Acc_status " +
                               "FROM trainer t " +
                               "INNER JOIN Users u ON t.TrainerID = u.UserID " +
                               "INNER JOIN Gym g ON t.GymID = g.GymID " +
                               "INNER JOIN Specialization s ON t.TrainerID = s.TrainerID";

                SqlCommand command = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trainerDataTable.Rows.Add(reader["TrainerID"], reader["Username"], reader["Email"], reader["Gender"], reader["GymName"], reader["Specialization"], reader["Experience"], reader["Acc_status"]);
                }

                conn.Close();

            dataGridView1.DataSource = trainerDataTable;
        }

        private void fillcomboTrainer()
        {
            comboBox1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TrainerID " +
                              "FROM Trainer";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["TrainerID"].ToString());
            }

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.loginID = Convert.ToInt32(comboBox1.SelectedItem);
            TRAINER_Form form = new TRAINER_Form();
            form.Show();
        }

        private void SearchfromTrainer(string searchWord)
        {
            dataGridView1.DataSource = null;

            string baseQuery = "SELECT t.TrainerID, u.Username, u.Email, u.Gender, g.GymName, s.Specialization, t.Experience, t.Acc_status " +
                               "FROM trainer t " +
                               "INNER JOIN Users u ON t.TrainerID = u.UserID " +
                               "INNER JOIN Gym g ON t.GymID = g.GymID " +
                               "INNER JOIN Specialization s ON t.TrainerID = s.TrainerID";

            List<string> searchColumns = new List<string> { "t.GymID", "u.username", "u.Email", "u.Gender", "g.GymName", "s.Specialization", "t.Experience", "t.Acc_status" };
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
            string word = textBox1.Text;
            if (string.IsNullOrEmpty(word))
                LoadTrainerData();
            else
                SearchfromTrainer(word);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateAppointmentTrainerID(int trainerID)
        {
            string query = "UPDATE Appointment SET TrainerID = NULL WHERE TrainerID = @trainerID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@trainerID", trainerID);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Appointment records: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateFeedbackTrainerID(int trainerID)
        {
            string query = "UPDATE Feedback SET TrainerID = NULL WHERE TrainerID = @trainerID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@trainerID", trainerID);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                //MessageBox.Show("Feedback records updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Feedback records: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateTrainerReportTrainerID(int trainerID)
        {
            string query = "UPDATE Trainer_Report SET TrainerID = NULL WHERE TrainerID = @trainerID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@trainerID", trainerID);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                //MessageBox.Show("Trainer_Report records updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Trainer_Report records: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateFormTrainerID(int trainerID)
        {
            string query = "UPDATE FORM SET UserID = NULL WHERE UserID = @trainerID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@trainerID", trainerID);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                //MessageBox.Show("Performance records updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Performance records: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateDietPlanTrainerID(int trainerID)
        {
            string query = "UPDATE DietPlan SET TrainerID = NULL WHERE TrainerID = @trainerID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@trainerID", trainerID);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                //MessageBox.Show("Diet plans updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating diet plans: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateSpecializationTrainerID(int trainerID)
        {
            string query = "UPDATE Specialization SET TrainerID = NULL WHERE TrainerID = @trainerID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@trainerID", trainerID);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                //MessageBox.Show("Specializations updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating specializations: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateWorkoutPlanCreatorID(int trainerID)
        {
            string query = "UPDATE WorkoutPlan SET CreatorID = NULL WHERE CreatorID = @trainerID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@trainerID", trainerID);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                //MessageBox.Show("Workout plans updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating workout plans: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void DeleteTrainer(int trainerID)
        {
            string trainerQuery = "DELETE FROM Trainer WHERE TrainerID = @trainerID";
            SqlCommand trainerCommand = new SqlCommand(trainerQuery, conn);
            trainerCommand.Parameters.AddWithValue("@trainerID", trainerID);

            string userQuery = "DELETE FROM Users WHERE UserID = @trainerID";
            SqlCommand userCommand = new SqlCommand(userQuery, conn);
            userCommand.Parameters.AddWithValue("@trainerID", trainerID);

            try
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                trainerCommand.Transaction = transaction;
                trainerCommand.ExecuteNonQuery();

                userCommand.Transaction = transaction;
                userCommand.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Trainer deleted successfully.");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error deleting trainer: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int trainerIDToDelete = Convert.ToInt32(comboBox1.SelectedItem);

                UpdateAppointmentTrainerID(trainerIDToDelete);
                UpdateFeedbackTrainerID(trainerIDToDelete);
                UpdateTrainerReportTrainerID(trainerIDToDelete);
                UpdateFormTrainerID(trainerIDToDelete);
                UpdateDietPlanTrainerID(trainerIDToDelete);
                UpdateSpecializationTrainerID(trainerIDToDelete);
                UpdateWorkoutPlanCreatorID(trainerIDToDelete);
                DeleteTrainer(trainerIDToDelete);

                LoadTrainerData();
            }
            else
            {
                MessageBox.Show("Please select a TrainerID to delete.");
            }
        }
    }
}
