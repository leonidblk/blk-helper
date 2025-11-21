using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowershellCommands.Services
{
    public class NodeVersionService
    {
        public async Task SwitchVersionAsync(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentException("Node version cannot be empty.", nameof(version));
            }

            var trimmed = version.Trim();
            var resolvedVersion = await ResolveVersionAsync(trimmed);

            // Switch to the exact resolved version.
            await RunCommandForOutputAsync($"nvm use {resolvedVersion}");

            // Verify the switch took effect.
            var current = await RunCommandForOutputAsync("nvm current");
            if (!current.Contains(resolvedVersion, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException($"nvm did not switch to {resolvedVersion}. Check that system Node is not first in PATH and use the exact patch version installed by nvm.");
            }
        }

        public async Task<NodeVersionResult> TrySwitchVersionAsync(string? version)
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                return NodeVersionResult.Fail("Please select a Node version.");
            }

            if (!version.Contains(".", StringComparison.Ordinal))
            {
                return NodeVersionResult.Fail("Use the full Node version (including patch), e.g. 18.19.1. If it is not installed, run `nvm install 18.19.1` first.");
            }

            try
            {
                await SwitchVersionAsync(version);
                return NodeVersionResult.CreateSuccess($"Switched to Node {version}.", version.TrimStart('v', 'V'));
            }
            catch (Exception ex)
            {
                return NodeVersionResult.Fail($"Failed to switch Node version: {ex.Message}");
            }
        }

        public async Task<string> GetCurrentVersionAsync()
        {
            var output = await RunCommandForOutputAsync("nvm current");

            if (string.IsNullOrWhiteSpace(output) || output.Contains("none", StringComparison.OrdinalIgnoreCase))
            {
                output = await RunCommandForOutputAsync("node -v");
            }

            return string.IsNullOrWhiteSpace(output) ? "Unknown" : output.Trim();
        }

        public async Task<string> CopyCurrentVersionToClipboardAsync()
        {
            var version = await GetCurrentVersionAsync();
            var cleanVersion = version.TrimStart('v', 'V');
            Clipboard.SetText(cleanVersion);
            return cleanVersion;
        }

        public async Task<NodeVersionResult> GetVersionStatusAsync()
        {
            try
            {
                var version = await GetCurrentVersionAsync();
                var cleanVersion = version.TrimStart('v', 'V');
                return NodeVersionResult.CreateSuccess($"Node: {cleanVersion}", cleanVersion);
            }
            catch (Exception ex)
            {
                return NodeVersionResult.Fail($"Unable to determine Node version: {ex.Message}");
            }
        }

        private static async Task<string> RunCommandForOutputAsync(string command)
        {
            var processStartInfo = new ProcessStartInfo("powershell.exe")
            {
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -Command \"{command}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process
            {
                StartInfo = processStartInfo
            };

            process.Start();

            var standardOutputTask = process.StandardOutput.ReadToEndAsync();
            var standardErrorTask = process.StandardError.ReadToEndAsync();

            await Task.WhenAll(standardOutputTask, standardErrorTask);
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                var error = standardErrorTask.Result;
                throw new InvalidOperationException(string.IsNullOrWhiteSpace(error) ? "Unknown error executing command." : error.Trim());
            }

            return standardOutputTask.Result;
        }

        private static async Task<string> ResolveVersionAsync(string versionInput)
        {
            var versions = await GetInstalledVersionsAsync();
            var target = versionInput.TrimStart('v');

            // If full version supplied, require an exact match from nvm list.
            if (target.Contains(".", StringComparison.Ordinal))
            {
                var match = versions.FirstOrDefault(v => string.Equals(v, target, StringComparison.OrdinalIgnoreCase));
                if (match == null)
                {
                    throw new InvalidOperationException($"Could not find Node {target} in nvm list. Installed: {string.Join(", ", versions)}.");
                }
                return match;
            }

            // Otherwise resolve to the highest installed version with the requested major.
            var candidates = versions
                .Select(v => new { Raw = v, Parsed = Version.TryParse(v, out var ver) ? ver : null })
                .Where(x => x.Parsed != null && x.Parsed.Major.ToString() == target)
                .OrderByDescending(x => x.Parsed)
                .ToList();

            if (!candidates.Any())
            {
                throw new InvalidOperationException($"Could not find Node {target}.x in nvm list. Installed: {string.Join(", ", versions)}.");
            }

            return candidates.First().Raw;
        }

        public static async Task<IReadOnlyList<string>> GetInstalledVersionsAsync()
        {
            var listOutput = await RunCommandForOutputAsync("nvm list");
            var found = new List<string>();

            foreach (var rawLine in listOutput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var line = rawLine.Trim().TrimStart('*').Trim(); // remove active marker and whitespace
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Skip aliases and labels
                if (!char.IsDigit(line.FirstOrDefault()) && !(line.StartsWith("v", StringComparison.Ordinal) && line.Length > 1 && char.IsDigit(line[1])))
                {
                    continue;
                }

                var clean = line.TrimStart('v');
                if (Version.TryParse(clean, out _))
                {
                    found.Add(clean);
                }
            }

            return found;
        }
    }

    public class NodeVersionResult
    {
        public bool Success { get; }
        public string Message { get; }
        public string Version { get; }

        private NodeVersionResult(bool success, string message, string version = "")
        {
            Success = success;
            Message = message;
            Version = version;
        }

        public static NodeVersionResult CreateSuccess(string message, string version) => new(true, message, version);
        public static NodeVersionResult Fail(string message) => new(false, message);
    }
}
