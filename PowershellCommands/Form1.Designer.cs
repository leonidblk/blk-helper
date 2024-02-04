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
            this.startVueWebsiteButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.maintenanceRootPathTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.vueCoreRootPathTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.maintDbConnectionStatusLable = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.vueOrchestratorFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.vueOrchestratorPathTextBox = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.maintApiConnectionStatusLablel = new System.Windows.Forms.Label();
            this.vueWebsiteCorePanel = new System.Windows.Forms.Panel();
            this.orchistratorPanel = new System.Windows.Forms.Panel();
            this.maintenanceApiPanel = new System.Windows.Forms.Panel();
            this.vueWebsiteCoreLabel = new System.Windows.Forms.Label();
            this.OrchistratorLabel = new System.Windows.Forms.Label();
            this.MaintenanceApiLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.vueWebsiteCorePanel.SuspendLayout();
            this.orchistratorPanel.SuspendLayout();
            this.maintenanceApiPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startVueWebsiteButton
            // 
            this.startVueWebsiteButton.Location = new System.Drawing.Point(26, 143);
            this.startVueWebsiteButton.Name = "startVueWebsiteButton";
            this.startVueWebsiteButton.Size = new System.Drawing.Size(200, 35);
            this.startVueWebsiteButton.TabIndex = 0;
            this.startVueWebsiteButton.Text = "Start Vue website";
            this.startVueWebsiteButton.UseVisualStyleBackColor = true;
            this.startVueWebsiteButton.Click += new System.EventHandler(this.ButtonRunCoreMicro_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(217, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Run Maintenance migration";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonMaintenanceMigration_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "Run Maintenance API";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonRunMaintApi_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(26, 184);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 33);
            this.button4.TabIndex = 3;
            this.button4.Text = "Add migration";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ButtonAddMigration_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(232, 186);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Migration name";
            this.textBox1.Size = new System.Drawing.Size(200, 27);
            this.textBox1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(26, 26);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(273, 35);
            this.button5.TabIndex = 4;
            this.button5.Text = "Select Maintenance Root Folder";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ButtonSaveMaintenanceRootPath_Click);
            // 
            // maintenanceRootPathTextBox
            // 
            this.maintenanceRootPathTextBox.Location = new System.Drawing.Point(305, 29);
            this.maintenanceRootPathTextBox.Name = "maintenanceRootPathTextBox";
            this.maintenanceRootPathTextBox.PlaceholderText = "Root path is empty";
            this.maintenanceRootPathTextBox.ReadOnly = true;
            this.maintenanceRootPathTextBox.Size = new System.Drawing.Size(238, 27);
            this.maintenanceRootPathTextBox.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(549, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 64);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(26, 33);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 34);
            this.button6.TabIndex = 7;
            this.button6.Text = "Select Core Micro Root Folder";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ButtonSaveVueCoreMicroRootPath_Click);
            // 
            // vueCoreRootPathTextBox
            // 
            this.vueCoreRootPathTextBox.Location = new System.Drawing.Point(241, 37);
            this.vueCoreRootPathTextBox.Name = "vueCoreRootPathTextBox";
            this.vueCoreRootPathTextBox.PlaceholderText = "Root path is empty";
            this.vueCoreRootPathTextBox.ReadOnly = true;
            this.vueCoreRootPathTextBox.Size = new System.Drawing.Size(246, 27);
            this.vueCoreRootPathTextBox.TabIndex = 8;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(26, 92);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(291, 29);
            this.button7.TabIndex = 9;
            this.button7.Text = "Connect to staging maintenance api";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ButtonConnectStagingMaintApi_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(338, 92);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(265, 29);
            this.button8.TabIndex = 10;
            this.button8.Text = "Connect to local maintenance api";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ButtonConnectLocalMaintApi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Migration name";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(26, 248);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(291, 29);
            this.button9.TabIndex = 12;
            this.button9.Text = "Connect to staging database";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.ConnectToStagingDb_Click);
            // 
            // maintDbConnectionStatusLable
            // 
            this.maintDbConnectionStatusLable.AutoSize = true;
            this.maintDbConnectionStatusLable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.maintDbConnectionStatusLable.ForeColor = System.Drawing.Color.Red;
            this.maintDbConnectionStatusLable.Location = new System.Drawing.Point(26, 312);
            this.maintDbConnectionStatusLable.Name = "maintDbConnectionStatusLable";
            this.maintDbConnectionStatusLable.Size = new System.Drawing.Size(114, 20);
            this.maintDbConnectionStatusLable.TabIndex = 13;
            this.maintDbConnectionStatusLable.Text = "Connected to...";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(328, 248);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(320, 29);
            this.button10.TabIndex = 14;
            this.button10.Text = "Connect to local database";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.ConnectToLocalDatabase_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(26, 30);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(291, 29);
            this.button11.TabIndex = 15;
            this.button11.Text = "Select orchistrator root folder";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.SelectOrchistratorPath_Click);
            // 
            // vueOrchestratorPathTextBox
            // 
            this.vueOrchestratorPathTextBox.Location = new System.Drawing.Point(338, 30);
            this.vueOrchestratorPathTextBox.Name = "vueOrchestratorPathTextBox";
            this.vueOrchestratorPathTextBox.ReadOnly = true;
            this.vueOrchestratorPathTextBox.Size = new System.Drawing.Size(249, 27);
            this.vueOrchestratorPathTextBox.TabIndex = 16;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(26, 78);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(217, 29);
            this.button12.TabIndex = 17;
            this.button12.Text = "Start Orchestrator";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.StartOrchestrator_Click);
            // 
            // maintApiConnectionStatusLablel
            // 
            this.maintApiConnectionStatusLablel.AutoSize = true;
            this.maintApiConnectionStatusLablel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.maintApiConnectionStatusLablel.ForeColor = System.Drawing.Color.Red;
            this.maintApiConnectionStatusLablel.Location = new System.Drawing.Point(287, 150);
            this.maintApiConnectionStatusLablel.Name = "maintApiConnectionStatusLablel";
            this.maintApiConnectionStatusLablel.Size = new System.Drawing.Size(102, 20);
            this.maintApiConnectionStatusLablel.TabIndex = 18;
            this.maintApiConnectionStatusLablel.Text = "Connected to";
            // 
            // vueWebsiteCorePanel
            // 
            this.vueWebsiteCorePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.vueWebsiteCorePanel.Controls.Add(this.startVueWebsiteButton);
            this.vueWebsiteCorePanel.Controls.Add(this.maintApiConnectionStatusLablel);
            this.vueWebsiteCorePanel.Controls.Add(this.button6);
            this.vueWebsiteCorePanel.Controls.Add(this.vueCoreRootPathTextBox);
            this.vueWebsiteCorePanel.Controls.Add(this.button7);
            this.vueWebsiteCorePanel.Controls.Add(this.button8);
            this.vueWebsiteCorePanel.Location = new System.Drawing.Point(30, 83);
            this.vueWebsiteCorePanel.Name = "vueWebsiteCorePanel";
            this.vueWebsiteCorePanel.Size = new System.Drawing.Size(703, 212);
            this.vueWebsiteCorePanel.TabIndex = 19;
            // 
            // orchistratorPanel
            // 
            this.orchistratorPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.orchistratorPanel.Controls.Add(this.button12);
            this.orchistratorPanel.Controls.Add(this.button11);
            this.orchistratorPanel.Controls.Add(this.vueOrchestratorPathTextBox);
            this.orchistratorPanel.Location = new System.Drawing.Point(30, 375);
            this.orchistratorPanel.Name = "orchistratorPanel";
            this.orchistratorPanel.Size = new System.Drawing.Size(703, 141);
            this.orchistratorPanel.TabIndex = 20;
            // 
            // maintenanceApiPanel
            // 
            this.maintenanceApiPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.maintenanceApiPanel.Controls.Add(this.button5);
            this.maintenanceApiPanel.Controls.Add(this.button2);
            this.maintenanceApiPanel.Controls.Add(this.button3);
            this.maintenanceApiPanel.Controls.Add(this.label1);
            this.maintenanceApiPanel.Controls.Add(this.button10);
            this.maintenanceApiPanel.Controls.Add(this.button4);
            this.maintenanceApiPanel.Controls.Add(this.maintDbConnectionStatusLable);
            this.maintenanceApiPanel.Controls.Add(this.textBox1);
            this.maintenanceApiPanel.Controls.Add(this.button9);
            this.maintenanceApiPanel.Controls.Add(this.maintenanceRootPathTextBox);
            this.maintenanceApiPanel.Controls.Add(this.pictureBox1);
            this.maintenanceApiPanel.Location = new System.Drawing.Point(30, 597);
            this.maintenanceApiPanel.Name = "maintenanceApiPanel";
            this.maintenanceApiPanel.Size = new System.Drawing.Size(703, 358);
            this.maintenanceApiPanel.TabIndex = 21;
            // 
            // vueWebsiteCoreLabel
            // 
            this.vueWebsiteCoreLabel.AutoSize = true;
            this.vueWebsiteCoreLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vueWebsiteCoreLabel.Location = new System.Drawing.Point(30, 49);
            this.vueWebsiteCoreLabel.Name = "vueWebsiteCoreLabel";
            this.vueWebsiteCoreLabel.Size = new System.Drawing.Size(193, 31);
            this.vueWebsiteCoreLabel.TabIndex = 19;
            this.vueWebsiteCoreLabel.Text = "Vue Website Core";
            // 
            // OrchistratorLabel
            // 
            this.OrchistratorLabel.AutoSize = true;
            this.OrchistratorLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OrchistratorLabel.Location = new System.Drawing.Point(30, 341);
            this.OrchistratorLabel.Name = "OrchistratorLabel";
            this.OrchistratorLabel.Size = new System.Drawing.Size(136, 31);
            this.OrchistratorLabel.TabIndex = 18;
            this.OrchistratorLabel.Text = "Orchistrator";
            // 
            // MaintenanceApiLabel
            // 
            this.MaintenanceApiLabel.AutoSize = true;
            this.MaintenanceApiLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaintenanceApiLabel.Location = new System.Drawing.Point(30, 563);
            this.MaintenanceApiLabel.Name = "MaintenanceApiLabel";
            this.MaintenanceApiLabel.Size = new System.Drawing.Size(187, 31);
            this.MaintenanceApiLabel.TabIndex = 15;
            this.MaintenanceApiLabel.Text = "Maintenance API";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(766, 992);
            this.Controls.Add(this.MaintenanceApiLabel);
            this.Controls.Add(this.OrchistratorLabel);
            this.Controls.Add(this.vueWebsiteCoreLabel);
            this.Controls.Add(this.maintenanceApiPanel);
            this.Controls.Add(this.orchistratorPanel);
            this.Controls.Add(this.vueWebsiteCorePanel);
            this.Name = "Form1";
            this.Text = "Blk Helper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.vueWebsiteCorePanel.ResumeLayout(false);
            this.vueWebsiteCorePanel.PerformLayout();
            this.orchistratorPanel.ResumeLayout(false);
            this.orchistratorPanel.PerformLayout();
            this.maintenanceApiPanel.ResumeLayout(false);
            this.maintenanceApiPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeButtons()
        {
            int standardButtonHeight = 30;
            this.startVueWebsiteButton.Size = new Size(this.startVueWebsiteButton.Size.Width, standardButtonHeight);
            this.button2.Size = new Size(this.button2.Size.Width, standardButtonHeight);
            this.button3.Size = new Size(this.button3.Size.Width, standardButtonHeight);
            this.button4.Size = new Size(this.button4.Size.Width, standardButtonHeight);
            this.button5.Size = new Size(this.button5.Size.Width, standardButtonHeight);
            this.button6.Size = new Size(this.button6.Size.Width, standardButtonHeight);
            this.button7.Size = new Size(this.button7.Size.Width, standardButtonHeight);
            this.button8.Size = new Size(this.button8.Size.Width, standardButtonHeight);
            this.button9.Size = new Size(this.button9.Size.Width, standardButtonHeight);
            this.button10.Size = new Size(this.button10.Size.Width, standardButtonHeight);
            this.button11.Size = new Size(this.button11.Size.Width, standardButtonHeight);
            this.button12.Size = new Size(this.button12.Size.Width, standardButtonHeight);
        }

        #endregion

        private ListBox listBoxCommands;
        private Button startVueWebsiteButton;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private FolderBrowserDialog folderBrowserDialog1;
        private FolderBrowserDialog folderBrowserDialog2;
        private Button button5;
        private TextBox maintenanceRootPathTextBox;
        private PictureBox pictureBox1;
        private Button button6;
        private TextBox vueCoreRootPathTextBox;
        private FolderBrowserDialog folderBrowserDialog3;
        private Button button7;
        private Button button8;
        private Label label1;
        private Button button9;
        private Label maintDbConnectionStatusLable;
        private Button button10;
        private Button button11;
        private FolderBrowserDialog vueOrchestratorFolderBrowserDialog;
        private TextBox vueOrchestratorPathTextBox;
        private Button button12;
        private Label maintApiConnectionStatusLablel;
        private Panel vueWebsiteCorePanel;
        private Panel orchistratorPanel;
        private Panel maintenanceApiPanel;
        private Label vueWebsiteCoreLabel;
        private Label OrchistratorLabel;
        private Label MaintenanceApiLabel;
    }
}