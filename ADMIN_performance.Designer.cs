
namespace Admin_Interface
{
    partial class ADMIN_performance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.performanceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gymIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipgrowthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customersatisfactionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialperformanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.final_ProjectDataSet = new Admin_Interface.Final_ProjectDataSet();
            this.panel9 = new System.Windows.Forms.Panel();
            this.performanceTableAdapter = new Admin_Interface.Final_ProjectDataSetTableAdapters.PerformanceTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.final_ProjectDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(533, 67);
            this.label2.TabIndex = 69;
            this.label2.Text = "GYM Performance Metrics";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 544);
            this.panel1.TabIndex = 71;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.performanceIDDataGridViewTextBoxColumn,
            this.gymIDDataGridViewTextBoxColumn,
            this.adminIDDataGridViewTextBoxColumn,
            this.membershipgrowthDataGridViewTextBoxColumn,
            this.customersatisfactionDataGridViewTextBoxColumn,
            this.financialperformanceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.performanceBindingSource;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(8, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1267, 531);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // performanceIDDataGridViewTextBoxColumn
            // 
            this.performanceIDDataGridViewTextBoxColumn.DataPropertyName = "PerformanceID";
            this.performanceIDDataGridViewTextBoxColumn.HeaderText = "PerformanceID";
            this.performanceIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.performanceIDDataGridViewTextBoxColumn.Name = "performanceIDDataGridViewTextBoxColumn";
            this.performanceIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.performanceIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // gymIDDataGridViewTextBoxColumn
            // 
            this.gymIDDataGridViewTextBoxColumn.DataPropertyName = "GymID";
            this.gymIDDataGridViewTextBoxColumn.HeaderText = "GymID";
            this.gymIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.gymIDDataGridViewTextBoxColumn.Name = "gymIDDataGridViewTextBoxColumn";
            this.gymIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.gymIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // adminIDDataGridViewTextBoxColumn
            // 
            this.adminIDDataGridViewTextBoxColumn.DataPropertyName = "AdminID";
            this.adminIDDataGridViewTextBoxColumn.HeaderText = "AdminID";
            this.adminIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.adminIDDataGridViewTextBoxColumn.Name = "adminIDDataGridViewTextBoxColumn";
            this.adminIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.adminIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // membershipgrowthDataGridViewTextBoxColumn
            // 
            this.membershipgrowthDataGridViewTextBoxColumn.DataPropertyName = "Membership_growth";
            this.membershipgrowthDataGridViewTextBoxColumn.HeaderText = "Membership_growth";
            this.membershipgrowthDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.membershipgrowthDataGridViewTextBoxColumn.Name = "membershipgrowthDataGridViewTextBoxColumn";
            this.membershipgrowthDataGridViewTextBoxColumn.ReadOnly = true;
            this.membershipgrowthDataGridViewTextBoxColumn.Width = 300;
            // 
            // customersatisfactionDataGridViewTextBoxColumn
            // 
            this.customersatisfactionDataGridViewTextBoxColumn.DataPropertyName = "Customer_satisfaction";
            this.customersatisfactionDataGridViewTextBoxColumn.HeaderText = "Customer_satisfaction";
            this.customersatisfactionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.customersatisfactionDataGridViewTextBoxColumn.Name = "customersatisfactionDataGridViewTextBoxColumn";
            this.customersatisfactionDataGridViewTextBoxColumn.ReadOnly = true;
            this.customersatisfactionDataGridViewTextBoxColumn.Width = 300;
            // 
            // financialperformanceDataGridViewTextBoxColumn
            // 
            this.financialperformanceDataGridViewTextBoxColumn.DataPropertyName = "Financial_performance";
            this.financialperformanceDataGridViewTextBoxColumn.HeaderText = "Financial_performance";
            this.financialperformanceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.financialperformanceDataGridViewTextBoxColumn.Name = "financialperformanceDataGridViewTextBoxColumn";
            this.financialperformanceDataGridViewTextBoxColumn.ReadOnly = true;
            this.financialperformanceDataGridViewTextBoxColumn.Width = 300;
            // 
            // performanceBindingSource
            // 
            this.performanceBindingSource.DataMember = "Performance";
            this.performanceBindingSource.DataSource = this.final_ProjectDataSet;
            this.performanceBindingSource.CurrentChanged += new System.EventHandler(this.performanceBindingSource_CurrentChanged);
            // 
            // final_ProjectDataSet
            // 
            this.final_ProjectDataSet.DataSetName = "Final_ProjectDataSet";
            this.final_ProjectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            this.panel9.Location = new System.Drawing.Point(6, 84);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1267, 54);
            this.panel9.TabIndex = 70;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // performanceTableAdapter
            // 
            this.performanceTableAdapter.ClearBeforeFill = true;
            // 
            // ADMIN_performance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 703);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ADMIN_performance";
            this.Text = "performance";
            this.Load += new System.EventHandler(this.performance_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.final_ProjectDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel9;
        private Final_ProjectDataSet final_ProjectDataSet;
        private System.Windows.Forms.BindingSource performanceBindingSource;
        private Final_ProjectDataSetTableAdapters.PerformanceTableAdapter performanceTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn performanceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gymIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adminIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn membershipgrowthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customersatisfactionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialperformanceDataGridViewTextBoxColumn;
    }
}