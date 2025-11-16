using Newtonsoft.Json;
using PowershellCommands.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PowershellCommands.Services
{
    public class EventLogApiService
    {
        private readonly ApplicationPaths _paths;
        private const string LocalConnectionString = "host=localhost;Port=5432;Database=EventLog;Username=postgres;Password=Password1!;";
        private const string DevConnectionString = "host=development1-20230809184014540300000002.cqsye0eggz8b.us-east-1.rds.amazonaws.com;Port=5432;Database=EventLog;Username=eventlog;Password=%ePyqdPx6y+Z0qjj;Maximum Pool Size=500;";

        public EventLogApiService(ApplicationPaths paths)
        {
            _paths = paths;
        }

        public async Task AddMigration(string migrationName)
        {
            string apiPath = GetApiDirectory();
            string command = $"cd \"{apiPath}\"; $env:ASPNETCORE_ENVIRONMENT = 'Local'; dotnet ef migrations add {migrationName} --project ..\\BuildingLink.EventLog.Repositories\\ --output-dir Migrations";

            await PowerShellCommandExecutor.RunCommandAsync(command);
        }

        public async Task StartEventLogApi()
        {
            string apiPath = GetApiDirectory();
            string command = $"cd \"{apiPath}\"; dotnet run";

            await PowerShellCommandExecutor.RunCommandAsync(command);
        }

        public async Task RunEventLogMigration()
        {
            string apiPath = GetApiDirectory();
            string appSettingsPath = Path.Combine(apiPath, "appsettings.Local.json");

            if (!File.Exists(appSettingsPath))
            {
                throw new FileNotFoundException("App settings file not found.");
            }

            var json = File.ReadAllText(appSettingsPath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            var connectionString = jsonObj["ConnectionStrings"]?["ApplicationDb"]?.ToString() ?? string.Empty;

            if (!connectionString.Contains("localhost", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Cannot perform migration: not connected to a local database.");
            }

            string command = "$env:ASPNETCORE_ENVIRONMENT = 'Local'; dotnet ef database update";
            await PowerShellCommandExecutor.RunCommandAsync(command, apiPath);
        }

        public void UpdateConnectionStringToLocal() => UpdateConnectionString(LocalConnectionString);

        public void UpdateConnectionStringToDev() => UpdateConnectionString(DevConnectionString);

        public string GetDatabaseConnectionStatus()
        {
            string appSettingsPath = Path.Combine(GetApiDirectory(), "appsettings.Local.json");

            if (!File.Exists(appSettingsPath))
            {
                return string.Empty;
            }

            var json = File.ReadAllText(appSettingsPath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            var connectionString = jsonObj["ConnectionStrings"]?["ApplicationDb"]?.ToString();

            if (connectionString == null)
            {
                return "EventLog connection string not found.";
            }

            return connectionString.Contains("localhost", StringComparison.OrdinalIgnoreCase)
                ? "Currently using Local DB"
                : "Currently using Dev DB";
        }

        private void UpdateConnectionString(string connectionString)
        {
            string appSettingsPath = Path.Combine(GetApiDirectory(), "appsettings.Local.json");

            if (!File.Exists(appSettingsPath))
            {
                throw new FileNotFoundException("App settings file not found.");
            }

            var json = File.ReadAllText(appSettingsPath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            jsonObj["ConnectionStrings"]["ApplicationDb"] = connectionString;

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(appSettingsPath, output);
        }

        private string GetApiDirectory()
        {
            if (string.IsNullOrWhiteSpace(_paths.EventLogRootPath))
            {
                throw new InvalidOperationException("EventLog root path is not set.");
            }

            string cleanedRoot = _paths.EventLogRootPath.Replace("`", "");
            string directPath = Path.Combine(cleanedRoot, "BuildingLink.EventLog.Api");
            string nestedPath = Path.Combine(cleanedRoot, "src", "BuildingLink.EventLog.Api");

            if (Directory.Exists(directPath))
            {
                return directPath;
            }

            if (Directory.Exists(nestedPath))
            {
                return nestedPath;
            }

            throw new DirectoryNotFoundException($"Could not locate BuildingLink.EventLog.Api folder under '{cleanedRoot}'.");
        }
    }
}
