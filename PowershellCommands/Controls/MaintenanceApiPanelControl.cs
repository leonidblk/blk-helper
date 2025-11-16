using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowershellCommands.Controls
{
    public partial class MaintenanceApiPanelControl : UserControl
    {
        private readonly Label headerLabel;
        private readonly Button selectMaintenanceRootButton;
        private readonly TextBox maintenanceRootPathTextBox;
        private readonly Button runMaintenanceMigrationButton;
        private readonly Button runMaintenanceApiButton;
        private readonly Button addMigrationButton;
        private readonly TextBox migrationNameTextBox;
        private readonly Label migrationNameLabel;
        private readonly Button connectToStagingDbButton;
        private readonly Button connectToLocalDbButton;
        private readonly Label databaseConnectionStatusLabel;
        private readonly PictureBox logoPictureBox;

        public event EventHandler? SelectMaintenanceRootClicked;
        public event EventHandler? RunMaintenanceMigrationClicked;
        public event EventHandler? RunMaintenanceApiClicked;
        public event EventHandler? AddMigrationClicked;
        public event EventHandler? ConnectToStagingDatabaseClicked;
        public event EventHandler? ConnectToLocalDatabaseClicked;

        public string MaintenanceRootPath
        {
            get => maintenanceRootPathTextBox.Text;
            set => maintenanceRootPathTextBox.Text = value;
        }

        public string MigrationName
        {
            get => migrationNameTextBox.Text;
            set => migrationNameTextBox.Text = value;
        }

        public string DatabaseConnectionStatusText
        {
            get => databaseConnectionStatusLabel.Text;
            set => databaseConnectionStatusLabel.Text = value;
        }

        public Color DatabaseConnectionStatusColor
        {
            get => databaseConnectionStatusLabel.ForeColor;
            set => databaseConnectionStatusLabel.ForeColor = value;
        }

        public MaintenanceApiPanelControl()
        {
            headerLabel = new Label();
            selectMaintenanceRootButton = new Button();
            maintenanceRootPathTextBox = new TextBox();
            runMaintenanceMigrationButton = new Button();
            runMaintenanceApiButton = new Button();
            addMigrationButton = new Button();
            migrationNameTextBox = new TextBox();
            migrationNameLabel = new Label();
            connectToStagingDbButton = new Button();
            connectToLocalDbButton = new Button();
            databaseConnectionStatusLabel = new Label();
            logoPictureBox = new PictureBox();

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel.Location = new Point(0, 0);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(187, 31);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Maintenance API";
            // 
            // selectMaintenanceRootButton
            // 
            selectMaintenanceRootButton.Location = new Point(26, 55);
            selectMaintenanceRootButton.Name = "selectMaintenanceRootButton";
            selectMaintenanceRootButton.Size = new Size(273, 35);
            selectMaintenanceRootButton.TabIndex = 1;
            selectMaintenanceRootButton.Text = "Select Maintenance Root Folder";
            selectMaintenanceRootButton.UseVisualStyleBackColor = true;
            selectMaintenanceRootButton.Click += (_, __) => SelectMaintenanceRootClicked?.Invoke(this, EventArgs.Empty);
            // 
            // maintenanceRootPathTextBox
            // 
            maintenanceRootPathTextBox.Location = new Point(305, 58);
            maintenanceRootPathTextBox.Name = "maintenanceRootPathTextBox";
            maintenanceRootPathTextBox.PlaceholderText = "Root path is empty";
            maintenanceRootPathTextBox.ReadOnly = true;
            maintenanceRootPathTextBox.Size = new Size(238, 27);
            maintenanceRootPathTextBox.TabIndex = 2;
            // 
            // runMaintenanceMigrationButton
            // 
            runMaintenanceMigrationButton.Location = new Point(26, 110);
            runMaintenanceMigrationButton.Name = "runMaintenanceMigrationButton";
            runMaintenanceMigrationButton.Size = new Size(217, 39);
            runMaintenanceMigrationButton.TabIndex = 3;
            runMaintenanceMigrationButton.Text = "Run Maintenance migration";
            runMaintenanceMigrationButton.UseVisualStyleBackColor = true;
            runMaintenanceMigrationButton.Click += (_, __) => RunMaintenanceMigrationClicked?.Invoke(this, EventArgs.Empty);
            // 
            // runMaintenanceApiButton
            // 
            runMaintenanceApiButton.Location = new Point(26, 160);
            runMaintenanceApiButton.Name = "runMaintenanceApiButton";
            runMaintenanceApiButton.Size = new Size(200, 39);
            runMaintenanceApiButton.TabIndex = 4;
            runMaintenanceApiButton.Text = "Run Maintenance API";
            runMaintenanceApiButton.UseVisualStyleBackColor = true;
            runMaintenanceApiButton.Click += (_, __) => RunMaintenanceApiClicked?.Invoke(this, EventArgs.Empty);
            // 
            // addMigrationButton
            // 
            addMigrationButton.Location = new Point(26, 216);
            addMigrationButton.Name = "addMigrationButton";
            addMigrationButton.Size = new Size(200, 33);
            addMigrationButton.TabIndex = 5;
            addMigrationButton.Text = "Add migration";
            addMigrationButton.UseVisualStyleBackColor = true;
            addMigrationButton.Click += (_, __) => AddMigrationClicked?.Invoke(this, EventArgs.Empty);
            // 
            // migrationNameTextBox
            // 
            migrationNameTextBox.Location = new Point(232, 218);
            migrationNameTextBox.Name = "migrationNameTextBox";
            migrationNameTextBox.PlaceholderText = "Migration name";
            migrationNameTextBox.Size = new Size(200, 27);
            migrationNameTextBox.TabIndex = 6;
            // 
            // migrationNameLabel
            // 
            migrationNameLabel.AutoSize = true;
            migrationNameLabel.Location = new Point(232, 195);
            migrationNameLabel.Name = "migrationNameLabel";
            migrationNameLabel.Size = new Size(115, 20);
            migrationNameLabel.TabIndex = 7;
            migrationNameLabel.Text = "Migration name";
            // 
            // connectToStagingDbButton
            // 
            connectToStagingDbButton.Location = new Point(26, 302);
            connectToStagingDbButton.Name = "connectToStagingDbButton";
            connectToStagingDbButton.Size = new Size(291, 29);
            connectToStagingDbButton.TabIndex = 8;
            connectToStagingDbButton.Text = "Connect to staging database";
            connectToStagingDbButton.UseVisualStyleBackColor = true;
            connectToStagingDbButton.Click += (_, __) => ConnectToStagingDatabaseClicked?.Invoke(this, EventArgs.Empty);
            // 
            // connectToLocalDbButton
            // 
            connectToLocalDbButton.Location = new Point(328, 302);
            connectToLocalDbButton.Name = "connectToLocalDbButton";
            connectToLocalDbButton.Size = new Size(320, 29);
            connectToLocalDbButton.TabIndex = 9;
            connectToLocalDbButton.Text = "Connect to local database";
            connectToLocalDbButton.UseVisualStyleBackColor = true;
            connectToLocalDbButton.Click += (_, __) => ConnectToLocalDatabaseClicked?.Invoke(this, EventArgs.Empty);
            // 
            // databaseConnectionStatusLabel
            // 
            databaseConnectionStatusLabel.AutoSize = true;
            databaseConnectionStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            databaseConnectionStatusLabel.ForeColor = Color.Red;
            databaseConnectionStatusLabel.Location = new Point(26, 366);
            databaseConnectionStatusLabel.Name = "databaseConnectionStatusLabel";
            databaseConnectionStatusLabel.Size = new Size(114, 20);
            databaseConnectionStatusLabel.TabIndex = 10;
            databaseConnectionStatusLabel.Text = "Connected to...";
            // 
            // logoPictureBox
            // 
            logoPictureBox.Location = new Point(549, 22);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(125, 64);
            logoPictureBox.TabIndex = 13;
            logoPictureBox.TabStop = false;
            // 
            // MaintenanceApiPanelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(headerLabel);
            Controls.Add(logoPictureBox);
            Controls.Add(databaseConnectionStatusLabel);
            Controls.Add(connectToLocalDbButton);
            Controls.Add(connectToStagingDbButton);
            Controls.Add(migrationNameLabel);
            Controls.Add(addMigrationButton);
            Controls.Add(runMaintenanceApiButton);
            Controls.Add(runMaintenanceMigrationButton);
            Controls.Add(migrationNameTextBox);
            Controls.Add(maintenanceRootPathTextBox);
            Controls.Add(selectMaintenanceRootButton);
            Name = "MaintenanceApiPanelControl";
            Size = new Size(703, 420);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
