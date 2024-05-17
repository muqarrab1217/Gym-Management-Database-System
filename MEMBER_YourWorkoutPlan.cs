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
    public partial class MEMBER_YourWorkoutPlan : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public MEMBER_YourWorkoutPlan()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void YourWorkoutPlan_Load(object sender, EventArgs e)
        {
            loadExercises();
            loadWorkoutPlan();
            loadWorkoutReport();
        }
        private void loadExercises()
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
                             where w.WorkoutID=(SELECT WorkoutID FROM Member WHERE memberid = @LoginID)
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

        private void loadWorkoutPlan()
        {
            DataTable gymDataTable2 = new DataTable();
            gymDataTable2.Columns.Add("Workout ID", typeof(int));
            gymDataTable2.Columns.Add("Workout Name", typeof(string));
            gymDataTable2.Columns.Add("Creator Name", typeof(string));
            gymDataTable2.Columns.Add("Date", typeof(string));

            try
            {
                conn.Open();

                string insertworkout = @"select w.WorkoutID, w.Name as Workout_Name, u.Username as Creator_Name, w.Date
                                      from WorkoutPlan w
                                      inner
                                      join Users u on w.CreatorID = u.UserID";

                using (SqlCommand command2 = new SqlCommand(insertworkout, conn))
                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        gymDataTable2.Rows.Add(reader2["WorkoutID"], reader2["Workout_Name"], reader2["Creator_Name"], reader2["Date"]);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error loading workouts: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            dataGridView2.DataSource = gymDataTable2;

            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].Width = 130;
            dataGridView2.Columns[2].Width = 130;
        }

        private void loadWorkoutReport()
        {
            DataTable gymDataTable3 = new DataTable();
            gymDataTable3.Columns.Add("Report ID", typeof(int));
            gymDataTable3.Columns.Add("Creator Name", typeof(string));
            gymDataTable3.Columns.Add("Goal", typeof(string));
            gymDataTable3.Columns.Add("Schedule", typeof(string));

            try
            {
                conn.Open();

                string insertNutrition = @"
                                          select wr.Workout_reportid, u.Username as Creator_Name, wr.Goal, wr.Schedule
                                          from WorkoutReport wr
                                          inner join Users u on wr.CreatorID=u.UserID";

                using (SqlCommand command3 = new SqlCommand(insertNutrition, conn))
                using (SqlDataReader reader3 = command3.ExecuteReader())
                {
                    while (reader3.Read())
                    {
                        gymDataTable3.Rows.Add(reader3["Workout_reportid"], reader3["Creator_Name"], reader3["Goal"], reader3["Schedule"]);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error loading nutrition: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            dataGridView3.DataSource = gymDataTable3;

            dataGridView3.Columns[0].Width = 80;
            dataGridView3.Columns[1].Width = 130;
            dataGridView3.Columns[2].Width = 100;
            dataGridView3.Columns[3].Width = 100;
        }
    }
}
