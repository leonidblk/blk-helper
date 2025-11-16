using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace PowershellCommands
{
    public static class PowerShellCommandExecutor
    {
        public static async Task RunCommandAsync(string command, string workingDirectory = "")
        {
            string tempScriptPath = Path.Combine(Path.GetTempPath(), $"blk-helper-{Guid.NewGuid():N}.ps1");
            await File.WriteAllTextAsync(tempScriptPath, command);

            ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe")
            {
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -File \"{tempScriptPath}\"",
                UseShellExecute = false,
                CreateNoWindow = false,
                WorkingDirectory = workingDirectory
            };

            try
            {
                await Task.Run(() =>
                {
                    using (Process process = Process.Start(processInfo))
                    {
                        process.WaitForExit();
                        if (process.ExitCode != 0)
                        {
                            throw new InvalidOperationException($"PowerShell command exited with code {process.ExitCode}.");
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred executing PowerShell command: {ex.Message}");
                if (File.Exists(tempScriptPath))
                {
                    File.Delete(tempScriptPath);
                }
                throw;
            }
            finally
            {
                if (File.Exists(tempScriptPath))
                {
                    File.Delete(tempScriptPath);
                }
            }
        }
    }
}
