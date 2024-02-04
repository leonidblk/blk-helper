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

        private void ButtonRunCoreMicro_Click(object sender, EventArgs e)
        {
            vueWebsiteCoreService.StartVueApplication();
        }

        private void ButtonMaintenanceMigration_Click(object sender, EventArgs e)
        {
            maintenanceApiService.RunMaintenanceMigration();
        }

        private void ButtonRunMaintApi_Click(object sender, EventArgs e)
        {
            maintenanceApiService.StartMaintenanceApi();
        }

        private void ButtonAddMigration_Click(object sender, EventArgs e)
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
                maintenanceApiService.AddMigration(migrationName);

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
            var cleanedMaintenanceRootPath = MaintenanceRootPath.Replace("`", "");

            var appSettingsPath = $"{cleanedMaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api\\appsettings.Local.json";

            try
            {
                var json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                jsonObj["ConnectionStrings"]["Maintenance"] = "Data Source=tcp:SqlCoreDevAGL.buildinglink.local,1433;Initial Catalog=Maintenance;User ID=maintenance;Password=76Ya#12jmhd#;Max Pool Size=10000;MultipleActiveResultSets=True;Connect Timeout=5;Application Name=BuildingLink.Maintenance.Api;ApplicationIntent=ReadWrite;MultiSubnetFailover=True;ConnectRetryCount=20;ConnectRetryInterval=1;Encrypt=True;TrustServerCertificate=True;";

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(appSettingsPath, output);

                MessageBox.Show("Connection string updated successfully to staging.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateDatabaseLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the connection string: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectToLocalDatabase_Click(object sender, EventArgs e)
        {
            var cleanedMaintenanceRootPath = MaintenanceRootPath.Replace("`", "");

            var appSettingsPath = $"{cleanedMaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api\\appsettings.Local.json";

            try
            {
                var json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                jsonObj["ConnectionStrings"]["Maintenance"] = "Data Source=localhost;Initial Catalog=Maintenance;User ID=sa;Password=Password1!;Encrypt=True;TrustServerCertificate=True;";

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(appSettingsPath, output);

                MessageBox.Show("Connection string updated successfully to local.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateDatabaseLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the connection string: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDatabaseLabel()
        {
            var cleanedMaintenanceRootPath = MaintenanceRootPath.Replace("`", "");

            var appSettingsPath = $"{cleanedMaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api\\appsettings.Local.json";

            if (!File.Exists(appSettingsPath))
            {
                MessageBox.Show($"The path to the app settings file does not exist: {appSettingsPath}", "Path Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                var connectionString = jsonObj["ConnectionStrings"]["Maintenance"].ToString();

                if (connectionString.Contains("localhost"))
                {
                    maintDbConnectionStatusLable.Text = "Currently using Local DB";
                }
                else
                {
                    maintDbConnectionStatusLable.Text = "Currently using Staging DB";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading the app settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateVueConnectionLabel()
        {
            var vueConnectionConfigPath = $"{VueCoreMicroRootPath}\\config\\env-settings-local.yaml";

            if (!File.Exists(vueConnectionConfigPath))
            {
                MessageBox.Show($"The path to the Vue connection config file does not exist: {vueConnectionConfigPath}", "Path Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var configContent = File.ReadAllText(vueConnectionConfigPath);
                string localHostNotCommentedPattern = @"^[^#]*localhost";

                bool isConnectedToLocal = Regex.IsMatch(configContent, localHostNotCommentedPattern, RegexOptions.Multiline);

                if (isConnectedToLocal)
                {
                    maintApiConnectionStatusLablel.Text = "Connected to Local API";
                    maintApiConnectionStatusLablel.ForeColor = Color.Green;
                }
                else
                {
                    maintApiConnectionStatusLablel.Text = "Connected to Staging API";
                    maintApiConnectionStatusLablel.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading the Vue connection settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void StartOrchestrator_Click(object sender, EventArgs e)
        {
            orchestratorService.StartOrchestrator();
        }

        private void LoadPathsIntoUI()
        {
            maintenanceRootPathTextBox.Text = applicationPaths.MaintenanceRootPath;
            vueCoreRootPathTextBox.Text = applicationPaths.VueCoreMicroRootPath;
            vueOrchestratorPathTextBox.Text = applicationPaths.VueOrchestratorPath;
        }
    }
}