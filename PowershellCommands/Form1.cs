using PowershellCommands.Models;
using PowershellCommands.Services;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PowershellCommands
{
    public partial class Form1 : Form
    {
        public string MaintenanceRootPath { get; set; }
        public string VueCoreMicroRootPath { get; set; }
        public string VueOrchestratorPath { get; set; }

        private readonly ApplicationPaths applicationPaths;
        private OrchestratorService orchestratorService;
        private MaintenanceApiService maintenanceApiService;
        private VueWebsiteCoreService vueWebsiteCoreService;

        public Form1()
        {
            InitializeComponent();

            // NEW
            applicationPaths = new ApplicationPaths
            {
                MaintenanceRootPath = Properties.Settings.Default["MaintenanceRootFolder"]?.ToString().Replace(" ", "` ") ?? "",
                VueCoreMicroRootPath = Properties.Settings.Default["VueCoreMicroRootFolder"]?.ToString().Replace("` ", " ") ?? "",
                VueOrchestratorPath = Properties.Settings.Default["VueOrchestratorPath"]?.ToString() ?? ""
            };

            // Old to be deleted
            MaintenanceRootPath = Properties.Settings.Default["MaintenanceRootFolder"]?.ToString() ?? "";
            VueCoreMicroRootPath = Properties.Settings.Default["VueCoreMicroRootFolder"]?.ToString() ?? "";
            VueOrchestratorPath = Properties.Settings.Default["VueOrchestratorPath"]?.ToString() ?? "";

            LoadPathsIntoUI();

            // NEW
            orchestratorService = new OrchestratorService(applicationPaths);
            maintenanceApiService = new MaintenanceApiService(applicationPaths);
            vueWebsiteCoreService = new (applicationPaths);

            UpdateDatabaseLabel();
            UpdateVueConnectionLabel();
        }

        private async void ButtonRunCoreMicro_Click(object sender, EventArgs e)
        {
            await vueWebsiteCoreService.StartVueApplication();
        }

        private async void ButtonMaintenanceMigration_Click(object sender, EventArgs e)
        {
            await maintenanceApiService.RunMaintenanceMigration();
        }

        private async void ButtonRunMaintApi_Click(object sender, EventArgs e)
        {
            await maintenanceApiService.StartMaintenanceApi();
        }

        private async void ButtonAddMigration_Click(object sender, EventArgs e)
        {
            string migrationName = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(migrationName))
            {
                MessageBox.Show("Please enter a migration name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to add the migration '{migrationName}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await maintenanceApiService.AddMigration(migrationName);

            }
        }

        private void ButtonConnectStagingMaintApi_Click(object sender, EventArgs e)
        {
            try
            {
                vueWebsiteCoreService.ConnectToDevMaintApi();
                MessageBox.Show("All lines in the configuration file have been commented out.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateVueConnectionLabel();
        }

        private void ButtonConnectLocalMaintApi_Click(object sender, EventArgs e)
        {
            try
            {
                vueWebsiteCoreService.UpdateConfigurationForLocalAPI();
                UpdateVueConnectionLabel();
                MessageBox.Show("Configuration successfully changed to point to local maintenance API!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveMaintenanceRootPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    folderBrowserDialog1.SelectedPath = folderBrowserDialog.SelectedPath;

                    maintenanceRootPathTextBox.Text = folderBrowserDialog.SelectedPath;

                    Properties.Settings.Default["MaintenanceRootFolder"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();

                    MaintenanceRootPath = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void ButtonSaveVueCoreMicroRootPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    folderBrowserDialog3.SelectedPath = folderBrowserDialog.SelectedPath;

                    vueCoreRootPathTextBox.Text = folderBrowserDialog.SelectedPath;

                    Properties.Settings.Default["VueCoreMicroRootFolder"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();

                    VueCoreMicroRootPath = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void ConnectToStagingDb_Click(object sender, EventArgs e)
        {
            maintenanceApiService.UpdateConnectionStringToStaging();
            UpdateDatabaseLabel();
        }

        private void ConnectToLocalDatabase_Click(object sender, EventArgs e)
        {
            maintenanceApiService.UpdateConnectionStringToLocal();
            UpdateDatabaseLabel();
        }

        private void UpdateDatabaseLabel()
        {
            string dbConnectionStatus = maintenanceApiService.GetDatabaseConnectionStatus();

            maintDbConnectionStatusLable.Text = string.IsNullOrEmpty(dbConnectionStatus) ? "Connection status unknown" : dbConnectionStatus;
        }

        private void UpdateVueConnectionLabel()
        {
            string statusText = vueWebsiteCoreService.GetVueConnectionStatus();

            maintApiConnectionStatusLablel.Text = statusText;

            maintApiConnectionStatusLablel.ForeColor = Color.Green;
        }

        private void SelectOrchistratorPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    vueOrchestratorFolderBrowserDialog.SelectedPath = folderBrowserDialog.SelectedPath;

                    vueOrchestratorPathTextBox.Text = folderBrowserDialog.SelectedPath;

                    Properties.Settings.Default["VueOrchestratorPath"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();

                    VueOrchestratorPath = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private async void StartOrchestrator_Click(object sender, EventArgs e)
        {
            await orchestratorService.StartOrchestrator();
        }

        private void LoadPathsIntoUI()
        {
            maintenanceRootPathTextBox.Text = applicationPaths.MaintenanceRootPath;
            vueCoreRootPathTextBox.Text = applicationPaths.VueCoreMicroRootPath;
            vueOrchestratorPathTextBox.Text = applicationPaths.VueOrchestratorPath;
        }
    }
}