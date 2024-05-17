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
    public partial class GYMOWNER_gym : Form
    {
        public GYMOWNER_gym()
        {
            InitializeComponent();
        }
        private void GYMOWNER_gym_Load(object sender, EventArgs e)
        {
            loadForm(new GYMOWNER_gymInfo());
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new GYMOWNER_trainerInfo());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new GYMOWNER_memberInfo());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gym_panel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadForm(new GYMOWNER_gymInfo());
        }
    }
}
