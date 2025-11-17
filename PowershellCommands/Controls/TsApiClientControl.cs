using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowershellCommands.Controls
{
    public partial class TsApiClientControl : UserControl
    {
        private readonly Label headerLabel;
        private readonly Button selectRootButton;
        private readonly TextBox rootPathTextBox;
        private readonly Button downloadApiButton;
        private readonly Label apiDefinitionLabel; // Label for API definition text

        public event EventHandler? SelectRootClicked;
        public event EventHandler? DownloadApiClicked;

        public string RootPath
        {
            get => rootPathTextBox.Text;
            set => rootPathTextBox.Text = value;
        }

        public TsApiClientControl()
        {
            headerLabel = new Label();
            selectRootButton = new Button();
            rootPathTextBox = new TextBox();
            downloadApiButton = new Button();
            apiDefinitionLabel = new Label(); // Initialize the API definition label

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
            headerLabel.Size = new Size(168, 31);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "TS API Client";
            // 
            // selectRootButton
            // 
            selectRootButton.Location = new Point(26, 55);
            selectRootButton.Name = "selectRootButton";
            selectRootButton.Size = new Size(273, 35);
            selectRootButton.TabIndex = 1;
            selectRootButton.Text = "Select TS API Client folder";
            selectRootButton.UseVisualStyleBackColor = true;
            selectRootButton.Click += (_, __) => SelectRootClicked?.Invoke(this, EventArgs.Empty);
            // 
            // rootPathTextBox
            // 
            rootPathTextBox.Location = new Point(305, 58);
            rootPathTextBox.Name = "rootPathTextBox";
            rootPathTextBox.PlaceholderText = "Root path is empty";
            rootPathTextBox.ReadOnly = true;
            rootPathTextBox.Size = new Size(238, 27);
            rootPathTextBox.TabIndex = 2;
            // 
            // downloadApiButton
            // 
            downloadApiButton.Location = new Point(26, 120);
            downloadApiButton.Name = "downloadApiButton";
            downloadApiButton.Size = new Size(273, 35);
            downloadApiButton.TabIndex = 3;
            downloadApiButton.Text = "Download API Definition";
            downloadApiButton.UseVisualStyleBackColor = true;
            downloadApiButton.Click += (_, __) => DownloadApiClicked?.Invoke(this, EventArgs.Empty);
            // 
            // apiDefinitionLabel
            // 
            apiDefinitionLabel.AutoSize = true;
            apiDefinitionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            apiDefinitionLabel.Location = new Point(26, 95);
            apiDefinitionLabel.Name = "apiDefinitionLabel";
            apiDefinitionLabel.Size = new Size(200, 23);
            apiDefinitionLabel.TabIndex = 4;
            apiDefinitionLabel.Text = "This is the API definition https://eventlog-lborigin.development.buildinglink.com/swagger/PropertyEmployee-v3/swagger.json";
            // 
            // TsApiClientControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(headerLabel);
            Controls.Add(selectRootButton);
            Controls.Add(rootPathTextBox);
            Controls.Add(downloadApiButton);
            Controls.Add(apiDefinitionLabel); // Add the API definition label to the control
            Name = "TsApiClientControl";
            Size = new Size(703, 200);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
