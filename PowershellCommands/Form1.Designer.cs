namespace PowershellCommands
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.folderBrowserDialog4 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Vue website";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonCoreDev_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(217, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Run Maintenance migration";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonMaintenanceMigration_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(30, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "Run Maintenance API";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonRunApp_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(30, 524);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 33);
            this.button4.TabIndex = 3;
            this.button4.Text = "Add migration";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonAddMigration_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(236, 526);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Migration name";
            this.textBox1.Size = new System.Drawing.Size(200, 27);
            this.textBox1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(30, 366);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(273, 35);
            this.button5.TabIndex = 4;
            this.button5.Text = "Select Maintenance Root Folder";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(309, 369);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Root path is empty";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(238, 27);
            this.textBox2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(553, 337);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 64);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(30, 33);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 34);
            this.button6.TabIndex = 7;
            this.button6.Text = "Select Core Root Folder";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(245, 37);
            this.textBox3.Name = "textBox3";
            this.textBox3.PlaceholderText = "Root path is empty";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(246, 27);
            this.textBox3.TabIndex = 8;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(30, 92);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(291, 29);
            this.button7.TabIndex = 9;
            this.button7.Text = "Connect to staging maintenance api";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(342, 92);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(265, 29);
            this.button8.TabIndex = 10;
            this.button8.Text = "Connect to local maintenance api";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Migration name";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(30, 588);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(291, 29);
            this.button9.TabIndex = 12;
            this.button9.Text = "Connect to staging database";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.ConnectToStagingDb_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(30, 652);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Connected to...";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(374, 588);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(320, 29);
            this.button10.TabIndex = 14;
            this.button10.Text = "Connect to local database";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.ConnectToLocalDatabase_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(30, 212);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(291, 29);
            this.button11.TabIndex = 15;
            this.button11.Text = "Select orchistrator root folder";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.SelectOrchistratorPath_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(342, 212);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(249, 27);
            this.textBox4.TabIndex = 16;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(30, 260);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(94, 29);
            this.button12.TabIndex = 17;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.StartOrchestrator_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 740);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBoxCommands;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private FolderBrowserDialog folderBrowserDialog1;
        private FolderBrowserDialog folderBrowserDialog2;
        private Button button5;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private Button button6;
        private TextBox textBox3;
        private FolderBrowserDialog folderBrowserDialog3;
        private Button button7;
        private Button button8;
        private Label label1;
        private Button button9;
        private Label label2;
        private Button button10;
        private Button button11;
        private FolderBrowserDialog folderBrowserDialog4;
        private TextBox textBox4;
        private Button button12;
    }
}