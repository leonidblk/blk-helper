using PowershellCommands.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PowershellCommands.Services
{
    public class EventLogVueService
    {
        private readonly ApplicationPaths _paths;

        public EventLogVueService(ApplicationPaths paths)
        {
            _paths = paths;
        }

        public async Task StartEventLogVueAsync()
        {
            string rootPath = GetRootPath();
            await PowerShellCommandExecutor.RunCommandAsync("yarn dev", rootPath);
        }

        private string GetRootPath()
        {
            if (string.IsNullOrWhiteSpace(_paths.EventLogVueRootPath))
            {
                throw new InvalidOperationException("EventLog Vue root path is not set.");
            }

            string cleanedPath = _paths.EventLogVueRootPath.Replace("`", "");
            if (!Directory.Exists(cleanedPath))
            {
                throw new DirectoryNotFoundException($"EventLog Vue root path '{cleanedPath}' was not found.");
            }

            return cleanedPath;
        }
    }
}
