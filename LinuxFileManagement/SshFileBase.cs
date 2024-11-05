using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.LinuxFileManagement
{
    internal abstract class SshFileBase
    {

        internal string sshHost = "xxxx.xxxx.xxx";
        internal string user = "xxx";
        internal string password = "xxxxxxxxx";

        internal string sshInPmcFolderPath = "/IN_PMC/";
        internal string sshInPmcOldFolderPath = "/IN_PMC/old/";

        internal string baseFileName = "users.csv";
    }
}
