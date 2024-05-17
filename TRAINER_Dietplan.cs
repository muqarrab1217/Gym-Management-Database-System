using System;
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
    public partial class TRAINER_Dietplan : Form
    {
        public TRAINER_Dietplan()
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

        private void report_Load(object sender, EventArgs e)
        {
            loadForm(new TRAINER_YourDietPlan());
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new TRAINER_SelectDietPlan());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new TRAINER_YourDietPlan());
        }

        private void gym_report_mainpanel_Paint(object sender, PaintEventArgs e)
        {
        
        }
    }
}
