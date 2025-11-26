using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PowershellCommands.Controls
{
    public partial class UtilsControl : UserControl
    {
        private readonly Label headerLabel;
        private readonly Label nodeVersionLabel;
        private readonly ComboBox versionComboBox;
        private readonly Button switchVersionButton;
        private readonly Button refreshVersionButton;
        private readonly Button copyVersionButton;
        private readonly Button clearNodeCacheButton;
        private readonly Label clearNodeCacheLabel;
        private readonly Label statusLabel;

        public event EventHandler? SwitchVersionClicked;
        public event EventHandler? RefreshVersionClicked;
        public event EventHandler? CopyVersionClicked;
        public event EventHandler? ClearNodeCacheClicked;

        public string SelectedVersion
        {
            get => versionComboBox.Text?.Trim() ?? string.Empty;
            set => versionComboBox.Text = value;
        }

        public string VersionStatusText
        {
            get => statusLabel.Text;
            set => statusLabel.Text = value;
        }

        public Color VersionStatusColor
        {
            get => statusLabel.ForeColor;
            set => statusLabel.ForeColor = value;
        }

        public UtilsControl()
        {
            headerLabel = new Label();
            nodeVersionLabel = new Label();
            versionComboBox = new ComboBox();
            switchVersionButton = new Button();
            refreshVersionButton = new Button();
            copyVersionButton = new Button();
            clearNodeCacheButton = new Button();
            clearNodeCacheLabel = new Label();
            statusLabel = new Label();

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
            headerLabel.Size = new Size(67, 31);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Utils";
            // 
            // nodeVersionLabel
            // 
            nodeVersionLabel.AutoSize = true;
            nodeVersionLabel.Location = new Point(26, 55);
            nodeVersionLabel.Name = "nodeVersionLabel";
            nodeVersionLabel.Size = new Size(124, 20);
            nodeVersionLabel.TabIndex = 1;
            nodeVersionLabel.Text = "Node version (full, e.g. 20.18.1)";
            // 
            // versionComboBox
            // 
            versionComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            versionComboBox.FormattingEnabled = true;
            versionComboBox.Items.AddRange(new object[] { "16.20.2", "18.19.1", "20.18.1" });
            versionComboBox.Location = new Point(26, 78);
            versionComboBox.Name = "versionComboBox";
            versionComboBox.Size = new Size(121, 28);
            versionComboBox.TabIndex = 2;
            versionComboBox.Text = ""; // Require user to pick or type full version
            // 
            // switchVersionButton
            // 
            switchVersionButton.Location = new Point(170, 78);
            switchVersionButton.Name = "switchVersionButton";
            switchVersionButton.Size = new Size(200, 30);
            switchVersionButton.TabIndex = 3;
            switchVersionButton.Text = "Switch Node version";
            switchVersionButton.UseVisualStyleBackColor = true;
            switchVersionButton.Click += (_, __) => SwitchVersionClicked?.Invoke(this, EventArgs.Empty);
            // 
            // refreshVersionButton
            // 
            refreshVersionButton.Location = new Point(26, 122);
            refreshVersionButton.Name = "refreshVersionButton";
            refreshVersionButton.Size = new Size(200, 30);
            refreshVersionButton.TabIndex = 4;
            refreshVersionButton.Text = "Check current version";
            refreshVersionButton.UseVisualStyleBackColor = true;
            refreshVersionButton.Click += (_, __) => RefreshVersionClicked?.Invoke(this, EventArgs.Empty);
            // 
            // copyVersionButton
            // 
            copyVersionButton.Location = new Point(245, 122);
            copyVersionButton.Name = "copyVersionButton";
            copyVersionButton.Size = new Size(200, 30);
            copyVersionButton.TabIndex = 5;
            copyVersionButton.Text = "Copy current version";
            copyVersionButton.UseVisualStyleBackColor = true;
            copyVersionButton.Click += (_, __) => CopyVersionClicked?.Invoke(this, EventArgs.Empty);
            // 
            // clearNodeCacheButton
            // 
            clearNodeCacheButton.Location = new Point(26, 166);
            clearNodeCacheButton.Name = "clearNodeCacheButton";
            clearNodeCacheButton.Size = new Size(200, 30);
            clearNodeCacheButton.TabIndex = 6;
            clearNodeCacheButton.Text = "Force switch / clear cache";
            clearNodeCacheButton.UseVisualStyleBackColor = true;
            clearNodeCacheButton.Click += (_, __) => ClearNodeCacheClicked?.Invoke(this, EventArgs.Empty);
            // 
            // clearNodeCacheLabel
            // 
            clearNodeCacheLabel.AutoSize = true;
            clearNodeCacheLabel.Location = new Point(245, 171);
            clearNodeCacheLabel.MaximumSize = new Size(430, 0);
            clearNodeCacheLabel.Name = "clearNodeCacheLabel";
            clearNodeCacheLabel.Size = new Size(334, 40);
            clearNodeCacheLabel.TabIndex = 7;
            clearNodeCacheLabel.Text = "If switching to another version results in no error but retains the previous version when checking current version, press this button to clear node cache";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            statusLabel.ForeColor = Color.DimGray;
            statusLabel.Location = new Point(26, 215);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(128, 20);
            statusLabel.TabIndex = 8;
            statusLabel.Text = "Node: checking...";
            // 
            // UtilsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(headerLabel);
            Controls.Add(nodeVersionLabel);
            Controls.Add(versionComboBox);
            Controls.Add(switchVersionButton);
            Controls.Add(refreshVersionButton);
            Controls.Add(copyVersionButton);
            Controls.Add(clearNodeCacheButton);
            Controls.Add(clearNodeCacheLabel);
            Controls.Add(statusLabel);
            Name = "UtilsControl";
            Size = new Size(703, 260);
            ResumeLayout(false);
            PerformLayout();
        }

        public void SetAvailableVersions(IEnumerable<string> versions)
        {
            versionComboBox.Items.Clear();
            versionComboBox.Items.AddRange(new List<string>(versions).ToArray());
        }
    }
}
