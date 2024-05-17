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
    public partial class TRAINER_updateGym : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public TRAINER_updateGym()
        {
            InitializeComponent();
        }

        private void TRAINER_updateGym_Load(object sender, EventArgs e)
        {

            fillcomboGym();
        }

        private void DisplayLocationForGym(string GymID)
        {
            try
            {
                conn.Open();
                string query = @"select g.GymName, g.City, g.Street
                                 from Gym g
                                 where g.GymID=@id ";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", GymID);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string GymName = reader["GymName"].ToString();
                    string city = reader["City"].ToString();
                    string street = reader["Street"].ToString();
                    label1.Text = GymName;
                    label3.Text = city + ", " + street;
                }
                else
                {
                    label1.Text = "Location not found";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading location: " + ex.Message);
            }
        }

        private void fillcomboGym()
        {
            gym.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT GymID FROM gym";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                gym.Items.Add(dr["GymID"].ToString());
            }

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();

                string updateQuery = @"UPDATE Trainer SET GymID = @newGymID WHERE TrainerID = @memberID";
                SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
                updateCommand.Parameters.AddWithValue("@newGymID", Convert.ToInt32(gym.SelectedItem));
                updateCommand.Parameters.AddWithValue("@memberID", Program.loginID);
                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("GymID updated successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update GymID.");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating GymID: " + ex.Message);
            }
        }

        private void gym_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gym.SelectedItem != null)
            {
                string GymID = gym.SelectedItem.ToString();
                DisplayLocationForGym(GymID);
            }
        }
    }
}
