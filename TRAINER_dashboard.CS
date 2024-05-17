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
    public partial class TRAINER_dashboard : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public TRAINER_dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TRAINER_dashboard_Load(object sender, EventArgs e)
        {
            loadImage();
            loadProfile();
            DisplayLocationForTrainer(Program.loginID.ToString());
            fillPieChart();
            fillChart();
        }

        public void fillPieChart()
        {
            DataTable dt = new DataTable();
            conn.Open();

            string sqlQuery = @"SELECT COUNT(DISTINCT m.MemberID) AS member_s, COUNT(DISTINCT t.TrainerID) AS trainers
                                FROM Gym_Owner o
                                INNER JOIN Gym g ON o.OwnerID = g.OwnerID
                                LEFT JOIN Member m ON g.GymID = m.GymID
                                LEFT JOIN Trainer t ON g.GymID = t.GymID";

            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            da.Fill(dt);
            chart2.DataSource = dt;
            conn.Close();

            chart2.Series["pieSeries"].Points.AddY(Convert.ToInt32(dt.Rows[0]["trainers"]));
            chart2.Series["pieSeries"].Points.AddY(Convert.ToInt32(dt.Rows[0]["member_s"]));

        }

        public void fillChart()
        {
            try
            {
                DataTable dt = new DataTable();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select License_number, OwnerID from Gym_Owner", conn);
                da.Fill(dt);
                chart1.DataSource = dt;
                conn.Close();

                chart1.Series["appointments"].XValueMember = "License_number";
                chart1.Series["appointments"].YValueMembers = "OwnerID";

                chart1.Titles.Add("Growth Report");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public void loadProfile()
        {
            string query = "select username, email from Users where UserID = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", Program.loginID);

                conn.Open();
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    adName.Text = reader["username"].ToString();
                    admail.Text = reader["email"].ToString();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
                reader.Close();
                conn.Close();
            }
        }
        public void loadImage()
        {
            try
            {
                string query = "SELECT filepath FROM users WHERE UserID = @userID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", Program.loginID);

                string imagePath = string.Empty;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        imagePath = reader["filepath"].ToString();
                    }
                }

                if (!string.IsNullOrEmpty(imagePath))
                {
                    Image image = Image.FromFile(imagePath);
                    bunifuPictureBox1.Image = image;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void DisplayLocationForTrainer(string TrainerID)
        {
            try
            {
                conn.Open();
                string query = @"SELECT g.City, g.Street
                         FROM Gym g
                         INNER JOIN Trainer m ON g.GymID = m.GymID
                         WHERE m.TrainerID = @id";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", TrainerID);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string city = reader["City"].ToString();
                    string street = reader["Street"].ToString();
                    label10.Text = city + ", " + street;
                }
                else
                {
                    label10.Text = "Location not found";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading location: " + ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            TRAINER_updateGym updateGym = new TRAINER_updateGym();
            updateGym.Show();
            DisplayLocationForTrainer(Program.loginID.ToString());
        }
    }
}
