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

        public event EventHandler? SelectRootClicked;

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
            // TsApiClientControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(headerLabel);
            Controls.Add(selectRootButton);
            Controls.Add(rootPathTextBox);
            Name = "TsApiClientControl";
            Size = new Size(703, 140);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
