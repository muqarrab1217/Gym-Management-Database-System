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
    public partial class TRAINER_YourWorkoutPlan : Form
    {
        int trainerid;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public TRAINER_YourWorkoutPlan()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox9_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void TRAINER_YourWorkoutPlan_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string get_workoutID = "(select max(workoutID) + 1 from WorkoutPlan)";
            string insertWorkoutQuery = "INSERT INTO WORKOUTPLAN (WorkoutID, Name, CreatorID, Date)" +
                                     "VALUES (" + get_workoutID + ", @Name, @CreatorID, GETDATE())";

            SqlCommand cmd = new SqlCommand(insertWorkoutQuery, conn);
            cmd.Parameters.AddWithValue("@Name", name.Text);
            cmd.Parameters.AddWithValue("@CreatorID", Program.loginID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding workout: " + ex.Message);
                conn.Close(); // Make sure to close the connection in case of an error
                return; // Exit the method to prevent further execution
            }

            string get_ExerciseID = "(select max(ExerciseID) + 1 from Exercise)";
            string insertExerciseQuery = "INSERT INTO EXERCISE (ExerciseID, Muscle, Machine, Sets, Number_of_reps, Rest_interval)" +
                                         "VALUES (" + get_ExerciseID + ", @Muscle, @Machine, @Sets, @Number_of_reps, @Rest_interval)";

            SqlCommand cmd2 = new SqlCommand(insertExerciseQuery, conn);
            cmd2.Parameters.AddWithValue("@Muscle", muscle.Text);
            cmd2.Parameters.AddWithValue("@Machine", machine.Text);
            cmd2.Parameters.AddWithValue("@Sets", sets.Text);
            cmd2.Parameters.AddWithValue("@Number_of_reps", reps.Text);
            cmd2.Parameters.AddWithValue("@Rest_interval", rest.Text);

            try
            {
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding exercise: " + ex.Message);
                conn.Close(); // Make sure to close the connection in case of an error
                return; // Exit the method to prevent further execution
            }

            string insertWorkout_HasQuery = "INSERT INTO WORKOUT_HAS (WorkoutID, ExerciseID)" +
                                         "VALUES ((select max(workoutID) from WorkoutPlan), (select max(ExerciseID) from Exercise))";

            SqlCommand cmd3 = new SqlCommand(insertWorkout_HasQuery, conn);

            try
            {
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Workout Added");


                name.Text = "";
                muscle.Text = "";
                machine.Text = "";
                sets.Text = "";
                reps.Text = "";
                rest.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding workout to workout_has table: " + ex.Message);
                conn.Close(); // Make sure to close the connection in case of an error
            }
        }
    }
}
