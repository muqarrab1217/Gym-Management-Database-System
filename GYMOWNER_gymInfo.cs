using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Admin_Interface.Resources
{
    public partial class GYMOWNER_gymInfo : Form
    {
        int ownerid;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public GYMOWNER_gymInfo()
        {
            InitializeComponent();
        }

        private void GYMOWNER_gymInfo_Load(object sender, EventArgs e)
        {
            ownerid = Program.loginID;
            LoadGymData();
        }

        private void LoadGymData()
        {
            DataTable gymDataTable = new DataTable();
            gymDataTable.Columns.Add("GymID", typeof(int));
            gymDataTable.Columns.Add("GymName", typeof(string));
            gymDataTable.Columns.Add("OwnerID", typeof(int));
            gymDataTable.Columns.Add("City", typeof(string));
            gymDataTable.Columns.Add("Street", typeof(string));
            Console.WriteLine("OwnerID: " + ownerid);

                string query = "SELECT GymID, GymName, OwnerID, City, Street FROM Gym WHERE OwnerID = @ownerid AND Gym_Status = 'Approved'";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ownerid", ownerid);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gymDataTable.Rows.Add(reader["GymID"], reader["GymName"], reader["OwnerID"], reader["City"], reader["Street"]);
                }

                conn.Close();

            dataGridView1.DataSource = gymDataTable;

            foreach (DataRow row in gymDataTable.Rows)
            {
                comboBox1.Items.Add(row["GymID"]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void UpdateMemberGymID(int gymID)
        {
                string query = "UPDATE Member SET GymID = NULL WHERE GymID = @gymID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@gymID", gymID);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
        }

        private void UpdateTrainerGymID(int gymID)
        {
                string query = "UPDATE Trainer SET GymID = NULL WHERE GymID = @gymID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@gymID", gymID);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
        }

        private void UpdatePerformanceGymID(int gymID)
        {
                string query = "UPDATE Performance SET GymID = NULL WHERE GymID = @gymID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@gymID", gymID);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
        }

        private void DeleteGym(int gymID)
        {
                string query = "DELETE FROM Gym WHERE GymID = @gymID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@gymID", gymID);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int gymIDToDelete = Convert.ToInt32(comboBox1.SelectedItem);

                UpdateMemberGymID(gymIDToDelete);
                UpdateTrainerGymID(gymIDToDelete);
                UpdatePerformanceGymID(gymIDToDelete);
                DeleteGym(gymIDToDelete);
                LoadGymData();
            }
            else
            {
                MessageBox.Show("Please select a GymID to delete.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LOGIN_gymownerregister form = new LOGIN_gymownerregister();
            form.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
