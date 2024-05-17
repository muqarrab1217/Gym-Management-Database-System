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
    public partial class GYMOWNER_dashboard : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public GYMOWNER_dashboard()
        {
            InitializeComponent();
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

            chart2.Series["pieSeries"].Points.AddY(Convert.ToInt32(dt.Rows[0]["member_s"]));
            chart2.Series["pieSeries"].Points.AddY(Convert.ToInt32(dt.Rows[0]["trainers"]));

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

                chart1.Series["Membership"].XValueMember = "License_number";
                chart1.Series["Membership"].YValueMembers = "OwnerID";

                chart1.Titles.Add("Growth Report");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void GYMOWNER_dashboard_Load(object sender, EventArgs e)
        {
            loadProfile();
            loadImage();
            fillChart();
            fillPieChart();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
