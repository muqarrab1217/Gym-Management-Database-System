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

namespace Admin_Interface.Resources
{
    public partial class GYMOWNER_trainerInfo : Form
    {
        int ownerid;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public GYMOWNER_trainerInfo()
        {
            InitializeComponent();
            ownerid = Program.loginID; // Assuming Program.loginID contains the logged-in owner's ID
            LoadTrainerData();
        }

        private void LoadTrainerData()
        {
            DataTable trainerDataTable = new DataTable();

            trainerDataTable.Columns.Add("TrainerID", typeof(int));
            trainerDataTable.Columns.Add("GymID", typeof(int));
            trainerDataTable.Columns.Add("GymName", typeof(string));
            trainerDataTable.Columns.Add("Experience", typeof(int));
            trainerDataTable.Columns.Add("Acc_status", typeof(string));

                string query = @"SELECT T.TrainerID, T.GymID, G.GymName, T.Experience, T.Acc_status
                                FROM Trainer T
                                JOIN Gym G ON T.GymID = G.GymID
                                JOIN Form F ON F.UserID = T.TrainerID
                                JOIN Registration R ON R.FormID = F.FormID
                                WHERE G.OwnerID = @ownerid AND R.Status = 'Approved'";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ownerid", ownerid);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Populate the DataTable with trainer data
                while (reader.Read())
                {
                    trainerDataTable.Rows.Add(reader["TrainerID"], reader["GymID"], reader["GymName"], reader["Experience"], reader["Acc_status"]);
                }

                conn.Close();

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = trainerDataTable;
            foreach (DataRow row in trainerDataTable.Rows)
            {
                comboBox1.Items.Add(row["TrainerID"]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if needed
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Handle paint event if needed
        }

        private void trainer_info_Load(object sender, EventArgs e)
        {
            // Add any additional initialization code here
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
            // Delete from Trainer table
            string trainerQuery = "DELETE FROM Trainer WHERE TrainerID = @trainerID";
            SqlCommand trainerCommand = new SqlCommand(trainerQuery, conn);
            trainerCommand.Parameters.AddWithValue("@trainerID", trainerID);

            // Delete from Users table
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

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN_createAccount acc = new LOGIN_createAccount();
            acc.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
