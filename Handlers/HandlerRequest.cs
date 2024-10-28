using ExportEmployeesToPmc.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.Handlers
{
    internal class HandlerRequest
    {
        public bool DataDownloaded { get; set; } = false;
        public bool FileCreated { get; set; }
        public bool PreviousFileWasCopied { get; set; } = false;
        public List<EmployeeDto> Employees { get; set; }
    }
}
