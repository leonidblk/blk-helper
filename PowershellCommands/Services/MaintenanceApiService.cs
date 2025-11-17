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
        private readonly ConfigurationService _configurationService;

        public MaintenanceApiService(ApplicationPaths paths, ConfigurationService configurationService)
        {
            _paths = paths;
            _configurationService = configurationService;
        }

        public async Task AddMigration(string migrationName)
        {
            string migrationCommand = $"cd {_paths.MaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api; " +
                                      "$env:ASPNETCORE_ENVIRONMENT = 'Local'; " +
                                      $"dotnet ef migrations add {migrationName} " +
                                      "--project ..\\BuildingLink.Maintenance.Repositories\\" +
                                      " --output-dir Data\\Migrations";

            await PowerShellCommandExecutor.RunCommandAsync(migrationCommand);
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

        public async Task StartMaintenanceApi()
        {
            var startCommand = $"cd \"{_paths.MaintenanceRootPath}\\src\\BuildingLink.Maintenance.Api\"; dotnet run";
            await PowerShellCommandExecutor.RunCommandAsync(startCommand);
        }

        public async Task RunMaintenanceMigration()
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

                await PowerShellCommandExecutor.RunCommandAsync(command, cleanedMaintenanceRootPath + "\\src\\BuildingLink.Maintenance.Api");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public void UpdateConnectionStringToStaging()
        {
            var connectionString = _configurationService.GetConnectionString("Maintenance", "Staging");
            UpdateConnectionString(connectionString);
        }

        public void UpdateConnectionStringToLocal()
        {
            var connectionString = _configurationService.GetConnectionString("Maintenance", "Local");
            UpdateConnectionString(connectionString);
        }

        public string GetDatabaseConnectionStatus()
        {
            var appSettingsPath = $"{_paths.MaintenanceRootPath.Replace("` ", " ")}\\src\\BuildingLink.Maintenance.Api\\appsettings.Local.json";

            if (File.Exists(appSettingsPath))
            {
                var json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                if (jsonObj["ConnectionStrings"]?["Maintenance"] != null)
                {
                    var connectionString = jsonObj["ConnectionStrings"]["Maintenance"].ToString();
                    return connectionString.Contains("localhost") ? "Currently using Local DB" : "Currently using Staging DB";
                }
                return "Maintenance connection string not found.";
            }

            return "";
        }

        private void UpdateConnectionString(string connectionString)
        {
            var appSettingsPath = $"{_paths.MaintenanceRootPath.Replace("`", "")}\\src\\BuildingLink.Maintenance.Api\\appsettings.Local.json";

            try
            {
                if (!File.Exists(appSettingsPath))
                {
                    throw new FileNotFoundException("App settings file not found.");
                }

                var json = File.ReadAllText(appSettingsPath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["ConnectionStrings"]["Maintenance"] = connectionString;

                string output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(appSettingsPath, output);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the connection string: {ex.Message}");
                throw;
            }
        }
    }
}