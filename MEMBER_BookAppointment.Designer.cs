namespace Admin_Interface
{
    partial class MEMBER_BookAppointment
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
            this.label1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(292, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 30);
            this.label1.TabIndex = 69;
            this.label1.Text = "Appointment Time: ";
            // 
            // time
            // 
            this.time.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.time.CalendarFont = new System.Drawing.Font("Poppins Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.CalendarForeColor = System.Drawing.Color.SteelBlue;
            this.time.CalendarMonthBackground = System.Drawing.SystemColors.ButtonFace;
            this.time.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonFace;
            this.time.CalendarTitleForeColor = System.Drawing.Color.AntiqueWhite;
            this.time.CalendarTrailingForeColor = System.Drawing.SystemColors.ButtonFace;
            this.time.Cursor = System.Windows.Forms.Cursors.Hand;
            this.time.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time.Location = new System.Drawing.Point(562, 176);
            this.time.Name = "time";
            this.time.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.time.Size = new System.Drawing.Size(261, 30);
            this.time.TabIndex = 68;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Qasim Hassan",
            "Areez Abdullah",
            "Muqarrab Ahmed"});
            this.comboBox1.Location = new System.Drawing.Point(562, 238);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(261, 34);
            this.comboBox1.TabIndex = 67;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(292, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 30);
            this.label5.TabIndex = 66;
            this.label5.Text = "Trainer Name:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(292, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 30);
            this.label7.TabIndex = 65;
            this.label7.Text = "Appointment Date: ";
            // 
            // date
            // 
            this.date.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.date.CalendarFont = new System.Drawing.Font("Poppins Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.CalendarForeColor = System.Drawing.Color.SteelBlue;
            this.date.CalendarMonthBackground = System.Drawing.SystemColors.ButtonFace;
            this.date.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonFace;
            this.date.CalendarTitleForeColor = System.Drawing.Color.AntiqueWhite;
            this.date.CalendarTrailingForeColor = System.Drawing.SystemColors.ButtonFace;
            this.date.Cursor = System.Windows.Forms.Cursors.Hand;
            this.date.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(562, 121);
            this.date.Name = "date";
            this.date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.date.Size = new System.Drawing.Size(261, 30);
            this.date.TabIndex = 64;
            this.date.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(84, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 42);
            this.label2.TabIndex = 63;
            this.label2.Text = "Book an appointment";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-56, -8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1337, 70);
            this.panel1.TabIndex = 63;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(78)))), ((int)(((byte)(128)))));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(571, 322);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(236, 47);
            this.button5.TabIndex = 70;
            this.button5.Text = "Book Appointment";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // MEMBER_BookAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1285, 703);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.time);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.date);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MEMBER_BookAppointment";
            this.Text = "BookAppointment";
            this.Load += new System.EventHandler(this.BookAppointment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
    }
}