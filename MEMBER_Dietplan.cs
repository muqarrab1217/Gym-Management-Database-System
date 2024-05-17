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
    public partial class MEMBER_Dietplan : Form
    {
        public MEMBER_Dietplan()
        {
            InitializeComponent();
        }

        public void loadForm(object Form)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(f);
            this.panel1.Tag = f;
            f.Show();
        }

        private void report_Load(object sender, EventArgs e)
        {
            loadForm(new MEMBER_YourDietPlan());
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new MEMBER_SelectDietPlan());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new MEMBER_YourDietPlan());
        }

        private void gym_report_mainpanel_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadForm(new MEMBER_CreateDietPlan());
        }
    }
}
