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
    public partial class ADMIN_Audit : Form
    {
        public ADMIN_Audit()
        {
            InitializeComponent();
        }

        private void ADMIN_Audit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'final_ProjectDataSet1.audit_trail' table. You can move, or remove it, as needed.
            this.audit_trailTableAdapter.Fill(this.final_ProjectDataSet1.audit_trail);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
