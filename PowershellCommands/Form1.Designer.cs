using MaterialSkin;
using MaterialSkin.Controls;

namespace PowershellCommands
{
    partial class Form1 : MaterialForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MaterialSkinManager materialSkinManager;

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
            // Initialize Material Skin Manager
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.startVueWebsiteButton = new MaterialSkin.Controls.MaterialButton();
            this.button2 = new MaterialSkin.Controls.MaterialButton();
            this.button3 = new MaterialSkin.Controls.MaterialButton();
            this.button4 = new MaterialSkin.Controls.MaterialButton();
            this.textBox1 = new MaterialSkin.Controls.MaterialTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button5 = new MaterialSkin.Controls.MaterialButton();
            this.maintenanceRootPathTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new MaterialSkin.Controls.MaterialButton();
            this.vueCoreRootPathTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.button7 = new MaterialSkin.Controls.MaterialButton();
            this.button8 = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.button9 = new MaterialSkin.Controls.MaterialButton();
            this.maintDbConnectionStatusLable = new MaterialSkin.Controls.MaterialLabel();
            this.button10 = new MaterialSkin.Controls.MaterialButton();
            this.button11 = new MaterialSkin.Controls.MaterialButton();
            this.vueOrchestratorFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.vueOrchestratorPathTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.button12 = new MaterialSkin.Controls.MaterialButton();
            this.maintApiConnectionStatusLablel = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startVueWebsiteButton
            // 
            this.startVueWebsiteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startVueWebsiteButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.startVueWebsiteButton.Depth = 0;
            this.startVueWebsiteButton.HighEmphasis = true;
            this.startVueWebsiteButton.Icon = null;
            this.startVueWebsiteButton.Location = new System.Drawing.Point(34, 224);
            this.startVueWebsiteButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.startVueWebsiteButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.startVueWebsiteButton.Name = "startVueWebsiteButton";
            this.startVueWebsiteButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.startVueWebsiteButton.Size = new System.Drawing.Size(163, 36);
            this.startVueWebsiteButton.TabIndex = 0;
            this.startVueWebsiteButton.Text = "Start Vue website";
            this.startVueWebsiteButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.startVueWebsiteButton.UseAccentColor = false;
            this.startVueWebsiteButton.UseVisualStyleBackColor = true;
            this.startVueWebsiteButton.Click += new System.EventHandler(this.ButtonRunCoreMicro_Click);
            // 
            // button2
            // 
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button2.Depth = 0;
            this.button2.HighEmphasis = true;
            this.button2.Icon = null;
            this.button2.Location = new System.Drawing.Point(30, 532);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button2.MouseState = MaterialSkin.MouseState.HOVER;
            this.button2.Name = "button2";
            this.button2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button2.Size = new System.Drawing.Size(241, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Run Maintenance migration";
            this.button2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button2.UseAccentColor = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonMaintenanceMigration_Click);
            // 
            // button3
            // 
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button3.Depth = 0;
            this.button3.HighEmphasis = true;
            this.button3.Icon = null;
            this.button3.Location = new System.Drawing.Point(30, 582);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button3.MouseState = MaterialSkin.MouseState.HOVER;
            this.button3.Name = "button3";
            this.button3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button3.Size = new System.Drawing.Size(185, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "Run Maintenance API";
            this.button3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button3.UseAccentColor = false;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonRunMaintApi_Click);
            // 
            // button4
            // 
            this.button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button4.Depth = 0;
            this.button4.HighEmphasis = true;
            this.button4.Icon = null;
            this.button4.Location = new System.Drawing.Point(30, 638);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button4.MouseState = MaterialSkin.MouseState.HOVER;
            this.button4.Name = "button4";
            this.button4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button4.Size = new System.Drawing.Size(134, 36);
            this.button4.TabIndex = 3;
            this.button4.Text = "Add migration";
            this.button4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button4.UseAccentColor = false;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ButtonAddMigration_Click);
            // 
            // textBox1
            // 
            this.textBox1.AnimateReadOnly = false;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Depth = 0;
            this.textBox1.Font = new System.Drawing.Font("Roboto", 9.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.LeadingIcon = null;
            this.textBox1.Location = new System.Drawing.Point(236, 640);
            this.textBox1.MaxLength = 50;
            this.textBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 50);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Migration name";
            this.textBox1.TrailingIcon = null;
            // 
            // button5
            // 
            this.button5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button5.Depth = 0;
            this.button5.HighEmphasis = true;
            this.button5.Icon = null;
            this.button5.Location = new System.Drawing.Point(30, 480);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button5.MouseState = MaterialSkin.MouseState.HOVER;
            this.button5.Name = "button5";
            this.button5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button5.Size = new System.Drawing.Size(280, 36);
            this.button5.TabIndex = 4;
            this.button5.Text = "Select Maintenance Root Folder";
            this.button5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button5.UseAccentColor = false;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ButtonSaveMaintenanceRootPath_Click);
            // 
            // maintenanceRootPathTextBox
            // 
            this.maintenanceRootPathTextBox.AnimateReadOnly = false;
            this.maintenanceRootPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maintenanceRootPathTextBox.Depth = 0;
            this.maintenanceRootPathTextBox.Font = new System.Drawing.Font("Roboto", 9.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maintenanceRootPathTextBox.LeadingIcon = null;
            this.maintenanceRootPathTextBox.Location = new System.Drawing.Point(334, 480);
            this.maintenanceRootPathTextBox.MaxLength = 50;
            this.maintenanceRootPathTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.maintenanceRootPathTextBox.Multiline = false;
            this.maintenanceRootPathTextBox.Name = "maintenanceRootPathTextBox";
            this.maintenanceRootPathTextBox.ReadOnly = true;
            this.maintenanceRootPathTextBox.Size = new System.Drawing.Size(225, 50);
            this.maintenanceRootPathTextBox.TabIndex = 5;
            this.maintenanceRootPathTextBox.Text = "Root path is empty";
            this.maintenanceRootPathTextBox.TrailingIcon = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(557, 399);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 65);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button6.Depth = 0;
            this.button6.HighEmphasis = true;
            this.button6.Icon = null;
            this.button6.Location = new System.Drawing.Point(34, 113);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button6.MouseState = MaterialSkin.MouseState.HOVER;
            this.button6.Name = "button6";
            this.button6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button6.Size = new System.Drawing.Size(264, 36);
            this.button6.TabIndex = 7;
            this.button6.Text = "Select Core Micro Root Folder";
            this.button6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button6.UseAccentColor = false;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ButtonSaveVueCoreMicroRootPath_Click);
            // 
            // vueCoreRootPathTextBox
            // 
            this.vueCoreRootPathTextBox.AnimateReadOnly = false;
            this.vueCoreRootPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vueCoreRootPathTextBox.Depth = 0;
            this.vueCoreRootPathTextBox.Font = new System.Drawing.Font("Roboto", 9.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vueCoreRootPathTextBox.LeadingIcon = null;
            this.vueCoreRootPathTextBox.Location = new System.Drawing.Point(349, 113);
            this.vueCoreRootPathTextBox.MaxLength = 50;
            this.vueCoreRootPathTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.vueCoreRootPathTextBox.Multiline = false;
            this.vueCoreRootPathTextBox.Name = "vueCoreRootPathTextBox";
            this.vueCoreRootPathTextBox.ReadOnly = true;
            this.vueCoreRootPathTextBox.Size = new System.Drawing.Size(246, 50);
            this.vueCoreRootPathTextBox.TabIndex = 8;
            this.vueCoreRootPathTextBox.Text = "Root path is empty";
            this.vueCoreRootPathTextBox.TrailingIcon = null;
            // 
            // button7
            // 
            this.button7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button7.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button7.Depth = 0;
            this.button7.HighEmphasis = true;
            this.button7.Icon = null;
            this.button7.Location = new System.Drawing.Point(34, 173);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button7.MouseState = MaterialSkin.MouseState.HOVER;
            this.button7.Name = "button7";
            this.button7.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button7.Size = new System.Drawing.Size(312, 36);
            this.button7.TabIndex = 9;
            this.button7.Text = "Connect to staging maintenance api";
            this.button7.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button7.UseAccentColor = false;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ButtonConnectStagingMaintApi_Click);
            // 
            // button8
            // 
            this.button8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button8.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button8.Depth = 0;
            this.button8.HighEmphasis = true;
            this.button8.Icon = null;
            this.button8.Location = new System.Drawing.Point(374, 173);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button8.MouseState = MaterialSkin.MouseState.HOVER;
            this.button8.Name = "button8";
            this.button8.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button8.Size = new System.Drawing.Size(295, 36);
            this.button8.TabIndex = 10;
            this.button8.Text = "Connect to local maintenance api";
            this.button8.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button8.UseAccentColor = false;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ButtonConnectLocalMaintApi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(247, 618);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Migration name";
            // 
            // button9
            // 
            this.button9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button9.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button9.Depth = 0;
            this.button9.HighEmphasis = true;
            this.button9.Icon = null;
            this.button9.Location = new System.Drawing.Point(30, 702);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button9.MouseState = MaterialSkin.MouseState.HOVER;
            this.button9.Name = "button9";
            this.button9.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button9.Size = new System.Drawing.Size(256, 36);
            this.button9.TabIndex = 12;
            this.button9.Text = "Connect to staging database";
            this.button9.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button9.UseAccentColor = false;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.ConnectToStagingDb_Click);
            // 
            // maintDbConnectionStatusLable
            // 
            this.maintDbConnectionStatusLable.AutoSize = true;
            this.maintDbConnectionStatusLable.Depth = 0;
            this.maintDbConnectionStatusLable.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.maintDbConnectionStatusLable.ForeColor = System.Drawing.Color.Red;
            this.maintDbConnectionStatusLable.Location = new System.Drawing.Point(30, 766);
            this.maintDbConnectionStatusLable.MouseState = MaterialSkin.MouseState.HOVER;
            this.maintDbConnectionStatusLable.Name = "maintDbConnectionStatusLable";
            this.maintDbConnectionStatusLable.Size = new System.Drawing.Size(106, 19);
            this.maintDbConnectionStatusLable.TabIndex = 13;
            this.maintDbConnectionStatusLable.Text = "Connected to...";
            // 
            // button10
            // 
            this.button10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button10.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button10.Depth = 0;
            this.button10.HighEmphasis = true;
            this.button10.Icon = null;
            this.button10.Location = new System.Drawing.Point(320, 702);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button10.MouseState = MaterialSkin.MouseState.HOVER;
            this.button10.Name = "button10";
            this.button10.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button10.Size = new System.Drawing.Size(239, 36);
            this.button10.TabIndex = 14;
            this.button10.Text = "Connect to local database";
            this.button10.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button10.UseAccentColor = false;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.ConnectToLocalDatabase_Click);
            // 
            // button11
            // 
            this.button11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button11.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button11.Depth = 0;
            this.button11.HighEmphasis = true;
            this.button11.Icon = null;
            this.button11.Location = new System.Drawing.Point(34, 293);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button11.MouseState = MaterialSkin.MouseState.HOVER;
            this.button11.Name = "button11";
            this.button11.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button11.Size = new System.Drawing.Size(285, 36);
            this.button11.TabIndex = 15;
            this.button11.Text = "Select orchistrator root folder";
            this.button11.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button11.UseAccentColor = false;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.SelectOrchistratorPath_Click);
            // 
            // vueOrchestratorPathTextBox
            // 
            this.vueOrchestratorPathTextBox.AnimateReadOnly = false;
            this.vueOrchestratorPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vueOrchestratorPathTextBox.Depth = 0;
            this.vueOrchestratorPathTextBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.vueOrchestratorPathTextBox.LeadingIcon = null;
            this.vueOrchestratorPathTextBox.Location = new System.Drawing.Point(346, 293);
            this.vueOrchestratorPathTextBox.MaxLength = 50;
            this.vueOrchestratorPathTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.vueOrchestratorPathTextBox.Multiline = false;
            this.vueOrchestratorPathTextBox.Name = "vueOrchestratorPathTextBox";
            this.vueOrchestratorPathTextBox.ReadOnly = true;
            this.vueOrchestratorPathTextBox.Size = new System.Drawing.Size(249, 50);
            this.vueOrchestratorPathTextBox.TabIndex = 16;
            this.vueOrchestratorPathTextBox.Text = "";
            this.vueOrchestratorPathTextBox.TrailingIcon = null;
            // 
            // button12
            // 
            this.button12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button12.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button12.Depth = 0;
            this.button12.HighEmphasis = true;
            this.button12.Icon = null;
            this.button12.Location = new System.Drawing.Point(34, 357);
            this.button12.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button12.MouseState = MaterialSkin.MouseState.HOVER;
            this.button12.Name = "button12";
            this.button12.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button12.Size = new System.Drawing.Size(183, 36);
            this.button12.TabIndex = 17;
            this.button12.Text = "Start Orchestrator";
            this.button12.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button12.UseAccentColor = false;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.StartOrchestrator_Click);
            // 
            // maintApiConnectionStatusLablel
            // 
            this.maintApiConnectionStatusLablel.AutoSize = true;
            this.maintApiConnectionStatusLablel.Depth = 0;
            this.maintApiConnectionStatusLablel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.maintApiConnectionStatusLablel.ForeColor = System.Drawing.Color.Red;
            this.maintApiConnectionStatusLablel.Location = new System.Drawing.Point(34, 408);
            this.maintApiConnectionStatusLablel.MouseState = MaterialSkin.MouseState.HOVER;
            this.maintApiConnectionStatusLablel.Name = "maintApiConnectionStatusLablel";
            this.maintApiConnectionStatusLablel.Size = new System.Drawing.Size(94, 19);
            this.maintApiConnectionStatusLablel.TabIndex = 18;
            this.maintApiConnectionStatusLablel.Text = "Connected to";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 862);
            this.Controls.Add(this.maintApiConnectionStatusLablel);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.vueOrchestratorPathTextBox);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.maintDbConnectionStatusLable);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.vueCoreRootPathTextBox);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.maintenanceRootPathTextBox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.startVueWebsiteButton);
            this.Name = "Form1";
            this.Text = "Blk Helper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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

        private MaterialSkin.Controls.MaterialListBox listBoxCommands; // MaterialSkin equivalent for ListBox
        private MaterialSkin.Controls.MaterialButton startVueWebsiteButton;
        private MaterialSkin.Controls.MaterialButton button2;
        private MaterialSkin.Controls.MaterialButton button3;
        private MaterialSkin.Controls.MaterialButton button4;
        private MaterialSkin.Controls.MaterialTextBox textBox1;
        private FolderBrowserDialog folderBrowserDialog1; // No MaterialSkin equivalent
        private FolderBrowserDialog folderBrowserDialog2; // No MaterialSkin equivalent
        private MaterialSkin.Controls.MaterialButton button5;
        private MaterialSkin.Controls.MaterialTextBox maintenanceRootPathTextBox;
        private PictureBox pictureBox1; // No MaterialSkin equivalent
        private MaterialSkin.Controls.MaterialButton button6;
        private MaterialSkin.Controls.MaterialTextBox vueCoreRootPathTextBox;
        private FolderBrowserDialog folderBrowserDialog3; // No MaterialSkin equivalent
        private MaterialSkin.Controls.MaterialButton button7;
        private MaterialSkin.Controls.MaterialButton button8;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialButton button9;
        private MaterialSkin.Controls.MaterialLabel maintDbConnectionStatusLable;
        private MaterialSkin.Controls.MaterialButton button10;
        private MaterialSkin.Controls.MaterialButton button11;
        private FolderBrowserDialog vueOrchestratorFolderBrowserDialog; // No MaterialSkin equivalent
        private MaterialSkin.Controls.MaterialTextBox vueOrchestratorPathTextBox;
        private MaterialSkin.Controls.MaterialButton button12;
        private MaterialSkin.Controls.MaterialLabel maintApiConnectionStatusLablel;

    }
}