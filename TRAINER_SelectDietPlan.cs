using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Interface
{
    public partial class TRAINER_SelectDietPlan : Form
    {
        int trainerid;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public TRAINER_SelectDietPlan()
        {
            InitializeComponent();
            trainerid = Program.loginID;
            loadDietPlan();
            loadMeal();
            loadNutrition();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void loadDietPlan()
        {
            DataTable gymDataTable1 = new DataTable();

            gymDataTable1.Columns.Add("DietID", typeof(int));
            gymDataTable1.Columns.Add("Created_by", typeof(string));
            gymDataTable1.Columns.Add("Contains_Meal", typeof(string));
            gymDataTable1.Columns.Add("Meal_Nutritions", typeof(string));
            gymDataTable1.Columns.Add("DietType", typeof(string)); // Changed column name
            gymDataTable1.Columns.Add("Objective", typeof(string));
            gymDataTable1.Columns.Add("Days", typeof(int));

            string insertDietPlan = @"
        SELECT d.DietID, 
               u.Username AS Created_by, 
               STUFF((SELECT ', ' + mm.Name 
                      FROM Meal_Contains mc 
                      JOIN Meal mm ON mc.MealID = mm.MealID 
                      WHERE mc.DietID = d.DietID 
                      FOR XML PATH('')), 1, 2, '') AS Contains_Meal, 
               STUFF((SELECT ', ' + n.Name 
                      FROM Meal_Nutrition mn 
                      JOIN Nutrition n ON mn.NutritionID = n.NutritionID 
                      WHERE mn.MealID IN (SELECT MealID FROM Meal_Contains WHERE DietID = d.DietID) 
                      FOR XML PATH('')), 1, 2, '') AS Meal_Nutritions, 
               d.Type AS DietType, 
               d.Objective, 
               d.Number_of_days AS Days 
        FROM DietPlan d 
        JOIN Users u ON d.TrainerID = u.UserID 
        WHERE d.TrainerID = @trainerID
        GROUP BY d.DietID, u.Username, d.Type, d.Objective, d.Number_of_days;
        ";

            SqlCommand command1 = new SqlCommand(insertDietPlan, conn);
            command1.Parameters.AddWithValue("@trainerID", trainerid);
            conn.Open();

            SqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                gymDataTable1.Rows.Add(reader1["DietID"], reader1["Created_by"], reader1["Contains_Meal"], reader1["Meal_Nutritions"], reader1["DietType"], reader1["Objective"], reader1["Days"]);
            }

            conn.Close();
            dataGridView1.DataSource = gymDataTable1;

            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 110;
            dataGridView1.Columns[6].Width = 50;
        }



        private void loadMeal()
        {
            DataTable gymDataTable2 = new DataTable();
            gymDataTable2.Columns.Add("Meal ID", typeof(int));
            gymDataTable2.Columns.Add("Meal Name", typeof(string));

            try
            {
                conn.Open();

                // Query to select meals linked with the trainer's diet plans
                string insertMeal = @"
            SELECT m.MealID, m.Name AS Meal_Name 
            FROM Meal m 
            JOIN Meal_Contains mc ON m.MealID = mc.MealID 
            JOIN DietPlan d ON mc.DietID = d.DietID 
            WHERE d.TrainerID = @trainerID";

                using (SqlCommand command2 = new SqlCommand(insertMeal, conn))
                {
                    command2.Parameters.AddWithValue("@trainerID", trainerid);
                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            gymDataTable2.Rows.Add(reader2["MealID"], reader2["Meal_Name"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error loading meals: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            dataGridView2.DataSource = gymDataTable2;

            dataGridView2.Columns[0].Width = 200;
            dataGridView2.Columns[1].Width = 300;
        }


        private void loadNutrition()
        {
            DataTable gymDataTable3 = new DataTable();
            gymDataTable3.Columns.Add("Meal Name", typeof(string));
            gymDataTable3.Columns.Add("Nutritions", typeof(string));

            try
            {
                conn.Open();

                // Query to select distinct meals and concatenate all nutrition values
                string insertNutrition = @"
            SELECT m.MealID,
                   m.Name AS MealName,
                   STUFF((SELECT ', ' + n.Name
                          FROM Meal_Nutrition mn
                          JOIN Nutrition n ON mn.NutritionID = n.NutritionID
                          WHERE mn.MealID = m.MealID
                          FOR XML PATH('')), 1, 2, '') AS Nutritions
            FROM Meal m
            JOIN Meal_Contains mc ON m.MealID = mc.MealID
            JOIN DietPlan d ON mc.DietID = d.DietID
            WHERE d.TrainerID = @trainerID
            GROUP BY m.MealID, m.Name;
        ";

                using (SqlCommand command3 = new SqlCommand(insertNutrition, conn))
                {
                    command3.Parameters.AddWithValue("@trainerID", trainerid);
                    using (SqlDataReader reader3 = command3.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            gymDataTable3.Rows.Add(reader3["MealName"], reader3["Nutritions"]);
                        }
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

            dataGridView3.Columns[0].Width = 100;
            dataGridView3.Columns[1].Width = 200;
        }



        private void SelectDietPlan_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
