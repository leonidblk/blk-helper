using PowershellCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowershellCommands.Services
{
    public class VueWebsiteCoreService
    {
        private readonly ApplicationPaths _paths;

        public VueWebsiteCoreService(ApplicationPaths paths)
        {
            _paths = paths;
        }

        public void UpdateConfigurationForLocalAPI()
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

            var pathToFile = $"{_paths.VueCoreMicroRootPath}\\config\\env-settings-local.yaml";

            File.WriteAllText(pathToFile, newConfiguration);
        }

        public void StartVueApplication()
        {
            var command = "yarn dev";
            PowerShellCommandExecutor.RunCommand(command, _paths.VueCoreMicroRootPath);
        }

        public void ConnectToDevMaintApi()
        {
            var pathToFile = $"{_paths.VueCoreMicroRootPath}\\config\\env-settings-local.yaml";

            try
            {
                var lines = File.ReadAllLines(pathToFile);

                // Comment out all lines
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = "#" + lines[i];
                }

                File.WriteAllLines(pathToFile, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
