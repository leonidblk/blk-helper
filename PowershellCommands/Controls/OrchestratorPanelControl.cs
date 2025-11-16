using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowershellCommands.Controls
{
    public partial class OrchestratorPanelControl : UserControl
    {
        private readonly Label headerLabel;
        private readonly Button selectOrchestratorRootButton;
        private readonly TextBox orchestratorPathTextBox;
        private readonly Button startOrchestratorButton;

        public event EventHandler? SelectOrchestratorPathClicked;
        public event EventHandler? StartOrchestratorClicked;

        public string OrchestratorPath
        {
            get => orchestratorPathTextBox.Text;
            set => orchestratorPathTextBox.Text = value;
        }

        public OrchestratorPanelControl()
        {
            headerLabel = new Label();
            selectOrchestratorRootButton = new Button();
            orchestratorPathTextBox = new TextBox();
            startOrchestratorButton = new Button();

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
            headerLabel.Size = new Size(136, 31);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Orchistrator";
            // 
            // selectOrchestratorRootButton
            // 
            selectOrchestratorRootButton.Location = new Point(26, 55);
            selectOrchestratorRootButton.Name = "selectOrchestratorRootButton";
            selectOrchestratorRootButton.Size = new Size(291, 29);
            selectOrchestratorRootButton.TabIndex = 1;
            selectOrchestratorRootButton.Text = "Select orchistrator root folder";
            selectOrchestratorRootButton.UseVisualStyleBackColor = true;
            selectOrchestratorRootButton.Click += (_, __) => SelectOrchestratorPathClicked?.Invoke(this, EventArgs.Empty);
            // 
            // orchestratorPathTextBox
            // 
            orchestratorPathTextBox.Location = new Point(338, 55);
            orchestratorPathTextBox.Name = "orchestratorPathTextBox";
            orchestratorPathTextBox.ReadOnly = true;
            orchestratorPathTextBox.Size = new Size(249, 27);
            orchestratorPathTextBox.TabIndex = 2;
            // 
            // startOrchestratorButton
            // 
            startOrchestratorButton.Location = new Point(26, 110);
            startOrchestratorButton.Name = "startOrchestratorButton";
            startOrchestratorButton.Size = new Size(217, 29);
            startOrchestratorButton.TabIndex = 3;
            startOrchestratorButton.Text = "Start Orchestrator";
            startOrchestratorButton.UseVisualStyleBackColor = true;
            startOrchestratorButton.Click += (_, __) => StartOrchestratorClicked?.Invoke(this, EventArgs.Empty);
            // 
            // OrchestratorPanelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(headerLabel);
            Controls.Add(startOrchestratorButton);
            Controls.Add(selectOrchestratorRootButton);
            Controls.Add(orchestratorPathTextBox);
            Name = "OrchestratorPanelControl";
            Size = new Size(703, 170);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
