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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Admin_Interface
{
    public partial class MEMBER_SelectDietPlan : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public MEMBER_SelectDietPlan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void SelectDietPlan_Load(object sender, EventArgs e)
        {
            loadDietPlan();
            loadMeal();
            loadNutrition();
            fillcomboDietPlans();
        }

        private void loadDietPlan()
        {
            DataTable gymDataTable1 = new DataTable();

            gymDataTable1.Columns.Add("DietID", typeof(int));
            gymDataTable1.Columns.Add("Created_by", typeof(string));
            gymDataTable1.Columns.Add("Contains_Meal", typeof(string));
            gymDataTable1.Columns.Add("Meal_Nutritions", typeof(string));
            gymDataTable1.Columns.Add("Diet Type", typeof(string));
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
               d.Type AS [Diet Type], 
               d.Objective, 
               d.Number_of_days AS [Days] 
        FROM DietPlan d 
        JOIN Users u ON d.UserID = u.UserID 
        GROUP BY d.DietID, u.Username, d.Type, d.Objective, d.Number_of_days;
    ";

            SqlCommand command1 = new SqlCommand(insertDietPlan, conn);
            conn.Open();

            SqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                gymDataTable1.Rows.Add(reader1["DietID"], reader1["Created_by"], reader1["Contains_Meal"], reader1["Meal_Nutritions"], reader1["Diet Type"], reader1["Objective"], reader1["Days"]);
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

                string insertMeal = "SELECT MealID, Name AS Meal_Name FROM Meal";
                using (SqlCommand command2 = new SqlCommand(insertMeal, conn))
                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        gymDataTable2.Rows.Add(reader2["MealID"], reader2["Meal_Name"]);
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
            gymDataTable3.Columns.Add("Nutrition ID", typeof(int));
            gymDataTable3.Columns.Add("Meal Name", typeof(string));
            gymDataTable3.Columns.Add("Nutritions", typeof(string));

            try
            {
                conn.Open();

                string insertNutrition = @"
            SELECT mn.NutritionID,
                   m.Name AS MealName,
                   STUFF((SELECT ', ' + n.Name
                          FROM Meal_Nutrition mn_inner
                          JOIN Nutrition n ON mn_inner.NutritionID = n.NutritionID
                          WHERE mn_inner.MealID = mn.MealID
                          FOR XML PATH('')), 1, 2, '') AS Nutritions
            FROM Meal_Nutrition mn
            JOIN Meal m ON mn.MealID = m.MealID
            GROUP BY mn.NutritionID, mn.MealID, m.Name;
        ";

                using (SqlCommand command3 = new SqlCommand(insertNutrition, conn))
                using (SqlDataReader reader3 = command3.ExecuteReader())
                {
                    while (reader3.Read())
                    {
                        gymDataTable3.Rows.Add(reader3["NutritionID"], reader3["MealName"], reader3["Nutritions"]);
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
            dataGridView3.Columns[2].Width = 200;
        }

        private void fillcomboDietPlans()
        {
            comboBox1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select DietID from DietPlan";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["DietID"].ToString());
            }

            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string updateDietID = "UPDATE Member " +
                                  "SET dietid = @id " +
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
    }
}
