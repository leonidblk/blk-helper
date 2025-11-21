using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowershellCommands.Controls;

namespace PowershellCommands.Services
{
    public class UtilsController
    {
        private readonly NodeVersionService _nodeVersionService;
        private readonly UtilsControl _utilsControl;
        private string _currentNodeVersion = string.Empty;

        public UtilsController(NodeVersionService nodeVersionService, UtilsControl utilsControl)
        {
            _nodeVersionService = nodeVersionService;
            _utilsControl = utilsControl;
        }

        public async Task InitializeAsync()
        {
            await LoadNodeVersionsAsync();
            await RefreshNodeVersionStatusAsync(showErrors: false);
        }

        public async Task SwitchNodeVersionAsync()
        {
            var selectedVersion = _utilsControl.SelectedVersion;

            _utilsControl.VersionStatusText = $"Switching to Node {selectedVersion}...";
            _utilsControl.VersionStatusColor = Color.DimGray;

            var result = await _nodeVersionService.TrySwitchVersionAsync(selectedVersion);

            if (result.Success)
            {
                _currentNodeVersion = result.Version;
                _utilsControl.VersionStatusText = $"Node: {result.Version}";
                _utilsControl.VersionStatusColor = Color.Green;
                MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _utilsControl.VersionStatusText = result.Message;
                _utilsControl.VersionStatusColor = Color.Red;
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task RefreshNodeVersionStatusAsync(bool showErrors = true)
        {
            _utilsControl.VersionStatusText = "Checking current Node version...";
            _utilsControl.VersionStatusColor = Color.DimGray;

            var result = await _nodeVersionService.GetVersionStatusAsync();

            if (result.Success)
            {
                _currentNodeVersion = result.Version;
                _utilsControl.VersionStatusText = $"Node: {result.Version}";
                _utilsControl.VersionStatusColor = Color.Green;
            }
            else
            {
                _currentNodeVersion = string.Empty;
                _utilsControl.VersionStatusText = result.Message;
                _utilsControl.VersionStatusColor = Color.Red;

                if (showErrors)
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task CopyNodeVersionAsync()
        {
            try
            {
                var cleanVersion = await _nodeVersionService.CopyCurrentVersionToClipboardAsync();
                _currentNodeVersion = cleanVersion;
                _utilsControl.VersionStatusText = $"Node: {cleanVersion} (copied)";
                _utilsControl.VersionStatusColor = Color.Green;
                MessageBox.Show($"Copied Node version: {cleanVersion}", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to copy Node version: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadNodeVersionsAsync()
        {
            try
            {
                var versions = await NodeVersionService.GetInstalledVersionsAsync();
                _utilsControl.SetAvailableVersions(versions);

                if (!string.IsNullOrWhiteSpace(_currentNodeVersion))
                {
                    _utilsControl.SelectedVersion = _currentNodeVersion.TrimStart('v', 'V');
                }
                else if (versions.Count > 0)
                {
                    _utilsControl.SelectedVersion = versions[0];
                }
            }
            catch
            {
                // Ignore populating list failures; user can still type manually.
            }
        }
    }
}
