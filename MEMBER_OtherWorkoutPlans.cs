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
    public partial class MEMBER_OtherWorkoutPlans : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public MEMBER_OtherWorkoutPlans()
        {
            InitializeComponent();
        }

        private void OtherWorkoutPlans_Load(object sender, EventArgs e)
        {
            loadOtherWorkoutPlans();
            fillcomboWorkoutPlans();
        }

        private void fillcomboWorkoutPlans()
        {
            comboBox1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select WorkoutID from WorkoutPlan";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["WorkoutID"].ToString());
            }

            conn.Close();
        }

        private void loadOtherWorkoutPlans()
        {
            DataTable gymDataTable1 = new DataTable();

            gymDataTable1.Columns.Add("Workout ID", typeof(int));
            gymDataTable1.Columns.Add("Workout_Name", typeof(string));
            gymDataTable1.Columns.Add("Used By", typeof(string));
            gymDataTable1.Columns.Add("Exercise ID", typeof(string));
            gymDataTable1.Columns.Add("Muscle", typeof(string));
            gymDataTable1.Columns.Add("Machine", typeof(string));
            gymDataTable1.Columns.Add("Sets", typeof(string));
            gymDataTable1.Columns.Add("Reps", typeof(string));

            string insert = @"
                            SELECT w.WorkoutID, 
                            w.Name AS Workout_Name, 
                            u.Username AS Used_by,
                                    STUFF((SELECT ', ' + CONVERT(VARCHAR(10), wh_inner.ExerciseID)
                                           FROM Workout_has wh_inner
                                           WHERE wh_inner.WorkoutID = w.WorkoutID
                                           FOR XML PATH('')), 1, 2, '') AS Exercises,
                                    STUFF((SELECT ', ' + e.Muscle
                                           FROM Workout_has wh_inner
                                           JOIN Exercise e ON wh_inner.ExerciseID = e.ExerciseID
                                           WHERE wh_inner.WorkoutID = w.WorkoutID
                                           FOR XML PATH('')), 1, 2, '') AS Muscles,
                                    STUFF((SELECT ', ' + e.Machine
                                           FROM Workout_has wh_inner
                                           JOIN Exercise e ON wh_inner.ExerciseID = e.ExerciseID
                                           WHERE wh_inner.WorkoutID = w.WorkoutID
                                           FOR XML PATH('')), 1, 2, '') AS Machines,
                                    STUFF((SELECT ', ' + CONVERT(VARCHAR(10), e.Sets)
                                           FROM Workout_has wh_inner
                                           JOIN Exercise e ON wh_inner.ExerciseID = e.ExerciseID
                                           WHERE wh_inner.WorkoutID = w.WorkoutID
                                           FOR XML PATH('')), 1, 2, '') AS Sets,
                                    STUFF((SELECT ', ' + CONVERT(VARCHAR(10), e.Number_of_reps)
                                           FROM Workout_has wh_inner
                                           JOIN Exercise e ON wh_inner.ExerciseID = e.ExerciseID
                                           WHERE wh_inner.WorkoutID = w.WorkoutID
                                           FOR XML PATH('')), 1, 2, '') AS Reps
                             FROM WorkoutPlan w
                             JOIN Users u ON w.CreatorID = u.UserID
                             GROUP BY w.WorkoutID, w.Name, u.Username";

            SqlCommand command1 = new SqlCommand(insert, conn);
            command1.Parameters.AddWithValue("@LoginID", Program.loginID);
            conn.Open();

            SqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                gymDataTable1.Rows.Add(reader1["WorkoutID"], reader1["Workout_Name"], reader1["Used_by"], reader1["Exercises"], reader1["Muscles"], reader1["Machines"], reader1["Sets"], reader1["Reps"]);
            }

            conn.Close();
            dataGridView1.DataSource = gymDataTable1;

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 140;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string updateDietID = "UPDATE Member " +
                                  "SET WorkoutID = @id " +
                                  "WHERE memberid = @loginid";

            SqlCommand cmd = new SqlCommand(updateDietID, conn);
            cmd.Parameters.AddWithValue("@loginid", Program.loginID);
            cmd.Parameters.AddWithValue("@id", comboBox1.SelectedItem.ToString());

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, e.g., display error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
