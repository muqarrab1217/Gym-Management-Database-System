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
    public partial class MEMBER_UpcomingAppointment : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public MEMBER_UpcomingAppointment()
        {
            InitializeComponent();
        }
        private void MEMBER_UpcomingAppointment_Load(object sender, EventArgs e)
        {
            loadAppointments();
        }

        private void loadAppointments()
        {
            DataTable gymDataTable = new DataTable();

            gymDataTable.Columns.Add("Appointment ID", typeof(int));
            gymDataTable.Columns.Add("Member ID", typeof(int));
            gymDataTable.Columns.Add("Member Name", typeof(string));
            gymDataTable.Columns.Add("Trainer ID", typeof(int));
            gymDataTable.Columns.Add("Trainer Name", typeof(string));
            gymDataTable.Columns.Add("Date", typeof(string));
            gymDataTable.Columns.Add("Time", typeof(string));

            string query = "select a.AppointmentID, a.MemberID, u1.Username as MemberName, a.TrainerID, u2.Username as TrainerName, a.Date, a.Time " +
                           "from Appointment a " +
                           "inner join Users u1 on a.MemberID = u1.UserID " +
                           "inner join Users u2 on a.TrainerID = u2.UserID " +
                           "where a.MemberID = @loginID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@loginID", Program.loginID);
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                gymDataTable.Rows.Add(reader["AppointmentID"], reader["MemberID"], reader["MemberName"], reader["TrainerID"], reader["TrainerName"], reader["Date"], reader["Time"]);
            }

            conn.Close();
            dataGridView1.DataSource = gymDataTable;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 120;
            }
        }
        private void SearchfromUpcomingAppointments(string searchWord)
        {
            dataGridView1.DataSource = null;

            string baseQuery = "SELECT a.AppointmentID, a.MemberID, u1.Username AS MemberName, a.TrainerID, u2.Username AS TrainerName, a.Date, a.Time " +
                               "FROM Appointment a " +
                               "INNER JOIN Users u1 ON a.MemberID = u1.UserID " +
                               "INNER JOIN Users u2 ON a.TrainerID = u2.UserID " +
                               "WHERE a.MemberID = @loginID";

            List<string> searchColumns = new List<string> { "a.AppointmentID", "a.MemberID", "u1.Username", "a.TrainerID", "u2.Username", "a.Date", "a.Time" };
            string whereClause = string.Join(" OR ", searchColumns.Select(col => $"{col} LIKE @searchWord"));
            string query = $"{baseQuery} AND ({whereClause})";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@searchWord", "%" + searchWord + "%");
                cmd.Parameters.AddWithValue("@loginID", Program.loginID);
                conn.Open();

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                conn.Close();
            }

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 120;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string word = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(word))
                loadAppointments();
            else
                SearchfromUpcomingAppointments(word);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
