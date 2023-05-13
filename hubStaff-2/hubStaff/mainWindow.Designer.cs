using System.Collections.Generic;
using hubStaff.models;

namespace hubStaff
{
    partial class mainWindow
    {
        private User user;

        public mainWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            this.labelUsername.Text = user.Login;
            List<string> nameTasks = new List<string>();
            comboBoxTasks.Items.Clear();
            foreach (var a in user.Tasks)
            {
                comboBoxTasks.Items.Add(a.Name);
            }
            comboBoxProject.Items.Clear();
            comboBoxProject.Items.Add("ItemFirst");
            comboBoxProject.Items.Add("ItemSecond");
            comboBoxProject.Enabled = true;
        }
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonStartWork = new System.Windows.Forms.Button();
            this.comboBoxTasks = new System.Windows.Forms.ComboBox();
            this.labelComboBox = new System.Windows.Forms.Label();
            this.richTextBoxReport = new System.Windows.Forms.RichTextBox();
            this.buttonReport = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonStop = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelClock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProject = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelUsername.Location = new System.Drawing.Point(315, 32);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(146, 37);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            // 
            // buttonStartWork
            // 
            this.buttonStartWork.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStartWork.Location = new System.Drawing.Point(315, 367);
            this.buttonStartWork.Name = "buttonStartWork";
            this.buttonStartWork.Size = new System.Drawing.Size(137, 54);
            this.buttonStartWork.TabIndex = 1;
            this.buttonStartWork.TabStop = false;
            this.buttonStartWork.Text = "Start work";
            this.buttonStartWork.UseVisualStyleBackColor = true;
            this.buttonStartWork.Click += new System.EventHandler(this.buttonStartWork_Click);
            // 
            // comboBoxTasks
            // 
            this.comboBoxTasks.AutoCompleteCustomSource.AddRange(new string[] {
            "projectFirst"});
            this.comboBoxTasks.Enabled = false;
            this.comboBoxTasks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxTasks.FormattingEnabled = true;
            this.comboBoxTasks.Items.AddRange(new object[] {
            "Task1",
            "Task2",
            "Task3",
            "Task4"});
            this.comboBoxTasks.Location = new System.Drawing.Point(254, 159);
            this.comboBoxTasks.Name = "comboBoxTasks";
            this.comboBoxTasks.Size = new System.Drawing.Size(149, 21);
            this.comboBoxTasks.TabIndex = 2;
            this.comboBoxTasks.Visible = false;
            this.comboBoxTasks.SelectedIndexChanged += new System.EventHandler(this.comboBoxTasks_SelectedIndexChanged);
            // 
            // labelComboBox
            // 
            this.labelComboBox.AutoSize = true;
            this.labelComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelComboBox.Location = new System.Drawing.Point(243, 114);
            this.labelComboBox.Name = "labelComboBox";
            this.labelComboBox.Size = new System.Drawing.Size(171, 25);
            this.labelComboBox.TabIndex = 3;
            this.labelComboBox.Text = "Choose your task:";
            this.labelComboBox.Visible = false;
            // 
            // richTextBoxReport
            // 
            this.richTextBoxReport.Location = new System.Drawing.Point(440, 119);
            this.richTextBoxReport.Name = "richTextBoxReport";
            this.richTextBoxReport.Size = new System.Drawing.Size(268, 132);
            this.richTextBoxReport.TabIndex = 4;
            this.richTextBoxReport.Text = "";
            this.richTextBoxReport.Visible = false;
            this.richTextBoxReport.TextChanged += new System.EventHandler(this.richTextBoxReport_TextChanged);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(466, 294);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(142, 22);
            this.buttonReport.TabIndex = 5;
            this.buttonReport.Text = "Send report";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Visible = false;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStop.Location = new System.Drawing.Point(315, 367);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(137, 54);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.TabStop = false;
            this.buttonStop.Text = "End work";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Visible = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // labelClock
            // 
            this.labelClock.AutoSize = true;
            this.labelClock.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelClock.Location = new System.Drawing.Point(75, 227);
            this.labelClock.Name = "labelClock";
            this.labelClock.Size = new System.Drawing.Size(112, 32);
            this.labelClock.TabIndex = 7;
            this.labelClock.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Choose your project:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.AutoCompleteCustomSource.AddRange(new string[] {
            "projectFirst",
            "projectSecond",
            "projectThird"});
            this.comboBoxProject.Enabled = false;
            this.comboBoxProject.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxProject.FormattingEnabled = true;
            this.comboBoxProject.Items.AddRange(new object[] {
            "Task1",
            "Task2",
            "Task3",
            "Task4"});
            this.comboBoxProject.Location = new System.Drawing.Point(61, 159);
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(149, 21);
            this.comboBoxProject.TabIndex = 9;
            this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxProject_SelectedIndexChanged);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelClock);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.richTextBoxReport);
            this.Controls.Add(this.labelComboBox);
            this.Controls.Add(this.comboBoxTasks);
            this.Controls.Add(this.buttonStartWork);
            this.Controls.Add(this.labelUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonStartWork;
        private System.Windows.Forms.ComboBox comboBoxTasks;
        private System.Windows.Forms.Label labelComboBox;
        private System.Windows.Forms.RichTextBox richTextBoxReport;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelClock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProject;
    }
}