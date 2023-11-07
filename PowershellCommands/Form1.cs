using System.Diagnostics;
using System.Windows.Forms;

namespace PowershellCommands
{
    public partial class Form1 : Form
    {
        public string MaintenanceRootPath { get; set; }
        public string VueCoreRootPath { get; set; }

        public Form1()
        {
            InitializeComponent();

            MaintenanceRootPath = Properties.Settings.Default["MaintenanceRootFolder"]?.ToString() ?? "";
            VueCoreRootPath = Properties.Settings.Default["VueCoreRootFolder"]?.ToString() ?? "";

            textBox2.Text = MaintenanceRootPath;
            textBox3.Text = VueCoreRootPath;

            MaintenanceRootPath = MaintenanceRootPath.Replace(" ", "` "); // Format blank spaces so error does not occur
            VueCoreRootPath = VueCoreRootPath.Replace(" ", "` "); // Format blank spaces so error does not occur

            UpdateDatabaseLabel();

            // var icon = 
            // pictureBox1.Image = Properties.Settings.Default["MaintenanceRootFolder"] ? Properties.Resources.
        }

        private void ButtonCoreDev_Click(object sender, EventArgs e)
        {
            // Run the "Core dev" command
            string command = $"cd {VueCoreRootPath}; yarn dev";
            RunPowerShellCommand(command);
        }

        // EF database update
        private void ButtonMaintenanceMigration_Click(object sender, EventArgs e)
        {
            // Run the "Maintenance migration" command
            string command = $"cd {MaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api; $env:ASPNETCORE_ENVIRONMENT = 'Local'; dotnet ef database update";
            RunPowerShellCommand(command);
        }

        // Dotnet run API
        private void ButtonRunApp_Click(object sender, EventArgs e)
        {
            string command = $"cd {MaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api; dotnet run";

            RunPowerShellCommand(command);
        }

        // Run bl website core
        private void button4_Click(object sender, EventArgs e)
        {
            string command = "cd C:\\Users\\Leonid` XPS` 15\\Documents\\GitHub\\Vue\\bl-website-core; dir";
            RunPowerShellCommand(command);
        }

        // Add migration
        private void buttonAddMigration_Click(object sender, EventArgs e)
        {
            string migrationName = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(migrationName))
            {
                MessageBox.Show("Please enter a migration name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Display confirmation dialog
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

        private void button7_Click(object sender, EventArgs e)
        {
            var pathToFile = $"{VueCoreRootPath}\\config\\env-settings-local.yaml";

            var command3 = $"\\\"\\\" | Set-Content -Path {pathToFile}";

            RunPowerShellCommand(command3);
        }

        // Connect to local maintenance api
        private void button8_Click(object sender, EventArgs e)
        {
            var newConfiguration = @"development:
              VUE_APP:
               AUTH:
                BASE_URL: https://auth-vqa.buildinglink.com
               API:
                BASE_URL: https://bl-api-mgmt-vqa.azure-api.net
                TRANSFORM_URL_CONFIG: '[{
                  ""search_string"": ""Maintenance/PropertyEmployee/v4"", 
                  ""config_key"": ""MAINTENANCE_API_BASE_URL""}]'
                MAINTENANCE_API_BASE_URL: https://localhost:5005";

            var pathToFile = $"{VueCoreRootPath}\\config\\env-settings-local.yaml";

            try
            {
                // Need to replace ` with empty space for function to work
                File.WriteAllText(pathToFile.Replace("` ", " "), newConfiguration);
                MessageBox.Show("Configuration successfully changed to point to local maintenance api!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RunPowerShellCommand(string command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe")
            {
                Arguments = $"-NoExit -NoProfile -ExecutionPolicy unrestricted -Command \"{command}\"",
                UseShellExecute = false,
                CreateNoWindow = false
            };

            Process.Start(processInfo);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Update the TextBox with the selected folder path
                    folderBrowserDialog1.SelectedPath = folderBrowserDialog.SelectedPath;

                    // update UI
                    textBox2.Text = folderBrowserDialog.SelectedPath;

                    // Save the selected folder path to application settings
                    Properties.Settings.Default["MaintenanceRootFolder"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();

                    // Update path for current session
                    MaintenanceRootPath = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Update the TextBox with the selected folder path
                    folderBrowserDialog3.SelectedPath = folderBrowserDialog.SelectedPath;

                    // update UI
                    textBox3.Text = folderBrowserDialog.SelectedPath;

                    // Save the selected folder path to application settings
                    Properties.Settings.Default["VueCoreRootFolder"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();

                    // Update path for current session
                    VueCoreRootPath = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void ConnectToStagingDb_Click(object sender, EventArgs e)
        {
            var appSettingsPath = @"C:\Users\Leonid XPS 15\Documents\GitHub\Api\Maintenance\src\BuildingLink.Maintenance.Api\appsettings.Local.json";
            try
            {
                // Read the existing configuration
                var json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                // Modify the connection string
                jsonObj["ConnectionStrings"]["Maintenance"] = "Data Source=tcp:SqlCoreDevAGL.buildinglink.local,1433;Initial Catalog=Maintenance;User ID=maintenance;Password=76Ya#12jmhd#;Max Pool Size=10000;MultipleActiveResultSets=True;Connect Timeout=5;Application Name=BuildingLink.Maintenance.Api;ApplicationIntent=ReadWrite;MultiSubnetFailover=True;ConnectRetryCount=20;ConnectRetryInterval=1;Encrypt=True;TrustServerCertificate=True;";

                // Write the updated configuration back to the file
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
            var appSettingsPath = @"C:\Users\Leonid XPS 15\Documents\GitHub\Api\Maintenance\src\BuildingLink.Maintenance.Api\appsettings.Local.json";
            try
            {
                // Read the existing configuration
                var json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                // Modify the connection string
                jsonObj["ConnectionStrings"]["Maintenance"] = "Data Source=localhost;Initial Catalog=Maintenance;User ID=sa;Password=Password1!;Encrypt=True;TrustServerCertificate=True;";

                // Write the updated configuration back to the file
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
            var appSettingsPath = @"C:\Users\Leonid XPS 15\Documents\GitHub\Api\Maintenance\src\BuildingLink.Maintenance.Api\appsettings.Local.json";
            var json = File.ReadAllText(appSettingsPath);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var connectionString = jsonObj["ConnectionStrings"]["Maintenance"].ToString();

            // Set label text based on the connection string
            if (connectionString.Contains("localhost"))
            {
                label2.Text = "Currently using Local DB";
            }
            else
            {
                label2.Text = "Currently using Staging DB";
            }
        }
    }
}