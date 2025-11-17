using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowershellCommands.Models
{
    public class ApplicationPaths
    {
        public string? MaintenanceRootPath { get; set; }
        public string? VueCoreMicroRootPath { get; set; }
        public string? VueOrchestratorPath { get; set; }
        public string? EventLogRootPath { get; set; }
        public string? EventLogVueRootPath { get; set; }
        public string? TsApiClientRootPath { get; set; }
    }
}
