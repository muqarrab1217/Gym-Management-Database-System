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
    public partial class MEMBER_CreateWorkout : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public MEMBER_CreateWorkout()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
                MessageBox.Show("Error: " + ex.Message);
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
                MessageBox.Show("Error: " + ex.Message);
            }

            string insertWorkout_HasQuery = "INSERT INTO WORKOUT_HAS (WorkoutID, ExerciseID)" +
                                         "VALUES ((select max(workoutID) from WorkoutPlan), (select max(ExerciseID) from Exercise))";

            SqlCommand cmd3 = new SqlCommand(insertWorkout_HasQuery, conn);

            try
            {
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void MEMBER_CreateWorkout_Load(object sender, EventArgs e)
        {

        }
    }
}
