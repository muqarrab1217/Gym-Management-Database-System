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
    public partial class MEMBER_Feedback : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public MEMBER_Feedback()
        {
            InitializeComponent();
        }
        private void MEMBER_Feedback_Load(object sender, EventArgs e)
        {
            loadFeedBack();
            fillcomboGym();
        }
        private void fillcomboGym()
        {
            id.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TrainerID FROM Trainer";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                id.Items.Add(dr["TrainerID"].ToString());
            }

            conn.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gym_report_mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string get_FeedBackID = "(select max(feedbackID) + 1 from FeedBack)";
            string insertWorkoutQuery = "INSERT INTO FEEDBACK (FeedBackID, MemberID, TrainerID, Rating, Comment, Date)" +
                                 "VALUES (" + get_FeedBackID + ", @MemberID, @TrainerID, @Rating, @Comment, GETDATE())";

            SqlCommand cmd = new SqlCommand(insertWorkoutQuery, conn);
            cmd.Parameters.AddWithValue("@MemberID", Program.loginID);
            cmd.Parameters.AddWithValue("@TrainerID", id.Text);
            cmd.Parameters.AddWithValue("@Rating", rating.Text);
            cmd.Parameters.AddWithValue("@Comment", comments.Text);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void loadFeedBack()
        {
            DataTable gymDataTable1 = new DataTable();

            gymDataTable1.Columns.Add("Feedback ID", typeof(int));
            gymDataTable1.Columns.Add("Member", typeof(string));
            gymDataTable1.Columns.Add("Trainer", typeof(string));
            gymDataTable1.Columns.Add("Rating", typeof(string));
            gymDataTable1.Columns.Add("Comments", typeof(string));
            gymDataTable1.Columns.Add("Date", typeof(string));

            string insertQuery = @"select f.FeedbackID, u1.Username as Member, u2.Username as Trainer, f.Rating, f.Comment, f.Date
                               from Feedback f
                               join Users u1 on f.MemberID = u1.UserID
                               join Users u2 on f.TrainerID = u2.UserID
                               where f.MemberID=@LoginID";

            SqlCommand command1 = new SqlCommand(insertQuery, conn);
            command1.Parameters.AddWithValue("@LoginID", Program.loginID);
            conn.Open();

            SqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                gymDataTable1.Rows.Add(reader1["FeedbackID"], reader1["Member"], reader1["Trainer"], reader1["Rating"], reader1["Comment"], reader1["Date"]);
            }

            conn.Close();
            dataGridView1.DataSource = gymDataTable1;

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 250;
            dataGridView1.Columns[5].Width = 100;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
