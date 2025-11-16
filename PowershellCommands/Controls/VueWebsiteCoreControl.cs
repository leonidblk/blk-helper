using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowershellCommands.Controls
{
    public partial class VueWebsiteCoreControl : UserControl
    {
        private readonly Label headerLabel;
        private readonly Button selectCoreRootButton;
        private readonly TextBox vueCoreRootPathTextBox;
        private readonly Button connectToStagingButton;
        private readonly Button connectToLocalButton;
        private readonly Button startVueWebsiteButton;
        private readonly Label connectionStatusLabel;

        public event EventHandler? SelectCoreRootFolderClicked;
        public event EventHandler? ConnectToStagingClicked;
        public event EventHandler? ConnectToLocalClicked;
        public event EventHandler? StartVueWebsiteClicked;

        public string VueCoreRootPath
        {
            get => vueCoreRootPathTextBox.Text;
            set => vueCoreRootPathTextBox.Text = value;
        }

        public string ConnectionStatusText
        {
            get => connectionStatusLabel.Text;
            set => connectionStatusLabel.Text = value;
        }

        public Color ConnectionStatusColor
        {
            get => connectionStatusLabel.ForeColor;
            set => connectionStatusLabel.ForeColor = value;
        }

        public VueWebsiteCoreControl()
        {
            headerLabel = new Label();
            selectCoreRootButton = new Button();
            vueCoreRootPathTextBox = new TextBox();
            connectToStagingButton = new Button();
            connectToLocalButton = new Button();
            startVueWebsiteButton = new Button();
            connectionStatusLabel = new Label();

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
            headerLabel.Size = new Size(193, 31);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Vue Website Core";
            // 
            // selectCoreRootButton
            // 
            selectCoreRootButton.Location = new Point(26, 55);
            selectCoreRootButton.Name = "selectCoreRootButton";
            selectCoreRootButton.Size = new Size(200, 34);
            selectCoreRootButton.TabIndex = 1;
            selectCoreRootButton.Text = "Select Core Micro Root Folder";
            selectCoreRootButton.UseVisualStyleBackColor = true;
            selectCoreRootButton.Click += (_, __) => SelectCoreRootFolderClicked?.Invoke(this, EventArgs.Empty);
            // 
            // vueCoreRootPathTextBox
            // 
            vueCoreRootPathTextBox.Location = new Point(241, 59);
            vueCoreRootPathTextBox.Name = "vueCoreRootPathTextBox";
            vueCoreRootPathTextBox.PlaceholderText = "Root path is empty";
            vueCoreRootPathTextBox.ReadOnly = true;
            vueCoreRootPathTextBox.Size = new Size(246, 27);
            vueCoreRootPathTextBox.TabIndex = 2;
            // 
            // connectToStagingButton
            // 
            connectToStagingButton.Location = new Point(26, 120);
            connectToStagingButton.Name = "connectToStagingButton";
            connectToStagingButton.Size = new Size(291, 29);
            connectToStagingButton.TabIndex = 3;
            connectToStagingButton.Text = "Connect to staging maintenance api";
            connectToStagingButton.UseVisualStyleBackColor = true;
            connectToStagingButton.Click += (_, __) => ConnectToStagingClicked?.Invoke(this, EventArgs.Empty);
            // 
            // connectToLocalButton
            // 
            connectToLocalButton.Location = new Point(338, 120);
            connectToLocalButton.Name = "connectToLocalButton";
            connectToLocalButton.Size = new Size(265, 29);
            connectToLocalButton.TabIndex = 4;
            connectToLocalButton.Text = "Connect to local maintenance api";
            connectToLocalButton.UseVisualStyleBackColor = true;
            connectToLocalButton.Click += (_, __) => ConnectToLocalClicked?.Invoke(this, EventArgs.Empty);
            // 
            // startVueWebsiteButton
            // 
            startVueWebsiteButton.Location = new Point(26, 180);
            startVueWebsiteButton.Name = "startVueWebsiteButton";
            startVueWebsiteButton.Size = new Size(200, 35);
            startVueWebsiteButton.TabIndex = 5;
            startVueWebsiteButton.Text = "Start Vue website";
            startVueWebsiteButton.UseVisualStyleBackColor = true;
            startVueWebsiteButton.Click += (_, __) => StartVueWebsiteClicked?.Invoke(this, EventArgs.Empty);
            // 
            // connectionStatusLabel
            // 
            connectionStatusLabel.AutoSize = true;
            connectionStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            connectionStatusLabel.ForeColor = Color.Red;
            connectionStatusLabel.Location = new Point(287, 187);
            connectionStatusLabel.Name = "connectionStatusLabel";
            connectionStatusLabel.Size = new Size(102, 20);
            connectionStatusLabel.TabIndex = 6;
            connectionStatusLabel.Text = "Connected to";
            // 
            // VueWebsiteCoreControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(headerLabel);
            Controls.Add(startVueWebsiteButton);
            Controls.Add(connectionStatusLabel);
            Controls.Add(selectCoreRootButton);
            Controls.Add(vueCoreRootPathTextBox);
            Controls.Add(connectToStagingButton);
            Controls.Add(connectToLocalButton);
            Name = "VueWebsiteCoreControl";
            Size = new Size(703, 240);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
