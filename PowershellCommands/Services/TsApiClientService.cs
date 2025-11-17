using PowershellCommands.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PowershellCommands.Services
{
    public class TsApiClientService
    {
        private readonly ApplicationPaths _paths;
        private static readonly HttpClient httpClient = new HttpClient();

        public TsApiClientService(ApplicationPaths paths)
        {
            _paths = paths;
        }

        public async Task<string> DownloadApiDefinitionAsync(string apiUrl)
        {
            try
            {
                var response = await httpClient.GetStringAsync(apiUrl);

                // Convert JSON to YAML
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();
                var serializer = new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var jsonObject = deserializer.Deserialize<object>(response);
                var yaml = serializer.Serialize(jsonObject);

                // Log YAML to console
                Console.WriteLine("API Definition downloaded successfully (YAML):");
                Console.WriteLine(yaml);

                return yaml;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading API definition: {ex.Message}");
                throw new InvalidOperationException($"Failed to download API definition from {apiUrl}: {ex.Message}", ex);
            }
        }

        public async Task<string> DownloadEventLogApiDefinitionAsync()
        {
            const string apiUrl = "https://eventlog-lborigin.development.buildinglink.com/swagger/PropertyEmployee-v3/swagger.json";
            return await DownloadApiDefinitionAsync(apiUrl);
        }

        public async Task SaveApiDefinitionToFileAsync(string apiDefinition, string? fileName = null)
        {
            try
            {
                string rootPath = GetRootPath();
                string filePath = Path.Combine(rootPath, fileName ?? "api-definition.yaml");

                await File.WriteAllTextAsync(filePath, apiDefinition);
                Console.WriteLine($"API definition saved to: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving API definition: {ex.Message}");
                throw new InvalidOperationException($"Failed to save API definition: {ex.Message}", ex);
            }
        }

        private string GetRootPath()
        {
            if (string.IsNullOrWhiteSpace(_paths.TsApiClientRootPath))
            {
                throw new InvalidOperationException("TS API Client root path is not set.");
            }

            string cleanedPath = _paths.TsApiClientRootPath.Replace("`", "");
            if (!Directory.Exists(cleanedPath))
            {
                throw new DirectoryNotFoundException($"TS API Client root path '{cleanedPath}' was not found.");
            }

            return cleanedPath;
        }
    }
}