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
    public partial class MEMBER_YourDietPlan : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public MEMBER_YourDietPlan()
        {
            InitializeComponent();
        }

        private void gym_member_Report_Load(object sender, EventArgs e)
        {
            loadDietPlan();
            loadMeal();
            loadNutrition();
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
                                    WHERE d.DietID = (SELECT dietid FROM Member WHERE memberid = @loginid)
                                    GROUP BY d.DietID, u.Username, d.Type, d.Objective, d.Number_of_days";

            SqlCommand command1 = new SqlCommand(insertDietPlan, conn);
            command1.Parameters.AddWithValue("@LoginID", Program.loginID);
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
            dataGridView1.Columns[4].Width = 110;
            dataGridView1.Columns[5].Width = 110;
            dataGridView1.Columns[6].Width = 60;
        }


        private void loadMeal()
        {
            DataTable gymDataTable2 = new DataTable();
            gymDataTable2.Columns.Add("DietID", typeof(int));
            gymDataTable2.Columns.Add("Meal ", typeof(string));
            gymDataTable2.Columns.Add("Protein Intake", typeof(string));

            try
            {
                conn.Open();

                string insertMeal = @"select d.DietID, m.Name, d.Type
                                      from DietPlan d
                                      left outer join Meal_Contains mc on d.DietID = mc.DietID
                                      left outer join meal m on mc.MealID = m.MealID
                                      inner join Member mm on d.DietID = mm.DietID
                                      where mm.MemberID = @LoginID";

                SqlCommand command2 = new SqlCommand(insertMeal, conn);
                command2.Parameters.AddWithValue("@LoginID", Program.loginID);

                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        gymDataTable2.Rows.Add(reader2["DietID"], reader2["Name"], reader2["Type"]);
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

            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[2].Width = 200;
        }

        private void loadNutrition()
        {
            DataTable gymDataTable3 = new DataTable();
            gymDataTable3.Columns.Add("DietID", typeof(int));
            gymDataTable3.Columns.Add("Meal ", typeof(string));
            gymDataTable3.Columns.Add("Nutritions ", typeof(string));
            gymDataTable3.Columns.Add("Protein Intake", typeof(string));

            try
            {
                conn.Open();

                string insertNutrition = @"select d.DietID, m.Name, n.Name, d.Type
                                         from DietPlan d
                                         left outer join Meal_Contains mc on d.DietID=mc.DietID
                                         left outer join meal m on mc.MealID=m.MealID
                                         left outer join Meal_Nutrition mn on m. MealID=mn.MealID
                                         left outer join Nutrition n on mn.NutritionID=n.NutritionID
                                         inner join Member mm on d.DietID=mm.DietID
                                         where mm.MemberID=@LoginID";

                SqlCommand command3 = new SqlCommand(insertNutrition, conn);
                command3.Parameters.AddWithValue("@LoginID", Program.loginID);

                using (SqlDataReader reader3 = command3.ExecuteReader())
                {
                    while (reader3.Read())
                    {
                        gymDataTable3.Rows.Add(reader3["DietID"], reader3["Name"], reader3["Name"], reader3["Type"]);
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



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
