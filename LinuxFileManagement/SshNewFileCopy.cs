using ExportEmployeesToPmc.FileSupport;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.LinuxFileManagement
{
    internal class SshNewFileCopy : SshFileBase
    {
        public bool Save(string localFilePath)
        {
            bool result = false;

            string fullFilePath = Path.Combine(sshInPmcFolderPath,baseFileName);

            using(SftpClient sftpClient = new SftpClient(sshHost, user, password))
            {
                try
                {
                    sftpClient.Connect();

                    if (sftpClient.Exists(sshInPmcFolderPath))
                    {
                        using (FileStream fileStream = new FileStream(localFilePath, FileMode.Open))
                        {
                            sftpClient.UploadFile(fileStream, fullFilePath);
                        }
                    }

                    result = true;
                }
                catch(Exception e)
                {
                    new FileSaveError("SshNewFileCopy", "Save", e).Save();
                }
                finally
                {
                    sftpClient.Disconnect();
                }
            }

            return result;
        }
    }
}
