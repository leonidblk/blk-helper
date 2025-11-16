using Newtonsoft.Json;
using PowershellCommands.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace PowershellCommands.Services
{
    public class OrchestratorService
    {
        private readonly ApplicationPaths _paths;

        public OrchestratorService(ApplicationPaths paths)
        {
            _paths = paths;
        }

        public async Task StartOrchestrator()
        {
            var cleanedVueOrchestratorPath = _paths.VueOrchestratorPath.Replace("`", "");
            var jsonFilePath = $"{cleanedVueOrchestratorPath}\\src\\import-map.local.json";

            try
            {
                var json = File.ReadAllText(jsonFilePath);
                dynamic jsonObj = JsonConvert.DeserializeObject(json);

                jsonObj["imports"]["@buildinglink/bl-website-core-micro"] = "http://localhost:3000/js/index.vdev.js";

                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(jsonFilePath, output);

                // Use the PowerShellCommandExecutor utility class
                await PowerShellCommandExecutor.RunCommandAsync("yarn dev", cleanedVueOrchestratorPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task OpenInVisualStudioCode()
        {
            var cleanedVueOrchestratorPath = _paths.VueOrchestratorPath.Replace("`", "");

            if (!Directory.Exists(cleanedVueOrchestratorPath))
            {
                MessageBox.Show("Orchestrator root folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    var importMapPath = Path.Combine(cleanedVueOrchestratorPath, "src", "import-map.local.json");
                    string command = "/c code .";

                    if (File.Exists(importMapPath))
                    {
                        command += $" \"{importMapPath}\"";
                    }

                    var psi = new ProcessStartInfo("cmd.exe")
                    {
                        Arguments = command,
                        WorkingDirectory = cleanedVueOrchestratorPath,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process.Start(psi);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open in VS Code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
