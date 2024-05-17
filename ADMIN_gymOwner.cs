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
    public partial class ADMIN_gymOwner : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public ADMIN_gymOwner()
        {
            InitializeComponent();
        }

        private void gym_Load(object sender, EventArgs e)
        {
            fillcomboGym();
            LoadGymData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN_createAccount form = new LOGIN_createAccount();
            form.Show();
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

        private void DeleteGymOwner(int ownerID)
        {
            // Step 2.1: Update related tables
            UpdateRelatedTables(ownerID);

            // Step 2.2: Delete Gym Owner
            string deleteQuery = "DELETE FROM Gym_Owner WHERE OwnerID = @ownerID";
            
                conn.Open();
                using (SqlCommand command = new SqlCommand(deleteQuery, conn))
                {
                    command.Parameters.AddWithValue("@ownerID", ownerID);
                    command.ExecuteNonQuery();
                }
            conn.Close();
            
        }

        private void UpdateRelatedTables(int ownerID)
        {
            UpdateForeignKeyToNull("Gym", "OwnerID", ownerID);
            //UpdateForeignKeyToNull("Performance", "AdminID", ownerID);
            //UpdateForeignKeyToNull("Registration", "AdminID", ownerID);
            UpdateForeignKeyToNull("Report", "OwnerID", ownerID);
        }

        private void UpdateForeignKeyToNull(string tableName, string columnName, int ownerID)
        {
            string updateQuery = $"UPDATE {tableName} SET {columnName} = NULL WHERE {columnName} = @ownerID";
            
                conn.Open();
                using (SqlCommand command = new SqlCommand(updateQuery, conn))
                {
                    command.Parameters.AddWithValue("@ownerID", ownerID);
                    command.ExecuteNonQuery();
                }
            conn.Close();


        }

      



        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int ownerIDToDelete = Convert.ToInt32(comboBox1.SelectedItem);
                DeleteGymOwner(ownerIDToDelete);
                MessageBox.Show("Gym Owner deleted successfully.");
                LoadGymData();
            }
            else
            {
                MessageBox.Show("Please select a Gym Owner to delete.");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadGymData()
        {
            DataTable gymDataTable = new DataTable();

            gymDataTable.Columns.Add("OwnerID", typeof(int));
            gymDataTable.Columns.Add("Username", typeof(string));
            gymDataTable.Columns.Add("Email", typeof(string));
            gymDataTable.Columns.Add("Contact", typeof(string));
            gymDataTable.Columns.Add("Gender", typeof(string));
            gymDataTable.Columns.Add("TotalGyms", typeof(int));

            string query = @"SELECT g.OwnerID, u.Username, u.Email, u.Contact, u.Gender, 
                            (SELECT COUNT(gs.GymID) FROM Gym gs WHERE gs.OwnerID = g.OwnerID) AS TotalGyms
                     FROM Gym_Owner g
                     INNER JOIN Users u ON g.OwnerID = u.UserID";

            SqlCommand command = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gymDataTable.Rows.Add(reader["OwnerID"], reader["Username"], reader["Email"], reader["Contact"], reader["Gender"], reader["TotalGyms"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading gym data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            dataGridView1.DataSource = gymDataTable;

            // Set column widths
            dataGridView1.Columns[0].Width = 60;
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 150;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Program.loginID = Convert.ToInt32(comboBox1.SelectedItem);
            GYMOWNER_Gymform form = new GYMOWNER_Gymform();
            form.Show();
        }

        private void fillcomboGym()
        {
            comboBox1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT OwnerID " +
                              "FROM Gym_Owner";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["OwnerID"].ToString());
            }

            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void SearchGymOwner(string searchWord)
        {
            dataGridView1.DataSource = null;

            string baseQuery = @"SELECT g.OwnerID, u.Username, u.Email, u.Contact, u.Gender, 
                                (SELECT COUNT(gs.GymID) FROM Gym gs WHERE gs.OwnerID = g.OwnerID) AS [Total Gyms]
                         FROM Gym_Owner g
                         INNER JOIN Users u ON g.OwnerID = u.UserID";

            List<string> searchColumns = new List<string> { "g.OwnerID", "u.Username", "u.Email", "u.Contact", "u.Gender" };
            string whereClause = string.Join(" OR ", searchColumns.Select(col => $"({col} LIKE @searchWord)"));
            string query = $"{baseQuery} WHERE ({whereClause})";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchWord", "%" + searchWord + "%");
                        conn.Open();

                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }

                dataGridView1.Columns[0].Width = 60;
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].Width = 150;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }



        private void searchbox_TextChanged_1(object sender, EventArgs e)
        {
            string word = searchbox.Text.Trim();
            if (string.IsNullOrEmpty(word))
                LoadGymData();
            else 
                SearchGymOwner(word);
        }
    }
}
