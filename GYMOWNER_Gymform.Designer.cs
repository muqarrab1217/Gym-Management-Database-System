﻿
namespace Admin_Interface
{
    partial class GYMOWNER_Gymform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GYMOWNER_Gymform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DashBoard = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gymButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.performanceButton = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.adName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 59);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Admin_Interface.Properties.Resources.menu_26px;
            this.pictureBox1.Location = new System.Drawing.Point(12, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DashBoard);
            this.panel2.Location = new System.Drawing.Point(3, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 48);
            this.panel2.TabIndex = 1;
            // 
            // DashBoard
            // 
            this.DashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DashBoard.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashBoard.ForeColor = System.Drawing.Color.White;
            this.DashBoard.Image = global::Admin_Interface.Properties.Resources.home_26px;
            this.DashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashBoard.Location = new System.Drawing.Point(-7, -7);
            this.DashBoard.Name = "DashBoard";
            this.DashBoard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.DashBoard.Size = new System.Drawing.Size(243, 65);
            this.DashBoard.TabIndex = 1;
            this.DashBoard.Text = "              Dashboard";
            this.DashBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashBoard.UseVisualStyleBackColor = true;
            this.DashBoard.Click += new System.EventHandler(this.DashBoard_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gymButton);
            this.panel5.Location = new System.Drawing.Point(3, 191);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(234, 48);
            this.panel5.TabIndex = 4;
            // 
            // gymButton
            // 
            this.gymButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gymButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gymButton.ForeColor = System.Drawing.Color.White;
            this.gymButton.Image = global::Admin_Interface.Properties.Resources.icons8_barbell_26;
            this.gymButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gymButton.Location = new System.Drawing.Point(-7, -7);
            this.gymButton.Name = "gymButton";
            this.gymButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.gymButton.Size = new System.Drawing.Size(243, 65);
            this.gymButton.TabIndex = 1;
            this.gymButton.Text = "              Gym";
            this.gymButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gymButton.UseVisualStyleBackColor = true;
            this.gymButton.Click += new System.EventHandler(this.gymButton_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.performanceButton);
            this.panel6.Location = new System.Drawing.Point(3, 299);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(234, 48);
            this.panel6.TabIndex = 5;
            // 
            // performanceButton
            // 
            this.performanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.performanceButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.performanceButton.ForeColor = System.Drawing.Color.White;
            this.performanceButton.Image = global::Admin_Interface.Properties.Resources.icons8_increase_26;
            this.performanceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.performanceButton.Location = new System.Drawing.Point(-5, -7);
            this.performanceButton.Name = "performanceButton";
            this.performanceButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.performanceButton.Size = new System.Drawing.Size(241, 65);
            this.performanceButton.TabIndex = 1;
            this.performanceButton.Text = "              Reports";
            this.performanceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.performanceButton.UseVisualStyleBackColor = true;
            this.performanceButton.Click += new System.EventHandler(this.performanceButton_Click);
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.sidebar.Controls.Add(this.panel9);
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel6);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.MaximumSize = new System.Drawing.Size(259, 703);
            this.sidebar.MinimumSize = new System.Drawing.Size(65, 703);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(259, 703);
            this.sidebar.TabIndex = 8;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label5);
            this.panel9.Controls.Add(this.bunifuPictureBox1);
            this.panel9.Controls.Add(this.adName);
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(251, 63);
            this.panel9.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(171)))), ((int)(((byte)(204)))));
            this.label5.Location = new System.Drawing.Point(80, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "* * * * * * * * ";
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 29;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(3, 5);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(58, 58);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 1;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // adName
            // 
            this.adName.AutoSize = true;
            this.adName.BackColor = System.Drawing.Color.Transparent;
            this.adName.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(171)))), ((int)(((byte)(204)))));
            this.adName.Location = new System.Drawing.Point(80, 17);
            this.adName.Name = "adName";
            this.adName.Size = new System.Drawing.Size(133, 25);
            this.adName.TabIndex = 6;
            this.adName.Text = "Muqarrab Ahmed";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(3, 245);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(234, 48);
            this.panel3.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Admin_Interface.Properties.Resources.icons8_increase_26;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-5, -7);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(241, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "              Registrations";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.BackColor = System.Drawing.Color.White;
            this.mainpanel.Location = new System.Drawing.Point(259, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1285, 703);
            this.mainpanel.TabIndex = 9;
            this.mainpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainpanel_Paint);
            // 
            // GYMOWNER_Gymform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(1924, 703);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GYMOWNER_Gymform";
            this.Text = "Gym Owner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button DashBoard;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button gymButton;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button performanceButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label5;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Label adName;
    }
}

