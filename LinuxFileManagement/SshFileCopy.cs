using ExportEmployeesToPmc.FileSupport;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.LinuxFileManagement
{
    internal class SshFileCopy : SshFileBase
    {
        public bool Save()
        {
            bool result = false;

            string fullFilePath = sshInPmcFolderPath + "/" + baseFileName;
            string fullFileDestinationPath = sshInPmcOldFolderPath + "/" + DateTime.Now.ToShortDateString() + " " + baseFileName;

            try
            {
                using (SftpClient sftpClient = new SftpClient(sshHost, user, password))
                {
                    sftpClient.Connect();

                    if (sftpClient.Exists(fullFilePath))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            sftpClient.DownloadFile(fullFilePath, memoryStream);
                            memoryStream.Position = 0;

                            sftpClient.UploadFile(memoryStream, fullFileDestinationPath);
                        }

                        sftpClient.DeleteFile(fullFilePath);
                    }

                    sftpClient.Disconnect();
                }

                result = true;
            }
            catch (Exception e)
            {
                new FileSaveError("SshFileCopy", "Save", e).Save();
            }

            return result;
        }
    }
}
