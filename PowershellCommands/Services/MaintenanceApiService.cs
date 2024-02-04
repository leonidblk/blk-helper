using Newtonsoft.Json;
using PowershellCommands.Models;
using PowershellCommands;
using System;
using System.Diagnostics;
using System.IO;

namespace PowershellCommands.Services
{
    public class MaintenanceApiService
    {
        private readonly ApplicationPaths _paths;

        public MaintenanceApiService(ApplicationPaths paths)
        {
            _paths = paths;
        }

        public void AddMigration(string migrationName)
        {
            string migrationCommand = $"cd {_paths.MaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api; " +
                                      "$env:ASPNETCORE_ENVIRONMENT = 'Local'; " +
                                      $"dotnet ef migrations add {migrationName} " +
                                      "--project ..\\BuildingLink.Maintenance.Repositories\\" +
                                      " --output-dir Data\\Migrations";

            PowerShellCommandExecutor.RunCommand(migrationCommand);
        }

        public void UpdateDatabaseConnectionString(string connectionString)
        {
            var appSettingsPath = $"{_paths.MaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api\\appsettings.Local.json";

            if (File.Exists(appSettingsPath))
            {
                var json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                jsonObj["ConnectionStrings"]["Maintenance"] = connectionString;

                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(appSettingsPath, output);
            }
        }

        public void StartMaintenanceApi()
        {
            var startCommand = $"cd \"{_paths.MaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api\"; dotnet run";
            PowerShellCommandExecutor.RunCommand(startCommand);
        }

        public void RunMaintenanceMigration()
        {
            var cleanedMaintenanceRootPath = _paths.MaintenanceRootPath.Replace("`", "");
            var appSettingsPath = $"{cleanedMaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api\\appsettings.Local.json";

            try
            {
                if (!File.Exists(appSettingsPath))
                {
                    throw new FileNotFoundException("App settings file not found.");
                }

                var json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                var connectionString = jsonObj["ConnectionStrings"]["Maintenance"].ToString();

                if (!connectionString.Contains("localhost"))
                {
                    throw new InvalidOperationException("Cannot perform migration: not connected to a local database.");
                }

                string command = "$env:ASPNETCORE_ENVIRONMENT = 'Local'; dotnet ef database update";

                PowerShellCommandExecutor.RunCommand(command, cleanedMaintenanceRootPath + "\\src\\BuildingLink.Maintenance.Api");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}