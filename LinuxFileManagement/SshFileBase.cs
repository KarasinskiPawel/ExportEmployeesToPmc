using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.LinuxFileManagement
{
    internal abstract class SshFileBase
    {

        internal string sshHost = "sftp.komfort.pl";
        internal string user = "pmc";
        internal string password = "7B6Ov2a8nq9B7Cfp";

        internal string sshInPmcFolderPath = "/IN_PMC/";
        internal string sshInPmcOldFolderPath = "/IN_PMC/old/";

        internal string baseFileName = "users.csv";
    }
}
