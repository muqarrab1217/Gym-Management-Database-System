using Admin_Interface.Resources;
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
    public partial class GYMOWNER_reports : Form
    {

        private void reports_Load(object sender, EventArgs e)
        {
            loadForm(new GYMOWNER_reportmember());
        }

        public void loadForm(object Form)
        {
            if (this.gym_panel.Controls.Count > 0)
                this.gym_panel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.gym_panel.Controls.Add(f);
            this.gym_panel.Tag = f;
            f.Show();
        }

        public GYMOWNER_reports()
        {
            InitializeComponent();
        }

        private void gym_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new GYMOWNER_reportmember());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new GYMOWNER_reporttrainer());

        }
    }
}
