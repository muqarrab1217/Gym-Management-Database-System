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
    public partial class ADMIN_gymReport : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True");

        public ADMIN_gymReport()
        {
            InitializeComponent();
        }

        private void ADMIN_gymReport_Load(object sender, EventArgs e)
        {
            fillcomboGym();
        }
        private void fillcomboGym()
        {
            comboBox1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT gymid " +
                              "FROM gym";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Gymid"].ToString());
            }

            conn.Close();
        }

        private void loadGymData()
        {
            DataTable gymDataTable = new DataTable();
            gymDataTable.Columns.Add("GymID", typeof(int));
            gymDataTable.Columns.Add("GymName", typeof(string));
            gymDataTable.Columns.Add("OwnerID", typeof(int));
            gymDataTable.Columns.Add("City", typeof(string));
            gymDataTable.Columns.Add("Street", typeof(string));

            try
            {
                conn.Open();

                string selectQuery = @"select g.GymID, g.GymName, g.OwnerID, g.City, g.Street
                               from gym g
                               where g.GymID=@GymID";

                SqlCommand command = new SqlCommand(selectQuery, conn);
                command.Parameters.AddWithValue("@GymID", comboBox1.SelectedItem.ToString());

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gymDataTable.Rows.Add(reader["GymID"], reader["GymName"], reader["OwnerID"], reader["City"], reader["Street"]);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error loading gym data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            dataGridView3.DataSource = gymDataTable;

        }

        private void loadTrainerData()
        {
            DataTable trainerDataTable = new DataTable();
            trainerDataTable.Columns.Add("TrainerID", typeof(int));
            trainerDataTable.Columns.Add("Username", typeof(string));
            trainerDataTable.Columns.Add("Experience", typeof(int));
            trainerDataTable.Columns.Add("Specialization", typeof(string));
            trainerDataTable.Columns.Add("Acc_status", typeof(string));

            try
            {
                conn.Open();

                string selectQuery = @"select t.TrainerID, u.Username, t.Experience, s.Specialization, t.Acc_status
                               from Trainer t
                               inner join Users u on t.TrainerID=u.UserID
                               inner join Specialization s on t.TrainerID=s.TrainerID
                               where t.GymID=@GymID";

                SqlCommand command = new SqlCommand(selectQuery, conn);
                command.Parameters.AddWithValue("@GymID", comboBox1.SelectedItem.ToString());

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trainerDataTable.Rows.Add(reader["TrainerID"], reader["Username"], reader["Experience"], reader["Specialization"], reader["Acc_status"]);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error loading trainer data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            dataGridView2.DataSource = trainerDataTable;
        }

        private void loadMemberData()
        {
            DataTable memberDataTable = new DataTable();
            memberDataTable.Columns.Add("MemberID", typeof(int));
            memberDataTable.Columns.Add("Username", typeof(string));
            memberDataTable.Columns.Add("Height", typeof(string));
            memberDataTable.Columns.Add("Weight", typeof(int));
            memberDataTable.Columns.Add("WorkoutPlan", typeof(string));
            memberDataTable.Columns.Add("Objective", typeof(string));
            memberDataTable.Columns.Add("DietType", typeof(string));

            try
            {
                conn.Open();

                string selectQuery = @"select m.MemberID, u.Username, m.Height, m.Weight, w.Name as WorkoutPlan, d.Objective, d.Type as DietType
                               from Member m
                               inner join Users u on m.MemberID=u.UserID
                               inner join WorkoutPlan w on m.WorkoutID=w.WorkoutID
                               inner join DietPlan d on m.DietID=d.DietID
                               where m.GymID=@GymID";

                SqlCommand command = new SqlCommand(selectQuery, conn);
                command.Parameters.AddWithValue("@GymID", comboBox1.SelectedItem.ToString());

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        memberDataTable.Rows.Add(reader["MemberID"], reader["Username"], reader["Height"], reader["Weight"], reader["WorkoutPlan"], reader["Objective"], reader["DietType"]);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error loading member data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            dataGridView1.DataSource = memberDataTable;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private static void GenerateDietPlanReport(string gymID, string gymName, string adminName, string members, string city, string street, string username, string objective, string type, string meals, string totalCalories)
        {
            try
            {
                Document doc = new Document();
                string filePath = "C:/Users/muq12/Desktop/Final_Projects/DataBase_Project/Admin_Interface/Reports/Gym Reports by Admin/" + gymID + "_" + gymName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                Paragraph title = new Paragraph("GYM MANAGEMENT SYSTEM REPORT", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                Paragraph subtitle = new Paragraph("Report generated by Admin: " + adminName, FontFactory.GetFont(FontFactory.HELVETICA, 12));
                subtitle.Alignment = Element.ALIGN_CENTER;
                doc.Add(subtitle);

                doc.Add(new Chunk("\n"));

                Paragraph gymDetails = new Paragraph("Gym Details", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                gymDetails.Alignment = Element.ALIGN_CENTER;
                doc.Add(gymDetails);

                Paragraph gymContent = new Paragraph();
                gymContent.Alignment = Element.ALIGN_CENTER;
                gymContent.Add(new Chunk("Gym ID: " + gymID + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                gymContent.Add(new Chunk("Gym Name: " + gymName + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                gymContent.Add(new Chunk("Location: " + street + ", " + city + "\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                gymContent.Add(new Chunk("Contact: 123-456-7890\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                gymContent.Add(new Chunk("Email: " + gymName + "@gmail.com.pk\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                doc.Add(gymContent);

                doc.Add(new Chunk("\n"));
                Paragraph memberStats = new Paragraph("Member Statistics", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                memberStats.Alignment = Element.ALIGN_CENTER;
                doc.Add(memberStats);

                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("C:/Users/muq12/Desktop/Final_Projects/DataBase_Project/barcode.png");
                image.Alignment = Element.ALIGN_CENTER;
                doc.Add(image);

                DataTable dietPlanData = GetDietPlanData(gymID);

                PdfPTable table = new PdfPTable(dietPlanData.Columns.Count);
                table.WidthPercentage = 100;

                foreach (DataColumn column in dietPlanData.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                    table.AddCell(cell);
                }

                foreach (DataRow row in dietPlanData.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        table.AddCell(new Phrase(item.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    }
                }

                doc.Add(table);
                doc.Close();

                Console.WriteLine("GYM Report generated successfully! File saved at: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static DataTable GetDietPlanData(string gymID)
        {
            DataTable dietPlanData = new DataTable();
            string query = @"SELECT m.MemberID, u.Username, d.Objective, d.Type
                     FROM Member m
                     INNER JOIN Users u ON m.MemberID = u.UserID
                     INNER JOIN DietPlan d ON m.DietID = d.DietID
                     WHERE m.GymID = @GymID";

            try
            {
                using (SqlConnection conn = new SqlConnection("YourConnectionString"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GymID", gymID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dietPlanData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching diet plan data: " + ex.Message);
            }

            return dietPlanData;
        }


        private void label5_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                loadGymData();
                loadTrainerData();
                loadMemberData();

                string selectQuery = @"SELECT g.GymID, g.GymName, g.City, g.Street 
                            FROM Gym g
                            WHERE g.GymID = @id
                            GROUP BY g.GymID, g.GymName, g.City, g.Street";

                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox1.SelectedItem));

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int gymID = Convert.ToInt32(reader["GymID"]);
                        string gymName = reader["GymName"].ToString();
                        string city = reader["City"].ToString();
                        string street = reader["Street"].ToString();

                        GenerateGymReport(gymID.ToString(), gymName, "Muqarrab Ahmed", city, street);
                    }
                }
                conn.Close();
            }
            else
                MessageBox.Show("Error: Please Select comlpete credentials");
        }


        private void GenerateGymReport(string gymID, string gymName, string adminName, string city, string street)
        {
            try
            {
                Document doc = new Document();
                string filePath = "C:/Users/muq12/Desktop/Final_Projects/DataBase_Project/Admin_Interface/Reports/Gym Reports by Admin/" + gymID + "_" + gymName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                Paragraph title = new Paragraph("GYM MANAGEMENT SYSTEM REPORT", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                Paragraph subtitle = new Paragraph("Report generated by Admin: " + adminName, FontFactory.GetFont(FontFactory.HELVETICA, 12));
                subtitle.Alignment = Element.ALIGN_CENTER;
                doc.Add(subtitle);

                doc.Add(new Chunk("\n"));
                Paragraph gymDetails = new Paragraph("Gym Details", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                gymDetails.Alignment = Element.ALIGN_CENTER;
                doc.Add(gymDetails);

                Paragraph gymContent = new Paragraph("Gym ID: " + gymID + "\nGym Name: " + gymName + "\nLocation: " + street + ", " + city + "\nNumber of Members: " + 17, FontFactory.GetFont(FontFactory.HELVETICA, 12));
                gymContent.Alignment = Element.ALIGN_CENTER;
                doc.Add(gymContent);

                doc.Add(new Chunk("\n"));

                if (comboBox2.SelectedItem.ToString() == "Members of One Specific Gym")
                {
                    Paragraph memberStats = new Paragraph("Member Statistics\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    memberStats.Alignment = Element.ALIGN_CENTER;
                    doc.Add(memberStats);

                    DataTable dietPlanData = GetMemberData(gymID);

                    PdfPTable table = new PdfPTable(dietPlanData.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataColumn column in dietPlanData.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dietPlanData.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            table.AddCell(new Phrase(item.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                        }
                    }

                    doc.Add(table);
                }
                else if (comboBox2.SelectedItem.ToString() == "Trainers of One Specific Gym")
                {
                    Paragraph memberStats = new Paragraph("Trainer Statistics\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    memberStats.Alignment = Element.ALIGN_CENTER;
                    doc.Add(memberStats);

                    DataTable dietPlanData = GetTrainerData(gymID);

                    PdfPTable table = new PdfPTable(dietPlanData.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataColumn column in dietPlanData.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dietPlanData.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            table.AddCell(new Phrase(item.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                        }
                    }

                    doc.Add(table);
                }
                else if (comboBox2.SelectedItem.ToString() == "Members of One Gym having meals with 300 above calorie Intake")
                {
                    Paragraph memberStats = new Paragraph("Member Statistics with Calorie Intake Greater than 300\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    memberStats.Alignment = Element.ALIGN_CENTER;
                    doc.Add(memberStats);

                    DataTable dietPlanData = Getcalorie_greaterthan_300(gymID);

                    PdfPTable table = new PdfPTable(dietPlanData.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataColumn column in dietPlanData.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dietPlanData.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            table.AddCell(new Phrase(item.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                        }
                    }

                    doc.Add(table);
                }
                else if (comboBox2.SelectedItem.ToString() == "Members of One Gym having meals with 40 above Protien Intake")
                {
                    Paragraph memberStats = new Paragraph("Member Statistics with Protein Intake Greater than 40 grams\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    memberStats.Alignment = Element.ALIGN_CENTER;
                    doc.Add(memberStats);

                    DataTable dietPlanData = Getprotien_greaterthan_40(gymID);

                    PdfPTable table = new PdfPTable(dietPlanData.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataColumn column in dietPlanData.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dietPlanData.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(item.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                            table.AddCell(cell);
                        }
                    }

                    doc.Add(table);

                }
                else if (comboBox2.SelectedItem.ToString() == "All Gyms with their total members and trainers")
                {

                    Paragraph memberStats = new Paragraph("Statistics of All Gyms with their total Members and Trainers\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    memberStats.Alignment = Element.ALIGN_CENTER;
                    doc.Add(memberStats);

                    DataTable dietPlanData = GetOverallGymData();

                    PdfPTable table = new PdfPTable(dietPlanData.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataColumn column in dietPlanData.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dietPlanData.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(item.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                            table.AddCell(cell);
                        }
                    }

                    doc.Add(table);
                }
                else if (comboBox2.SelectedItem.ToString() == "All Exercises with details of Machines Specific to them")
                {
                    try
                    {
                        Paragraph memberStats = new Paragraph("Statistics of All Exercises used with their Machines Specific to them\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                        memberStats.Alignment = Element.ALIGN_CENTER;
                        doc.Add(memberStats);

                        DataTable exerciseData = GetExerciseData();

                        if (exerciseData != null && exerciseData.Rows.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(exerciseData.Columns.Count);
                            table.WidthPercentage = 100;

                            float[] columnWidths = { 40f, 30f, 200f, 50f };
                            table.SetWidths(columnWidths);

                            foreach (DataColumn column in exerciseData.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                                table.AddCell(cell);
                            }

                            foreach (DataRow row in exerciseData.Rows)
                            {
                                foreach (var item in row.ItemArray)
                                {
                                    table.AddCell(new Phrase(item.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                                }
                            }

                            doc.Add(table);
                        }
                        else
                        {
                            Console.WriteLine("No data found for all exercises with details of machines specific to them.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while fetching exercise data: " + ex.Message);
                    }
                }
                else if (comboBox2.SelectedItem.ToString() == "All Workout Plans with details of Exercises Specific to them")
                {
                    Paragraph memberStats = new Paragraph("Statistics of All Workout Plans used with their Exercises Specific to them\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    memberStats.Alignment = Element.ALIGN_CENTER;
                    doc.Add(memberStats);

                    DataTable dietPlanData = GetWorkoutData();

                    PdfPTable table = new PdfPTable(dietPlanData.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataColumn column in dietPlanData.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dietPlanData.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            table.AddCell(new Phrase(item.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                        }
                    }

                    doc.Add(table);
                }



                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("C:/Users/muq12/Desktop/Final_Projects/DataBase_Project/barcode.png");
                image.Alignment = Element.ALIGN_CENTER;
                doc.Add(image);

                doc.Close();

                Console.WriteLine("GYM Report generated successfully! File saved at: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        private static DataTable GetMemberData(string gymID)
        {
            DataTable gymData = new DataTable();
            string query = @"SELECT m.MemberID, u.Username, m.Height, m.Weight, w.Name as WorkoutPlan, d.Type as DietPlan
                        FROM Gym g
                        JOIN Member m ON g.GymID = m.GymID
                        JOIN Users u ON m.MemberID = u.UserID
                        JOIN WorkoutPlan w ON m.WorkoutID = w.WorkoutID
                        JOIN DietPlan d ON m.DietID = d.DietID
                        WHERE g.GymID = @GymID";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GymID", gymID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(gymData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching gym data: " + ex.Message);
            }

            return gymData;
        }
        private static DataTable GetTrainerData(string gymID)
        {
            DataTable trainerData = new DataTable();
            string query = @"SELECT t.TrainerID, u.Username, s.Specialization, t.Experience, t.Acc_status
                        FROM Gym g
                        JOIN Trainer t ON g.GymID = t.GymID
                        JOIN Users u ON t.TrainerID = u.UserID
                        JOIN Specialization s ON t.TrainerID = s.TrainerID
                        WHERE g.GymID = @GymID";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GymID", gymID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(trainerData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching trainer data: " + ex.Message);
            }

            return trainerData;
        }
        private static DataTable Getcalorie_greaterthan_300(string gymID)
        {
            DataTable dietPlanData = new DataTable();
            string query = @"SELECT m.MemberID, u.Username, d.Objective, d.Type, 
                            STUFF((
                                SELECT ', ' + m2.Name
                                FROM Meal_Contains cm 
                                INNER JOIN Meal m2 ON cm.MealID = m2.MealID 
                                WHERE cm.DietID = d.DietID 
                                FOR XML PATH('')
                            ), 1, 2, '') AS Meals,
                            (
                                SELECT MAX(m2.calories)
                                FROM Meal_Contains cm 
                                INNER JOIN Meal m2 ON cm.MealID = m2.MealID 
                                WHERE cm.DietID = d.DietID
                            ) AS TotalCalories
                        FROM Member m
                        INNER JOIN Users u ON m.MemberID = u.UserID
                        INNER JOIN DietPlan d ON m.DietID = d.DietID
                        WHERE m.GymID = @GymID AND m.MemberID IN (
                            SELECT m.MemberID
                            FROM Member m
                            INNER JOIN Meal_Contains mc ON m.DietID = mc.DietID
                            INNER JOIN Meal m1 ON mc.MealID = m1.MealID
                            INNER JOIN Meal_Nutrition mn ON m1.MealID = mn.MealID
                            INNER JOIN Nutrition n ON mn.NutritionID = n.NutritionID
                            WHERE m1.calories > 300
                        )";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GymID", gymID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dietPlanData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching diet plan data: " + ex.Message);
            }

            return dietPlanData;
        }

        private static DataTable Getprotien_greaterthan_40(string gymID)
        {
            DataTable dietPlanData = new DataTable();
            string query = @"SELECT m.MemberID, u.Username, d.Objective, d.Type, 
                            STUFF((
                                SELECT ', ' + m2.Name
                                FROM Meal_Contains cm 
                                INNER JOIN Meal m2 ON cm.MealID = m2.MealID 
                                WHERE cm.DietID = d.DietID 
                                FOR XML PATH('')
                            ), 1, 2, '') AS Meals,
                            (
                                SELECT MAX(m2.calories)/5
                                FROM Meal_Contains cm 
                                INNER JOIN Meal m2 ON cm.MealID = m2.MealID 
                                WHERE cm.DietID = d.DietID
                            ) AS ProtienIntake
                        FROM Member m
                        INNER JOIN Users u ON m.MemberID = u.UserID
                        INNER JOIN DietPlan d ON m.DietID = d.DietID
                        WHERE m.GymID = @GymID AND m.MemberID IN (
                            SELECT m.MemberID
                            FROM Member m
                            INNER JOIN Meal_Contains mc ON m.DietID = mc.DietID
                            INNER JOIN Meal m1 ON mc.MealID = m1.MealID
                            INNER JOIN Meal_Nutrition mn ON m1.MealID = mn.MealID
                            INNER JOIN Nutrition n ON mn.NutritionID = n.NutritionID
                            WHERE m1.calories > 300
                        )";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GymID", gymID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dietPlanData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching diet plan data: " + ex.Message);
            }

            return dietPlanData;
        }
        private static DataTable GetOverallGymData()
        {
            DataTable gymData = new DataTable();
            string query = @"
        SELECT g.GymID, 
               g.GymName, 
               COUNT(DISTINCT m.MemberID) AS TotalMembers, 
               COUNT(DISTINCT t.TrainerID) AS TotalTrainers
        FROM Gym g
        LEFT JOIN Member m ON g.GymID = m.GymID
        LEFT JOIN Trainer t ON g.GymID = t.GymID
        GROUP BY g.GymID, g.GymName";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(gymData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching gym data: " + ex.Message);
            }

            return gymData;
        }

        private static DataTable GetExerciseData()
        {
            DataTable exerciseData = new DataTable();
            string query = @"SELECT ROW_NUMBER() 
                     OVER (ORDER BY Muscle) AS ExerciseID,
                     Muscle,
                     STUFF((
                         SELECT ', ' + ex.Machine
                         FROM Exercise ex 
                         WHERE ex.Muscle = e.Muscle
                         FOR XML PATH(''), TYPE
                     ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Machines,
                     e.Rest_interval
                    FROM Exercise e
                    GROUP BY Muscle, e.Rest_interval;";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(exerciseData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching exercise data: " + ex.Message);
            }

            return exerciseData;
        }
        private static DataTable GetWorkoutData()
        {
            DataTable exerciseData = new DataTable();
            string query = @"SELECT top 15 w.WorkoutID, w.Name AS WorkoutName, 
                             STUFF((
                                     SELECT ', ' + e.Machine
                                     FROM Workout_has wh 
                                     INNER JOIN Exercise e ON wh.ExerciseID = e.ExerciseID
                                     WHERE 
                                         wh.WorkoutID = w.WorkoutID
                                     FOR XML PATH(''), TYPE
                                 ).value('.', 'NVARCHAR(MAX)'), 1, 2, ''
                             ) AS [Machines Used]
                             FROM WorkoutPlan w;";

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-ASQAQVJ\\SQLEXPRESS;Initial Catalog=Final Project;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(exerciseData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching exercise data: " + ex.Message);
            }

            return exerciseData;
        }


        private void panel9_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
