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
            var normalizedTarget = NormalizeVersion(resolvedVersion);

            await EnsureVersionInstalledAsync(resolvedVersion);

            // Switch to the exact resolved version.
            var useResult = await TryRunCommandAsync($"nvm use {resolvedVersion}");
            if (!useResult.IsSuccess)
            {
                throw new InvalidOperationException(useResult.Message);
            }

            // Verify the switch took effect.
            var nodeRaw = await TryGetNodeVersionAsync();
            var nodeVersion = NormalizeVersion(nodeRaw);

            if (string.Equals(nodeVersion, normalizedTarget, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            // Fallback to nvm current if node -v did not match.
            var currentRaw = await RunCommandForOutputAsync("nvm current");
            var current = NormalizeVersion(currentRaw);

            if (!string.Equals(current, normalizedTarget, StringComparison.OrdinalIgnoreCase))
            {
                var message = $"nvm did not switch to {resolvedVersion}.";

                if (!string.IsNullOrWhiteSpace(currentRaw))
                {
                    message += $" nvm current: '{currentRaw.Trim()}'.";
                }

                if (!string.IsNullOrWhiteSpace(nodeRaw))
                {
                    message += $" node -v: '{nodeRaw.Trim()}'.";
                }

                message += " Check that system Node is not first in PATH and use the exact patch version installed by nvm.";

                throw new InvalidOperationException(message);
            }
        }

        public async Task<NodeVersionResult> TrySwitchVersionAsync(string? version)
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                return NodeVersionResult.Fail("Please select a Node version.");
            }

            var normalizedInput = NormalizeVersion(version);

            if (string.IsNullOrWhiteSpace(normalizedInput))
            {
                return NodeVersionResult.Fail("Please select a Node version.");
            }

            if (!normalizedInput.Contains(".", StringComparison.Ordinal))
            {
                return NodeVersionResult.Fail("Use the full Node version (including patch), e.g. 18.19.1. If it is not installed, run `nvm install 18.19.1` first.");
            }

            try
            {
                await SwitchVersionAsync(normalizedInput);
                return NodeVersionResult.CreateSuccess($"Switched to Node {normalizedInput}.", normalizedInput);
            }
            catch (Exception ex)
            {
                return NodeVersionResult.Fail($"Failed to switch Node version: {ex.Message}");
            }
        }

        public async Task<NodeVersionResult> ForceSwitchVersionWithCacheClearAsync(string? version)
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                return NodeVersionResult.Fail("Please select a Node version.");
            }

            var normalizedInput = NormalizeVersion(version);

            if (!normalizedInput.Contains(".", StringComparison.Ordinal))
            {
                return NodeVersionResult.Fail("Use the full Node version (including patch), e.g. 18.19.1. If it is not installed, run `nvm install 18.19.1` first.");
            }

            try
            {
                var resolved = await ResolveVersionAsync(normalizedInput);

                var cleanupCommands = new[]
                {
                    "taskkill /F /IM node.exe",
                    "taskkill /F /IM npm.exe",
                    "taskkill /F /IM node",
                    "Remove-Item \"C:\\\\Program Files\\\\nodejs*\" -Recurse -Force -ErrorAction SilentlyContinue"
                };

                foreach (var command in cleanupCommands)
                {
                    await TryRunCommandAllowErrorsAsync(command);
                }

                await SwitchVersionAsync(resolved);

                var finalVersion = await GetCurrentVersionAsync();
                var cleanVersion = finalVersion.TrimStart('v', 'V');

                return NodeVersionResult.CreateSuccess($"Force-switched to Node {cleanVersion}.", cleanVersion);
            }
            catch (Exception ex)
            {
                return NodeVersionResult.Fail($"Failed to force switch Node version: {ex.Message}");
            }
        }

        public async Task<string> GetCurrentVersionAsync()
        {
            var output = await RunCommandForOutputAsync("nvm current");
            var normalized = NormalizeVersion(output);

            if (string.IsNullOrWhiteSpace(normalized) || normalized.Contains("none", StringComparison.OrdinalIgnoreCase))
            {
                output = await RunCommandForOutputAsync("node -v");
                normalized = NormalizeVersion(output);
            }

            return string.IsNullOrWhiteSpace(normalized) ? "Unknown" : normalized;
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
            var target = NormalizeVersion(versionInput);

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

                var clean = NormalizeVersion(line);
                if (Version.TryParse(clean, out _))
                {
                    found.Add(clean.Trim());
                }
            }

            return found;
        }

        private static string NormalizeVersion(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            var firstLine = value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()?.Trim() ?? string.Empty;
            var withoutPrefix = firstLine.TrimStart('v', 'V').Trim();
            var digitsOnly = new string(withoutPrefix.TakeWhile(c => char.IsDigit(c) || c == '.').ToArray());

            return string.IsNullOrWhiteSpace(digitsOnly) ? withoutPrefix : digitsOnly;
        }

        private static async Task<string> TryGetNodeVersionAsync()
        {
            try
            {
                return await RunCommandForOutputAsync("node -v");
            }
            catch
            {
                return string.Empty;
            }
        }

        private static async Task EnsureVersionInstalledAsync(string version)
        {
            var versions = await GetInstalledVersionsAsync();
            if (versions.Any(v => string.Equals(v, NormalizeVersion(version), StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            var installResult = await TryRunCommandAsync($"nvm install {version}");
            if (!installResult.IsSuccess)
            {
                throw new InvalidOperationException($"Failed to install Node {version} via nvm: {installResult.Message}");
            }
        }

        private static async Task<NodeUseResult> TryRunCommandAsync(string command)
        {
            try
            {
                var output = (await RunCommandForOutputAsync(command)).Trim();
                if (IsUseFailure(output))
                {
                    return NodeUseResult.FromFailure(output);
                }

                return NodeUseResult.FromSuccess(string.IsNullOrWhiteSpace(output) ? "(no output)" : output);
            }
            catch (Exception ex)
            {
                return NodeUseResult.FromFailure(ex.Message);
            }
        }

        private static bool IsUseFailure(string output)
        {
            if (string.IsNullOrWhiteSpace(output))
            {
                return false;
            }

            return output.IndexOf("not installed", StringComparison.OrdinalIgnoreCase) >= 0
                || output.IndexOf("could not find", StringComparison.OrdinalIgnoreCase) >= 0
                || output.IndexOf("is not recognized", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static async Task TryRunCommandAllowErrorsAsync(string command)
        {
            try
            {
                await RunCommandForOutputAsync(command);
            }
            catch
            {
                // Ignore failures for cleanup attempts; they are best-effort.
            }
        }

        private record NodeUseResult(bool IsSuccess, string Message, string Output)
        {
            public static NodeUseResult FromSuccess(string output) => new(true, string.Empty, output);
            public static NodeUseResult FromFailure(string message) => new(false, message, message);
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
