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
using System.Configuration;

namespace Admin_Interface
{
    public partial class ADMIN_dashboard : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public ADMIN_dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            fillChart();
            fillPieChart();
            displayStatistics();
            loadImage();
            loadProfile();
        }
        public void fillPieChart()
        {
            DataTable dt = new DataTable();
            conn.Open();

            string sqlQuery = "select count(m.memberid) as member_s, count(distinct g.gymid) as gyms, count(distinct w.workoutid) as trainers from member m join gym g on m.gymid = g.gymid join workoutPlan w on m.workoutid = w.workoutid";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
            da.Fill(dt);
            chart2.DataSource = dt;
            conn.Close();

            chart2.Series["pieSeries"].Points.AddY(Convert.ToInt32(dt.Rows[0]["trainers"]));
            chart2.Series["pieSeries"].Points.AddY(Convert.ToInt32(dt.Rows[0]["member_s"]));
            chart2.Series["pieSeries"].Points.AddY(Convert.ToInt32(dt.Rows[0]["gyms"]));

        }

        public void fillChart()
        {
            try
            {
                DataTable dt = new DataTable();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select weight,weight/2 as height from member", conn);
                da.Fill(dt);
                chart1.DataSource = dt;
                conn.Close();

                chart1.Series["height"].XValueMember = "height";
                chart1.Series["height"].YValueMembers = "weight";

                chart1.Series["weight"].XValueMember = "height";
                chart1.Series["weight"].YValueMembers = "weight";

                chart1.Titles.Add("Height Increase");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public void displayStatistics()
        {

            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select memberid from member", conn);
            da.Fill(dt);
            conn.Close();

            label2.Text = dt.Rows.Count.ToString();
        }

        public void loadImage()
        {
            try
            {
                string query = "SELECT filepath FROM users WHERE UserID = @userID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", Program.masterloginID);

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
                cmd.Parameters.AddWithValue("@id", Program.masterloginID);

                conn.Open();
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                // Check if there are any rows returned
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }

        private void pieChart2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adName_Click(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }
    }
}
