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
using System.Data.SqlClient;

namespace Admin_Interface
{
    public partial class MEMBER_CreateDietPlan : Form
    {
        int memberid;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public MEMBER_CreateDietPlan()
        {
            InitializeComponent();
            comboBox1.DisplayMember = "MealName";
            memberid = Program.loginID;
            PopulateComboBox();
        }

        private void gym_member_Report_Load(object sender, EventArgs e)
        {

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

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public class MealItem
        {
            public int MealID { get; set; }
            public string MealName { get; set; }

            public override string ToString()
            {
                return MealName; // Display the MealName in the ComboBox
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void PopulateComboBox()
        {
            comboBox1.Items.Clear(); // Clear existing items

            try
            {
                conn.Open();
                string query = "SELECT MealID, Name AS MealName FROM Meal"; // Modify this query according to your database schema
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MealItem mealItem = new MealItem
                    {
                        MealID = Convert.ToInt32(reader["MealID"]),
                        MealName = reader["MealName"].ToString()
                    };
                    comboBox1.Items.Add(mealItem);
                    comboBox2.Items.Add(mealItem);
                    comboBox3.Items.Add(mealItem);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating ComboBox: " + ex.Message);
            }
        }

        private string GetNutritionsForMeal(int mealID)
        {
            string nutritions = "";

            try
            {
                conn.Open();
                string query = @"SELECT n.Name AS NutritionName
                         FROM Meal_Nutrition mn
                         JOIN Nutrition n ON mn.NutritionID = n.NutritionID
                         WHERE mn.MealID = @mealID";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@mealID", mealID);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nutritionName = reader["NutritionName"].ToString();
                    nutritions += nutritionName + Environment.NewLine; // Add each nutrition with a new line
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading nutritions: " + ex.Message);
            }

            return nutritions;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                int days;
                if (!int.TryParse(daysbox.Text, out days))
                {
                    MessageBox.Show("Please enter a valid number of days.");
                    return;
                }

                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Please select a diet type.");
                    return;
                }

                string dietType = comboBox2.SelectedItem.ToString();
                string objective = objectivebox.Text;

                int memberid = this.memberid;

                conn.Open();

                string getMaxDietIDQuery = "SELECT ISNULL(MAX(DietID), 0) FROM DietPlan";
                SqlCommand getMaxDietIDCommand = new SqlCommand(getMaxDietIDQuery, conn);
                int maxDietID = Convert.ToInt32(getMaxDietIDCommand.ExecuteScalar());
                int dietPlanID = maxDietID + 1;

                conn.Close();

                conn.Open();

                string insertDietPlanQuery = "INSERT INTO DietPlan (DietID, UserID, Objective, Type, Number_of_days) " +
                    "VALUES (@DietID, @MemberID, @Objective, @Type, @Number_of_days)";
                SqlCommand insertDietPlanCommand = new SqlCommand(insertDietPlanQuery, conn);
                insertDietPlanCommand.Parameters.AddWithValue("@DietID", dietPlanID);
                insertDietPlanCommand.Parameters.AddWithValue("@MemberID", memberid);
                insertDietPlanCommand.Parameters.AddWithValue("@Objective", objective);
                insertDietPlanCommand.Parameters.AddWithValue("@Type", dietType);
                insertDietPlanCommand.Parameters.AddWithValue("@Number_of_days", days);
                insertDietPlanCommand.ExecuteNonQuery();

                string insertMealContainsQuery = "INSERT INTO Meal_Contains (DietID, MealID) VALUES (@DietID, @MealID)";
                SqlCommand insertMealContainsCommand = new SqlCommand(insertMealContainsQuery, conn);
                insertMealContainsCommand.Parameters.AddWithValue("@DietID", dietPlanID);

                if (comboBox1.SelectedItem != null)
                {
                    int mealID1 = ((MealItem)comboBox1.SelectedItem).MealID;
                    insertMealContainsCommand.Parameters.AddWithValue("@MealID", mealID1);
                    insertMealContainsCommand.ExecuteNonQuery();
                }

                if (comboBox2.SelectedItem != null)
                {
                    int mealID2 = ((MealItem)comboBox2.SelectedItem).MealID;
                    insertMealContainsCommand.Parameters["@MealID"].Value = mealID2;
                    insertMealContainsCommand.ExecuteNonQuery();
                }

                if (comboBox3.SelectedItem != null)
                {
                    int mealID3 = ((MealItem)comboBox3.SelectedItem).MealID;
                    insertMealContainsCommand.Parameters["@MealID"].Value = mealID3;
                    insertMealContainsCommand.ExecuteNonQuery();
                }

                conn.Close();

                MessageBox.Show("Diet Plan created successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating diet plan: " + ex.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                MealItem selectedMeal = (MealItem)comboBox1.SelectedItem;
                int mealID = selectedMeal.MealID;

                // Load nutritions for the selected meal
                string nutritions = GetNutritionsForMeal(mealID);

                // Set the text of the TextBox with the fetched nutrients
                maskedTextBox1.Text = nutritions;
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                MealItem selectedMeal = (MealItem)comboBox2.SelectedItem;
                int mealID = selectedMeal.MealID;

                // Load nutritions for the selected meal
                string nutritions = GetNutritionsForMeal(mealID);

                // Set the text of the TextBox with the fetched nutrients
                maskedTextBox2.Text = nutritions;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                MealItem selectedMeal = (MealItem)comboBox3.SelectedItem;
                int mealID = selectedMeal.MealID;

                // Load nutritions for the selected meal
                string nutritions = GetNutritionsForMeal(mealID);

                // Set the text of the TextBox with the fetched nutrients
                maskedTextBox3.Text = nutritions;
            }
        }
    }
}
