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
    public partial class MEMBER_BookAppointment : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public MEMBER_BookAppointment()
        {
            InitializeComponent();
        }

        private void BookAppointment_Load(object sender, EventArgs e)
        {
            fillcomboTrainer();
        }
        private void fillcomboTrainer()
        {
            comboBox1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT trainerID FROM Trainer";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["trainerID"].ToString());
            }

            conn.Close();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(date.Text) && !string.IsNullOrEmpty(time.Text) && comboBox1.SelectedItem != null)
            {
                try
                {
                    string query = "INSERT INTO APPOINTMENT (AppointmentID, MemberID, TrainerID, Date, Time)" +
                                 "VALUES ((select max(appointmentid) + 1 from Appointment), @MemberID, @TrainerID, @Date, @Time)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MemberID", Program.loginID);
                    cmd.Parameters.AddWithValue("@TrainerID", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Date", date.Text);
                    cmd.Parameters.AddWithValue("@Time", time.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
