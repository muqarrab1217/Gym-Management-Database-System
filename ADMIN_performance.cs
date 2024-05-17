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
    public partial class ADMIN_performance : Form
    {
        public ADMIN_performance()
        {
            InitializeComponent();
        }

        private void performance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'final_ProjectDataSet.Performance' table. You can move, or remove it, as needed.
            this.performanceTableAdapter.Fill(this.final_ProjectDataSet.Performance);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void performanceBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
