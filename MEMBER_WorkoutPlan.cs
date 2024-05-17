﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Interface
{
    public partial class MEMBER_WorkoutPlan : Form
    {
        public MEMBER_WorkoutPlan()
        {
            InitializeComponent();
        }

        public void loadForm(object Form)
        {
            if (this.gym_report_mainpanel.Controls.Count > 0)
                this.gym_report_mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.gym_report_mainpanel.Controls.Add(f);
            this.gym_report_mainpanel.Tag = f;
            f.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gym_report_mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new MEMBER_YourWorkoutPlan());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new MEMBER_OtherWorkoutPlans());
        }

        private void WorkoutPlan_Load(object sender, EventArgs e)
        {
            loadForm(new MEMBER_YourWorkoutPlan());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadForm(new MEMBER_CreateWorkout());
        }
    }
}
