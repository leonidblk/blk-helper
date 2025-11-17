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
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog3 = new FolderBrowserDialog();
            vueOrchestratorFolderBrowserDialog = new FolderBrowserDialog();
            eventLogFolderBrowserDialog = new FolderBrowserDialog();
            eventLogVueFolderBrowserDialog = new FolderBrowserDialog();
            tsApiClientFolderBrowserDialog = new FolderBrowserDialog();
            vueWebsiteCoreSection = new PowershellCommands.Controls.VueWebsiteCoreControl();
            orchestratorSection = new PowershellCommands.Controls.OrchestratorPanelControl();
            maintenanceApiSection = new PowershellCommands.Controls.MaintenanceApiPanelControl();
            eventLogSection = new PowershellCommands.Controls.EventLogApiPanelControl();
            eventLogVueSection = new PowershellCommands.Controls.EventLogVueControl();
            tsApiClientSection = new PowershellCommands.Controls.TsApiClientControl();
            SuspendLayout();
            // 
            // vueWebsiteCoreSection
            // 
            vueWebsiteCoreSection.BackColor = Color.WhiteSmoke;
            vueWebsiteCoreSection.ConnectionStatusColor = Color.Red;
            vueWebsiteCoreSection.ConnectionStatusText = "Connected to";
            vueWebsiteCoreSection.Location = new Point(30, 30);
            vueWebsiteCoreSection.Name = "vueWebsiteCoreSection";
            vueWebsiteCoreSection.Size = new Size(703, 240);
            vueWebsiteCoreSection.TabIndex = 0;
            vueWebsiteCoreSection.VueCoreRootPath = "";
            // 
            // orchestratorSection
            // 
            orchestratorSection.BackColor = Color.WhiteSmoke;
            orchestratorSection.Location = new Point(30, 276);
            orchestratorSection.Name = "orchestratorSection";
            orchestratorSection.OrchestratorPath = "";
            orchestratorSection.Size = new Size(703, 170);
            orchestratorSection.TabIndex = 1;
            // 
            // maintenanceApiSection
            // 
            maintenanceApiSection.BackColor = Color.WhiteSmoke;
            maintenanceApiSection.DatabaseConnectionStatusColor = Color.Red;
            maintenanceApiSection.DatabaseConnectionStatusText = "Connected to...";
            maintenanceApiSection.Location = new Point(30, 480);
            maintenanceApiSection.MaintenanceRootPath = "";
            maintenanceApiSection.MigrationName = "";
            maintenanceApiSection.Name = "maintenanceApiSection";
            maintenanceApiSection.Size = new Size(703, 371);
            maintenanceApiSection.TabIndex = 2;
            maintenanceApiSection.Visible = false;
            // 
            // eventLogSection
            // 
            eventLogSection.BackColor = Color.WhiteSmoke;
            eventLogSection.DatabaseConnectionStatusColor = Color.Red;
            eventLogSection.DatabaseConnectionStatusText = "Connected to...";
            eventLogSection.EventLogRootPath = "";
            eventLogSection.Location = new Point(30, 452);
            eventLogSection.MigrationName = "";
            eventLogSection.Name = "eventLogSection";
            eventLogSection.Size = new Size(703, 399);
            eventLogSection.TabIndex = 3;
            // 
            // eventLogVueSection
            // 
            eventLogVueSection.BackColor = Color.WhiteSmoke;
            eventLogVueSection.Location = new Point(748, 30);
            eventLogVueSection.Name = "eventLogVueSection";
            eventLogVueSection.RootPath = "";
            eventLogVueSection.Size = new Size(703, 180);
            eventLogVueSection.TabIndex = 4;
            // 
            // tsApiClientSection
            // 
            tsApiClientSection.BackColor = Color.WhiteSmoke;
            tsApiClientSection.Location = new Point(748, 216);
            tsApiClientSection.Name = "tsApiClientSection";
            tsApiClientSection.RootPath = "";
            tsApiClientSection.Size = new Size(703, 301);
            tsApiClientSection.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1588, 869);
            Controls.Add(tsApiClientSection);
            Controls.Add(eventLogVueSection);
            Controls.Add(eventLogSection);
            Controls.Add(maintenanceApiSection);
            Controls.Add(orchestratorSection);
            Controls.Add(vueWebsiteCoreSection);
            Name = "Form1";
            Text = "Blk Helper";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog3;
        private System.Windows.Forms.FolderBrowserDialog vueOrchestratorFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog eventLogFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog eventLogVueFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog tsApiClientFolderBrowserDialog;
        private Controls.VueWebsiteCoreControl vueWebsiteCoreSection;
        private Controls.OrchestratorPanelControl orchestratorSection;
        private Controls.MaintenanceApiPanelControl maintenanceApiSection;
        private Controls.EventLogApiPanelControl eventLogSection;
        private Controls.EventLogVueControl eventLogVueSection;
        private Controls.TsApiClientControl tsApiClientSection;
    }
}
