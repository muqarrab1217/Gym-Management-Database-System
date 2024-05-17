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
    public partial class GYM_MANAGEMENT_SYSTEM : Form
    {
        public GYM_MANAGEMENT_SYSTEM()
        {
            InitializeComponent();

          
        }

        private void GYM_MANAGEMENT_SYSTEM_Load(object sender, EventArgs e)
        {
            //LOGIN_Form login = new LOGIN_Form();
            //login.Show();
            //this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(2);
            if(progressBar1.Value == 100)
            {
                timer1.Enabled = false;

                this.Hide();
                LOGIN_Form login = new LOGIN_Form();
                login.Show();
            }
        }
    }
}
