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

        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.vueOrchestratorFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.eventLogFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.eventLogVueFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.vueWebsiteCoreSection = new PowershellCommands.Controls.VueWebsiteCoreControl();
            this.orchestratorSection = new PowershellCommands.Controls.OrchestratorPanelControl();
            this.maintenanceApiSection = new PowershellCommands.Controls.MaintenanceApiPanelControl();
            this.eventLogSection = new PowershellCommands.Controls.EventLogApiPanelControl();
            this.eventLogVueSection = new PowershellCommands.Controls.EventLogVueControl();
            this.SuspendLayout();
            // 
            // vueWebsiteCoreSection
            // 
            this.vueWebsiteCoreSection.Location = new System.Drawing.Point(30, 30);
            this.vueWebsiteCoreSection.Name = "vueWebsiteCoreSection";
            this.vueWebsiteCoreSection.Size = new System.Drawing.Size(703, 240);
            this.vueWebsiteCoreSection.TabIndex = 0;
            // 
            // orchestratorSection
            // 
            this.orchestratorSection.Location = new System.Drawing.Point(30, 300);
            this.orchestratorSection.Name = "orchestratorSection";
            this.orchestratorSection.Size = new System.Drawing.Size(703, 170);
            this.orchestratorSection.TabIndex = 1;
            // 
            // maintenanceApiSection
            // 
            this.maintenanceApiSection.Location = new System.Drawing.Point(30, 480);
            this.maintenanceApiSection.Name = "maintenanceApiSection";
            this.maintenanceApiSection.Size = new System.Drawing.Size(703, 420);
            this.maintenanceApiSection.TabIndex = 2;
            this.maintenanceApiSection.Visible = false;
            // 
            // eventLogSection
            // 
            this.eventLogSection.Location = new System.Drawing.Point(30, 480);
            this.eventLogSection.Name = "eventLogSection";
            this.eventLogSection.Size = new System.Drawing.Size(703, 420);
            this.eventLogSection.TabIndex = 3;
            // 
            // eventLogVueSection
            // 
            this.eventLogVueSection.Location = new System.Drawing.Point(30, 930);
            this.eventLogVueSection.Name = "eventLogVueSection";
            this.eventLogVueSection.Size = new System.Drawing.Size(703, 180);
            this.eventLogVueSection.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(766, 1140);
            this.Controls.Add(this.eventLogVueSection);
            this.Controls.Add(this.eventLogSection);
            this.Controls.Add(this.maintenanceApiSection);
            this.Controls.Add(this.orchestratorSection);
            this.Controls.Add(this.vueWebsiteCoreSection);
            this.Name = "Form1";
            this.Text = "Blk Helper";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog3;
        private System.Windows.Forms.FolderBrowserDialog vueOrchestratorFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog eventLogFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog eventLogVueFolderBrowserDialog;
        private Controls.VueWebsiteCoreControl vueWebsiteCoreSection;
        private Controls.OrchestratorPanelControl orchestratorSection;
        private Controls.MaintenanceApiPanelControl maintenanceApiSection;
        private Controls.EventLogApiPanelControl eventLogSection;
        private Controls.EventLogVueControl eventLogVueSection;
    }
}
