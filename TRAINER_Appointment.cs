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
    public partial class Appointment_Trainer_ : Form
    {
        int trainerid;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public Appointment_Trainer_()
        {
            InitializeComponent();
        }

        private void Appointment_Trainer__Load(object sender, EventArgs e)
        {
            trainerid = Program.loginID;
            LoadAppoinmentdata();
            fillAppointmentCombo();
        }

        private void fillAppointmentCombo()
        {
            comboBox2.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select a.AppointmentID
                                from Appointment a
                                where a.TrainerID = 105";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["AppointmentID"].ToString());
            }

            conn.Close();
        }

        void LoadAppoinmentdata()
        {
            DataTable Appointmenttable = new DataTable();

            Appointmenttable.Columns.Add("AppoimtnetID", typeof(int));
            Appointmenttable.Columns.Add("MemberID", typeof(int));
            Appointmenttable.Columns.Add("MemberName", typeof(string));
            Appointmenttable.Columns.Add("Date", typeof(string));
            Appointmenttable.Columns.Add("Time", typeof(string));

            string query = @"SELECT A.AppointmentID,A.MemberID,M.Username as 'Member Name',A.Date,A.Time
                            FROM Appointment A
                            JOIN TRAINER T on T.TrainerID = A.TrainerID
                            JOIN Users M on M.UserID = A.MemberID
                            where T.TrainerID = @trainerid";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@trainerid", trainerid);
            conn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Appointmenttable.Rows.Add(reader["AppointmentID"], reader["MemberID"], reader["Member Name"], reader["Date"], reader["Time"]);
            }

            conn.Close();
            dataGridView1.DataSource = Appointmenttable;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
