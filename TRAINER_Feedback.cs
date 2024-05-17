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
    public partial class TRAINER_Feedback : Form
    {
        int trainerid;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public TRAINER_Feedback()
        {
            InitializeComponent();
            trainerid = Program.loginID;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            LoadFeedbackdata();
        }

        void LoadFeedbackdata()
        {
            DataTable Feedback = new DataTable();

            Feedback.Columns.Add("FeedbackID", typeof(int));
            Feedback.Columns.Add("MemberID", typeof(int));
            Feedback.Columns.Add("MemberName", typeof(string));
            Feedback.Columns.Add("Rating", typeof(string));
            Feedback.Columns.Add("Comment", typeof(string));
            Feedback.Columns.Add("Date", typeof(string));

            string query = @"SELECT F.FeedbackID ,F.MemberID,M.Username,F.Rating,F.Comment,F.Date
                            FROM Feedback F
                            JOIN TRAINER T on T.TrainerID = F.TrainerID
                            JOIN Users M on M.UserID = F.MemberID
                            where T.TrainerID = @trainerid";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@trainerid", trainerid);
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Feedback.Rows.Add(reader["FeedbackID"], reader["MemberID"], reader["Username"], reader["Rating"], reader["Comment"], reader["Date"]);
            }

            conn.Close();
            dataGridView2.DataSource = Feedback;

        }

    }
}
