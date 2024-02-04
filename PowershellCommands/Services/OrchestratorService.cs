using Newtonsoft.Json;
using PowershellCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void StartOrchestrator()
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
                PowerShellCommandExecutor.RunCommand("yarn dev", cleanedVueOrchestratorPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
