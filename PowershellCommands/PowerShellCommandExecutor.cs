using System;
using System.Diagnostics;

namespace PowershellCommands
{
    public static class PowerShellCommandExecutor
    {
        public static void RunCommand(string command, string workingDirectory = "")
        {
            ProcessStartInfo processInfo = new ("powershell.exe")
            {
                Arguments = $"-NoExit -NoProfile -ExecutionPolicy unrestricted -Command \"{command}\"",
                UseShellExecute = false,
                CreateNoWindow = false,
                WorkingDirectory = workingDirectory
            };

            try
            {
                using (Process process = Process.Start(processInfo))
                {
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred executing PowerShell command: {ex.Message}");
            }
        }
    }
}