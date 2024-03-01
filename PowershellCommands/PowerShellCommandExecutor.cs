using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PowershellCommands
{
    public static class PowerShellCommandExecutor
    {
        public static async Task RunCommandAsync(string command, string workingDirectory = "")
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe")
            {
                Arguments = $"-NoExit -NoProfile -ExecutionPolicy unrestricted -Command \"{command}\"",
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
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred executing PowerShell command: {ex.Message}");
            }
        }
    }
}
