using Newtonsoft.Json;
using System;
using System.IO;

namespace PowershellCommands.Services
{
    public class ConfigurationService
    {
        private const string ConfigFileName = "connectionstrings.local.json";
        private readonly string _configPath;
        private dynamic? _config;

        public ConfigurationService()
        {
            // Look for the config file in the project directory, not the bin directory
            var projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            if (projectDirectory == null)
            {
                throw new InvalidOperationException("Could not determine project directory.");
            }
            
            _configPath = Path.Combine(projectDirectory, ConfigFileName);
            LoadConfiguration();
        }

        public string GetConnectionString(string service, string environment)
        {
            try
            {
                if (_config == null)
                {
                    throw new InvalidOperationException("Configuration not loaded.");
                }

                var connectionString = _config["ConnectionStrings"]?[service]?[environment]?.ToString();
                
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException($"Connection string for {service}.{environment} not found.");
                }

                return connectionString!;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get connection string for {service}.{environment}: {ex.Message}", ex);
            }
        }

        public bool HasConfiguration()
        {
            return File.Exists(_configPath) && _config != null;
        }

        public string GetConfigurationPath()
        {
            return _configPath;
        }

        private void LoadConfiguration()
        {
            try
            {
                if (!File.Exists(_configPath))
                {
                    throw new FileNotFoundException($"Configuration file not found at: {_configPath}");
                }

                var json = File.ReadAllText(_configPath);
                _config = JsonConvert.DeserializeObject(json);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to load configuration from {_configPath}: {ex.Message}", ex);
            }
        }

        public void ReloadConfiguration()
        {
            LoadConfiguration();
        }
    }
}