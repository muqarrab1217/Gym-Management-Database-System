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
    public partial class TRAINER_Form : Form
    {
        bool sidebarExpand;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public TRAINER_Form()
        {
            InitializeComponent();
        }
        public void loadProfile()
        {
            string query = "select username from Users where UserID = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", Program.loginID);

                conn.Open();
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    adName.Text = reader["username"].ToString();
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

        public void loadForm(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            loadForm(new TRAINER_dashboard());
            loadImage();
            loadProfile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                //if sidebar is expanded, minimize
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }

            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void trainerButton_Click(object sender, EventArgs e)
        {
            loadForm(new TRAINER_Dietplan());
        }

        private void DashBoard_Click(object sender, EventArgs e)
        {
            loadForm(new TRAINER_dashboard());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new TRAINER_WorkoutPlan());
        }

        private void gymButton_Click(object sender, EventArgs e)
        {
            loadForm(new Appointment_Trainer_());
        }

        private void performanceButton_Click(object sender, EventArgs e)
        {
            
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadForm(new TRAINER_Feedback());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadForm(new TRAINER_Report());
        }
    }
}
