using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowershellCommands.Controls
{
    public partial class EventLogApiPanelControl : UserControl
    {
        private readonly Label headerLabel;
        private readonly Button selectRootButton;
        private readonly TextBox eventLogRootPathTextBox;
        private readonly Button runMigrationButton;
        private readonly Button runApiButton;
        private readonly Button addMigrationButton;
        private readonly TextBox migrationNameTextBox;
        private readonly Label migrationNameLabel;
        private readonly Button connectDevDatabaseButton;
        private readonly Button connectLocalDatabaseButton;
        private readonly Label databaseConnectionStatusLabel;

        public event EventHandler? SelectRootClicked;
        public event EventHandler? RunMigrationClicked;
        public event EventHandler? RunApiClicked;
        public event EventHandler? AddMigrationClicked;
        public event EventHandler? ConnectDevDatabaseClicked;
        public event EventHandler? ConnectLocalDatabaseClicked;

        public string EventLogRootPath
        {
            get => eventLogRootPathTextBox.Text;
            set => eventLogRootPathTextBox.Text = value;
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

        public EventLogApiPanelControl()
        {
            headerLabel = new Label();
            selectRootButton = new Button();
            eventLogRootPathTextBox = new TextBox();
            runMigrationButton = new Button();
            runApiButton = new Button();
            addMigrationButton = new Button();
            migrationNameTextBox = new TextBox();
            migrationNameLabel = new Label();
            connectDevDatabaseButton = new Button();
            connectLocalDatabaseButton = new Button();
            databaseConnectionStatusLabel = new Label();

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
            headerLabel.Size = new Size(144, 31);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "EventLog API";
            // 
            // selectRootButton
            // 
            selectRootButton.Location = new Point(26, 55);
            selectRootButton.Name = "selectRootButton";
            selectRootButton.Size = new Size(273, 35);
            selectRootButton.TabIndex = 1;
            selectRootButton.Text = "Select EventLog folder";
            selectRootButton.UseVisualStyleBackColor = true;
            selectRootButton.Click += (_, __) => SelectRootClicked?.Invoke(this, EventArgs.Empty);
            // 
            // eventLogRootPathTextBox
            // 
            eventLogRootPathTextBox.Location = new Point(305, 58);
            eventLogRootPathTextBox.Name = "eventLogRootPathTextBox";
            eventLogRootPathTextBox.PlaceholderText = "Root path is empty";
            eventLogRootPathTextBox.ReadOnly = true;
            eventLogRootPathTextBox.Size = new Size(238, 27);
            eventLogRootPathTextBox.TabIndex = 2;
            // 
            // runMigrationButton
            // 
            runMigrationButton.Location = new Point(26, 110);
            runMigrationButton.Name = "runMigrationButton";
            runMigrationButton.Size = new Size(217, 39);
            runMigrationButton.TabIndex = 3;
            runMigrationButton.Text = "Run EventLog migration";
            runMigrationButton.UseVisualStyleBackColor = true;
            runMigrationButton.Click += (_, __) => RunMigrationClicked?.Invoke(this, EventArgs.Empty);
            // 
            // runApiButton
            // 
            runApiButton.Location = new Point(26, 160);
            runApiButton.Name = "runApiButton";
            runApiButton.Size = new Size(200, 39);
            runApiButton.TabIndex = 4;
            runApiButton.Text = "Run EventLog API";
            runApiButton.UseVisualStyleBackColor = true;
            runApiButton.Click += (_, __) => RunApiClicked?.Invoke(this, EventArgs.Empty);
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
            // connectDevDatabaseButton
            // 
            connectDevDatabaseButton.Location = new Point(26, 302);
            connectDevDatabaseButton.Name = "connectDevDatabaseButton";
            connectDevDatabaseButton.Size = new Size(291, 29);
            connectDevDatabaseButton.TabIndex = 8;
            connectDevDatabaseButton.Text = "Connect to Dev database";
            connectDevDatabaseButton.UseVisualStyleBackColor = true;
            connectDevDatabaseButton.Click += (_, __) => ConnectDevDatabaseClicked?.Invoke(this, EventArgs.Empty);
            // 
            // connectLocalDatabaseButton
            // 
            connectLocalDatabaseButton.Location = new Point(328, 302);
            connectLocalDatabaseButton.Name = "connectLocalDatabaseButton";
            connectLocalDatabaseButton.Size = new Size(320, 29);
            connectLocalDatabaseButton.TabIndex = 9;
            connectLocalDatabaseButton.Text = "Connect to Local database";
            connectLocalDatabaseButton.UseVisualStyleBackColor = true;
            connectLocalDatabaseButton.Click += (_, __) => ConnectLocalDatabaseClicked?.Invoke(this, EventArgs.Empty);
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
            // EventLogApiPanelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(headerLabel);
            Controls.Add(databaseConnectionStatusLabel);
            Controls.Add(connectLocalDatabaseButton);
            Controls.Add(connectDevDatabaseButton);
            Controls.Add(migrationNameLabel);
            Controls.Add(addMigrationButton);
            Controls.Add(runApiButton);
            Controls.Add(runMigrationButton);
            Controls.Add(migrationNameTextBox);
            Controls.Add(eventLogRootPathTextBox);
            Controls.Add(selectRootButton);
            Name = "EventLogApiPanelControl";
            Size = new Size(703, 420);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
