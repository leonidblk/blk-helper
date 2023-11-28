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

        public Form1()
        {
            InitializeComponent();

            MaintenanceRootPath = Properties.Settings.Default["MaintenanceRootFolder"]?.ToString() ?? "";
            VueCoreMicroRootPath = Properties.Settings.Default["VueCoreMicroRootFolder"]?.ToString() ?? "";
            VueOrchestratorPath = Properties.Settings.Default["VueOrchestratorPath"]?.ToString() ?? "";

            maintenanceRootPathTextBox.Text = MaintenanceRootPath;
            vueCoreRootPathTextBox.Text = VueCoreMicroRootPath;
            vueOrchestratorPathTextBox.Text = VueOrchestratorPath;

            // Format blank spaces so error does not occur
            MaintenanceRootPath = MaintenanceRootPath.Replace(" ", "` ");
            // VueCoreMicroRootPath = VueCoreMicroRootPath.Replace(" ", "` ");
            VueOrchestratorPath = VueOrchestratorPath.Replace(" ", "` ");

            UpdateDatabaseLabel();
            UpdateVueConnectionLabel();
        }

        private void ButtonRunCoreMicro_Click(object sender, EventArgs e)
        {
            var cleanedVueCoreMicroRootPath = VueCoreMicroRootPath.Replace("`", "");
            var finalFilePath = $"{cleanedVueCoreMicroRootPath}";
            string command = $"cd {cleanedVueCoreMicroRootPath}; yarn dev";
            RunPowerShellCommand(command, finalFilePath);
        }

        private void ButtonMaintenanceMigration_Click(object sender, EventArgs e)
        {
            string command = $"cd {MaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api; $env:ASPNETCORE_ENVIRONMENT = 'Local'; dotnet ef database update";
            RunPowerShellCommand(command);
        }

        private void ButtonRunMaintApi_Click(object sender, EventArgs e)
        {
            string command = $"cd {MaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api; dotnet run";

            RunPowerShellCommand(command);
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
                string command = $"cd {MaintenanceRootPath}\\Maintenance\\src\\BuildingLink.Maintenance.Api; " +
                 "$env:ASPNETCORE_ENVIRONMENT = 'Local'; " +
                 "dotnet ef migrations add " + migrationName +
                 " --project ..\\BuildingLink.Maintenance.Repositories\\" +
                 " --output-dir Data//Migrations";
                RunPowerShellCommand(command);

            }
        }

        private void ButtonConnectStagingMaintApi_Click(object sender, EventArgs e)
        {
            var pathToFile = $"{VueCoreMicroRootPath}\\config\\env-settings-local.yaml";

            try
            {
                var lines = File.ReadAllLines(pathToFile);

                // Comment out all lines
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = "#" + lines[i];
                }

                File.WriteAllLines(pathToFile, lines);

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
            var newConfiguration = @"vdev:
              VUE_APP:
                CLOGD_URL: https://clogdd.buildinglink.com/clog
                FEATURE_FLAG_SERVICE_ID: TMyQdQSEZLCAPQv4TLQJ2s
                GOOGLE_TAG_MANAGER_ID: GTM-NTF2QDT
                V2_BASE_URL: https://vdev.buildinglink.com
                AUTH:
                  BASE_URL: https://auth-vdev.buildinglink.com
                  CLIENT_ID: bldev-5dea8e3878e1cf10b8bc62e6
                API:
                  BASE_URL: https://bl-api-mgmt-vqa.azure-api.net
                  SUBSCRIPTION_KEY: e65946e054924df0a76ccdc6b2304a8b
                  DEVICE_ID: 79A4A391-EBA0-44DA-AD1B-CEEFDC3C370C
                  TRANSFORM_URL_CONFIG: '[{""search_string"": ""Maintenance/PropertyEmployee/v4"",""config_key"": ""MAINTENANCE_API_BASE_URL""}]'
                  MAINTENANCE_API_BASE_URL: https://localhost:5005";

            var pathToFile = $"{VueCoreMicroRootPath}\\config\\env-settings-local.yaml";

            try
            {
                // Need to replace ` with empty space for function to work
                File.WriteAllText(pathToFile.Replace("` ", " "), newConfiguration);
                MessageBox.Show("Configuration successfully changed to point to local maintenance api!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                UpdateVueConnectionLabel();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunPowerShellCommand(string command, string workingDirectory = "")
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe")
            {
                Arguments = $"-NoExit -NoProfile -ExecutionPolicy unrestricted -Command \"{command}\"",
                UseShellExecute = false,
                CreateNoWindow = false
            };

            if (!string.IsNullOrEmpty(workingDirectory))
            {
                processInfo.WorkingDirectory = workingDirectory;
            }

            Process.Start(processInfo);
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
            var cleanedVueOrchestratorPath = VueOrchestratorPath.Replace("`", "");

            var jsonFilePath = $"{cleanedVueOrchestratorPath}\\src\\import-map.local.json";

            try
            {
                var json = File.ReadAllText(jsonFilePath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                jsonObj["imports"]["@buildinglink/bl-website-core-micro"] = "http://localhost:3000/js/index.vdev.js";

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFilePath, output);

                string command = "yarn dev";
                RunPowerShellCommand(command, cleanedVueOrchestratorPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}