using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Microsoft.OpenApi.Writers;
using PowershellCommands.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
                await using var responseStream = await httpClient.GetStreamAsync(apiUrl);
                var reader = new OpenApiStreamReader();
                var document = reader.Read(responseStream, out var diagnostic);

                if (diagnostic.Errors.Any())
                {
                    var errorMessages = string.Join(Environment.NewLine, diagnostic.Errors.Select(e => e.Message));
                    throw new InvalidOperationException($"Failed to parse API definition:{Environment.NewLine}{errorMessages}");
                }

                ApplyDocumentOverrides(document, apiUrl);

                using var textWriter = new StringWriter();
                var yamlWriter = new OpenApiYamlWriter(textWriter);
                document.SerializeAsV3(yamlWriter);
                var yaml = textWriter.ToString();

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
            var yaml = await DownloadApiDefinitionAsync(apiUrl);

            // Save the YAML to the appropriate file
            string rootPath = GetRootPath();
            string filePath = Path.Combine(rootPath, "defs", "api-buildinglink-com", "EventLog-PropertyEmployee-v3.yaml");

            await File.WriteAllTextAsync(filePath, yaml);
            Console.WriteLine($"YAML definition saved to: {filePath}");

            return yaml;
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

        public async Task GenerateTypeScriptClientAsync()
        {
            string rootPath = GetRootPath();

            Console.WriteLine("Running `yarn` to regenerate the TypeScript client. This may take a while...");
            await PowerShellCommandExecutor.RunCommandAsync("yarn", rootPath);
        }

        private static void ApplyDocumentOverrides(OpenApiDocument document, string apiUrl)
        {
            if (!apiUrl.Contains("PropertyEmployee-v3", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            document.Info.Version = "EventLog/PropertyEmployee/v3";

            var gatewayServer = document.Servers.FirstOrDefault(s =>
                string.Equals(s.Description, "API Gateway", StringComparison.OrdinalIgnoreCase))
                ?? document.Servers.FirstOrDefault(s => s.Url?.Contains("localhost:44382", StringComparison.OrdinalIgnoreCase) == true);

            if (gatewayServer != null)
            {
                gatewayServer.Url = "/EventLog/PropertyEmployee/v3";
                if (string.IsNullOrWhiteSpace(gatewayServer.Description))
                {
                    gatewayServer.Description = "API Gateway";
                }
            }
            else
            {
                document.Servers.Add(new OpenApiServer
                {
                    Url = "/EventLog/PropertyEmployee/v3",
                    Description = "API Gateway"
                });
            }
        }
    }
}
