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
    public partial class ADMIN_registrations : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public ADMIN_registrations()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {
            fillcomboGym();
            loadRegistration();
        }

        private void loadRegistration()
        {
            DataTable trainerDataTable = new DataTable();

            trainerDataTable.Columns.Add("Owner ID", typeof(int));
            trainerDataTable.Columns.Add("Gym Owner", typeof(string));
            trainerDataTable.Columns.Add("Gym ID", typeof(int));
            trainerDataTable.Columns.Add("Gym Name", typeof(string));
            trainerDataTable.Columns.Add("Gym Status", typeof(string));

            string query = "SELECT u.UserID, u.Username, g.GymID, g.GymName, g.Gym_status " +
                           "FROM Gym g " +
                           "LEFT OUTER JOIN Users u ON g.OwnerID = u.UserID " +
                           "WHERE g.gym_status = 'Under Review'";


            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                trainerDataTable.Rows.Add(reader["UserID"], reader["Username"], reader["GymID"], reader["GymName"], reader["Gym_status"]);
            }

            conn.Close();

            dataGridView1.DataSource = trainerDataTable;

            dataGridView1.Columns[0].Width = 180;
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 200;
            }
        }


        private void searchfromRegistration(string searchWord)
        {
            dataGridView1.DataSource = null;

            string baseQuery = "SELECT u.UserID, u.Username, g.GymID, g.GymName, g.Gym_status " +
                               "FROM Gym g " + 
                               "LEFT OUTER JOIN Users u ON g.OwnerID = u.UserID " + 
                               "WHERE g.gym_status = 'Under Review' "; 

            List<string> searchColumns = new List<string> { "u.UserID", "u.Username", "g.GymID", "g.GymName", "g.Gym_status" };
            string whereClause = string.Join(" OR ", searchColumns.Select(col => $"({col} LIKE @searchWord)"));
            string query = $"{baseQuery} AND ({whereClause})"; 
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
            dataGridView1.Columns[0].Width = 100;
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 200;
            }
        }


        private void fillcomboGym()
        {
            comboBox1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT gymid FROM gym where gym_status='Under Review'";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Gymid"].ToString());
            }

            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string word = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(word))
                loadRegistration();
            else
                searchfromRegistration(word);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int id = Convert.ToInt32(comboBox1.SelectedItem);

                string updateQuery = "UPDATE Registration " +
                                     "SET status = 'Approved' " +
                                     "WHERE FormID IN (SELECT FormID " +
                                                      "FROM Form " +
                                                      "WHERE UserID = " + id + ")";

                SqlCommand up = new SqlCommand(updateQuery, conn);

                conn.Open();
                up.ExecuteNonQuery();
                conn.Close();

                string updateQuery2 = "UPDATE Gym " +
                                      "SET gym_status = 'Approved' " +
                                      "WHERE GymID = " + id;

                SqlCommand up2 = new SqlCommand(updateQuery2, conn);

                conn.Open();
                up2.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please select a user from the ComboBox.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int id = Convert.ToInt32(comboBox1.SelectedItem);

                string updateQuery = "UPDATE Registration " +
                                     "SET status = 'Rejected' " +
                                     "WHERE FormID IN (SELECT FormID " +
                                                      "FROM Form " +
                                                      "WHERE UserID = " + id + ")";

                SqlCommand up = new SqlCommand(updateQuery, conn);

                conn.Open();
                up.ExecuteNonQuery();
                conn.Close();

                string updateQuery2 = "UPDATE Gym " +
                                      "SET gym_status = 'Rejected' " +
                                      "WHERE GymID = " + id;

                SqlCommand up2 = new SqlCommand(updateQuery2, conn);

                conn.Open();
                up2.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please select a user from the ComboBox.");
            }
        }
    }
}
