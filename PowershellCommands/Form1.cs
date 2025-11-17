using PowershellCommands.Controls;
using PowershellCommands.Models;
using PowershellCommands.Services;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PowershellCommands
{
    public partial class Form1 : Form
    {
        public string MaintenanceRootPath { get; set; }
        public string VueCoreMicroRootPath { get; set; }
        public string VueOrchestratorPath { get; set; }
        public string EventLogRootPath { get; set; }
        public string EventLogVueRootPath { get; set; }
        public string TsApiClientRootPath { get; set; }

        private readonly ApplicationPaths applicationPaths;
        private OrchestratorService orchestratorService;
        private MaintenanceApiService maintenanceApiService;
        private VueWebsiteCoreService vueWebsiteCoreService;
        private EventLogApiService eventLogApiService;
        private EventLogVueService eventLogVueService;

        public Form1()
        {
            InitializeComponent();
            WireUpSectionEvents();

            // NEW
            applicationPaths = new ApplicationPaths
            {
                MaintenanceRootPath = Properties.Settings.Default["MaintenanceRootFolder"]?.ToString().Replace(" ", "` ") ?? "",
                VueCoreMicroRootPath = Properties.Settings.Default["VueCoreMicroRootFolder"]?.ToString().Replace("` ", " ") ?? "",
                VueOrchestratorPath = Properties.Settings.Default["VueOrchestratorPath"]?.ToString() ?? "",
                EventLogRootPath = Properties.Settings.Default["EventLogRootFolder"]?.ToString().Replace(" ", "` ") ?? "",
                EventLogVueRootPath = Properties.Settings.Default["EventLogVueRootFolder"]?.ToString().Replace(" ", "` ") ?? "",
                TsApiClientRootPath = Properties.Settings.Default["TsApiClientRootFolder"]?.ToString().Replace(" ", "` ") ?? ""
            };

            // Old to be deleted
            MaintenanceRootPath = Properties.Settings.Default["MaintenanceRootFolder"]?.ToString() ?? "";
            VueCoreMicroRootPath = Properties.Settings.Default["VueCoreMicroRootFolder"]?.ToString() ?? "";
            VueOrchestratorPath = Properties.Settings.Default["VueOrchestratorPath"]?.ToString() ?? "";
            EventLogRootPath = Properties.Settings.Default["EventLogRootFolder"]?.ToString() ?? "";
            EventLogVueRootPath = Properties.Settings.Default["EventLogVueRootFolder"]?.ToString() ?? "";
            TsApiClientRootPath = Properties.Settings.Default["TsApiClientRootFolder"]?.ToString() ?? "";

            LoadPathsIntoUI();

            // NEW
            orchestratorService = new OrchestratorService(applicationPaths);
            maintenanceApiService = new MaintenanceApiService(applicationPaths);
            vueWebsiteCoreService = new (applicationPaths);
            eventLogApiService = new EventLogApiService(applicationPaths);
            eventLogVueService = new EventLogVueService(applicationPaths);

            UpdateDatabaseLabel();
            UpdateVueConnectionLabel();
            UpdateEventLogDatabaseLabel();
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
            string migrationName = maintenanceApiSection.MigrationName.Trim();
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

                    maintenanceApiSection.MaintenanceRootPath = folderBrowserDialog.SelectedPath;

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

                    vueWebsiteCoreSection.VueCoreRootPath = folderBrowserDialog.SelectedPath;

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

            maintenanceApiSection.DatabaseConnectionStatusText = string.IsNullOrEmpty(dbConnectionStatus)
                ? "Connection status unknown"
                : dbConnectionStatus;
        }

        private void UpdateVueConnectionLabel()
        {
            string statusText = vueWebsiteCoreService.GetVueConnectionStatus();

            vueWebsiteCoreSection.ConnectionStatusText = statusText;
            vueWebsiteCoreSection.ConnectionStatusColor = Color.Green;
        }

        private void UpdateEventLogDatabaseLabel()
        {
            string status = string.Empty;

            try
            {
                status = eventLogApiService.GetDatabaseConnectionStatus();
            }
            catch (Exception ex)
            {
                status = $"Unable to determine status: {ex.Message}";
            }

            eventLogSection.DatabaseConnectionStatusText = string.IsNullOrEmpty(status)
                ? "Connection status unknown"
                : status;
        }

        private void SelectOrchistratorPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    vueOrchestratorFolderBrowserDialog.SelectedPath = folderBrowserDialog.SelectedPath;

                    orchestratorSection.OrchestratorPath = folderBrowserDialog.SelectedPath;

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

        private async void ButtonOpenOrchestratorInVsCode_Click(object sender, EventArgs e)
        {
            await orchestratorService.OpenInVisualStudioCode();
        }

        private async void ButtonRunEventLogApi_Click(object sender, EventArgs e)
        {
            try
            {
                await eventLogApiService.StartEventLogApi();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start EventLog API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ButtonRunEventLogMigration_Click(object sender, EventArgs e)
        {
            try
            {
                await eventLogApiService.RunEventLogMigration();
                MessageBox.Show("EventLog migration completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to run EventLog migration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ButtonAddEventLogMigration_Click(object sender, EventArgs e)
        {
            string migrationName = eventLogSection.MigrationName.Trim();
            if (string.IsNullOrEmpty(migrationName))
            {
                MessageBox.Show("Please enter a migration name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to add the EventLog migration '{migrationName}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await eventLogApiService.AddMigration(migrationName);
                    MessageBox.Show("Migration added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to add EventLog migration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSaveEventLogRootPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    eventLogFolderBrowserDialog.SelectedPath = folderBrowserDialog.SelectedPath;
                    eventLogSection.EventLogRootPath = folderBrowserDialog.SelectedPath;

                    Properties.Settings.Default["EventLogRootFolder"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();

                    EventLogRootPath = folderBrowserDialog.SelectedPath;
                    applicationPaths.EventLogRootPath = folderBrowserDialog.SelectedPath.Replace(" ", "` ");
                }
            }
        }

        private void ConnectEventLogToDevDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                eventLogApiService.UpdateConnectionStringToDev();
                UpdateEventLogDatabaseLabel();
                MessageBox.Show("EventLog API configured to use Dev database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update EventLog database connection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectEventLogToLocalDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                eventLogApiService.UpdateConnectionStringToLocal();
                UpdateEventLogDatabaseLabel();
                MessageBox.Show("EventLog API configured to use Local database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update EventLog database connection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ButtonRunEventLogVue_Click(object sender, EventArgs e)
        {
            try
            {
                await eventLogVueService.StartEventLogVueAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start EventLog Vue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSaveEventLogVueRootPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    eventLogVueFolderBrowserDialog.SelectedPath = folderBrowserDialog.SelectedPath;
                    eventLogVueSection.RootPath = folderBrowserDialog.SelectedPath;

                    Properties.Settings.Default["EventLogVueRootFolder"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();

                    EventLogVueRootPath = folderBrowserDialog.SelectedPath;
                    applicationPaths.EventLogVueRootPath = folderBrowserDialog.SelectedPath.Replace(" ", "` ");
                }
            }
        }

        private void ButtonSaveTsApiClientRootPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    tsApiClientFolderBrowserDialog.SelectedPath = folderBrowserDialog.SelectedPath;
                    tsApiClientSection.RootPath = folderBrowserDialog.SelectedPath;

                    Properties.Settings.Default["TsApiClientRootFolder"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();

                    TsApiClientRootPath = folderBrowserDialog.SelectedPath;
                    applicationPaths.TsApiClientRootPath = folderBrowserDialog.SelectedPath.Replace(" ", "` ");
                }
            }
        }

        private void WireUpSectionEvents()
        {
            vueWebsiteCoreSection.SelectCoreRootFolderClicked += ButtonSaveVueCoreMicroRootPath_Click;
            vueWebsiteCoreSection.ConnectToStagingClicked += ButtonConnectStagingMaintApi_Click;
            vueWebsiteCoreSection.ConnectToLocalClicked += ButtonConnectLocalMaintApi_Click;
            vueWebsiteCoreSection.StartVueWebsiteClicked += ButtonRunCoreMicro_Click;

            orchestratorSection.SelectOrchestratorPathClicked += SelectOrchistratorPath_Click;
            orchestratorSection.StartOrchestratorClicked += StartOrchestrator_Click;
            orchestratorSection.OpenInVsCodeClicked += ButtonOpenOrchestratorInVsCode_Click;

            maintenanceApiSection.SelectMaintenanceRootClicked += ButtonSaveMaintenanceRootPath_Click;
            maintenanceApiSection.RunMaintenanceMigrationClicked += ButtonMaintenanceMigration_Click;
            maintenanceApiSection.RunMaintenanceApiClicked += ButtonRunMaintApi_Click;
            maintenanceApiSection.AddMigrationClicked += ButtonAddMigration_Click;
            maintenanceApiSection.ConnectToStagingDatabaseClicked += ConnectToStagingDb_Click;
            maintenanceApiSection.ConnectToLocalDatabaseClicked += ConnectToLocalDatabase_Click;

            eventLogSection.SelectRootClicked += ButtonSaveEventLogRootPath_Click;
            eventLogSection.RunMigrationClicked += ButtonRunEventLogMigration_Click;
            eventLogSection.RunApiClicked += ButtonRunEventLogApi_Click;
            eventLogSection.AddMigrationClicked += ButtonAddEventLogMigration_Click;
            eventLogSection.ConnectDevDatabaseClicked += ConnectEventLogToDevDatabase_Click;
            eventLogSection.ConnectLocalDatabaseClicked += ConnectEventLogToLocalDatabase_Click;

            eventLogVueSection.SelectRootClicked += ButtonSaveEventLogVueRootPath_Click;
            eventLogVueSection.StartVueClicked += ButtonRunEventLogVue_Click;
            tsApiClientSection.SelectRootClicked += ButtonSaveTsApiClientRootPath_Click;
        }

        private void LoadPathsIntoUI()
        {
            maintenanceApiSection.MaintenanceRootPath = applicationPaths.MaintenanceRootPath;
            vueWebsiteCoreSection.VueCoreRootPath = applicationPaths.VueCoreMicroRootPath;
            orchestratorSection.OrchestratorPath = applicationPaths.VueOrchestratorPath;
            eventLogSection.EventLogRootPath = applicationPaths.EventLogRootPath;
            eventLogVueSection.RootPath = applicationPaths.EventLogVueRootPath;
            tsApiClientSection.RootPath = applicationPaths.TsApiClientRootPath;
        }
    }
}
