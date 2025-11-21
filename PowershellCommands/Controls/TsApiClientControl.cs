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
        private readonly Label step1Label; // Step 1 label
        private readonly Label step2Label; // Step 2 label
        private readonly Label step3Label; // Step 3 label
        private readonly Label step4Label; // Step 4 label

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
            step1Label = new Label(); // Initialize Step 1 label
            step2Label = new Label(); // Initialize Step 2 label
            step3Label = new Label(); // Initialize Step 3 label
            step4Label = new Label(); // Initialize Step 4 label

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
            // step1Label
            // 
            step1Label.AutoSize = true;
            step1Label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            step1Label.Location = new Point(26, 170);
            step1Label.Name = "step1Label";
            step1Label.Size = new Size(300, 20);
            step1Label.TabIndex = 5;
            step1Label.Text = "Step 1: Download API Definition - Pending";
            // 
            // step2Label
            // 
            step2Label.AutoSize = true;
            step2Label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            step2Label.Location = new Point(26, 200);
            step2Label.Name = "step2Label";
            step2Label.Size = new Size(250, 20);
            step2Label.TabIndex = 6;
            step2Label.Text = "Step 2: Convert to YAML - Pending";
            // 
            // step3Label
            // 
            step3Label.AutoSize = true;
            step3Label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            step3Label.Location = new Point(26, 230);
            step3Label.Name = "step3Label";
            step3Label.Size = new Size(350, 20);
            step3Label.TabIndex = 7;
            step3Label.Text = "Step 3: Replace existing definition - Pending";
            // 
            // step4Label
            // 
            step4Label.AutoSize = true;
            step4Label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            step4Label.Location = new Point(26, 260);
            step4Label.Name = "step4Label";
            step4Label.Size = new Size(360, 20);
            step4Label.TabIndex = 8;
            step4Label.Text = "Step 4: Generate TypeScript via yarn - Pending";
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
            Controls.Add(apiDefinitionLabel);
            Controls.Add(step1Label);
            Controls.Add(step2Label);
            Controls.Add(step3Label);
            Controls.Add(step4Label);
            Name = "TsApiClientControl";
            Size = new Size(703, 300);
            ResumeLayout(false);
            PerformLayout();
        }

        public void UpdateStepStatus(int stepNumber, string status)
        {
            switch (stepNumber)
            {
                case 1:
                    step1Label.Text = $"Step 1: Download API Definition - {status}";
                    break;
                case 2:
                    step2Label.Text = $"Step 2: Convert to YAML - {status}";
                    break;
                case 3:
                    step3Label.Text = $"Step 3: Replace existing definition - {status}";
                    break;
                case 4:
                    step4Label.Text = $"Step 4: Generate TypeScript via yarn - {status}";
                    break;
            }
        }
    }
}
