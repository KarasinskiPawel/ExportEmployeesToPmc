using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.FileSupport
{
    internal class FileSaveLog : FileSaveBase
    {
        private readonly string message;

        public FileSaveLog(string message)
        { 
        this.message = message;
        }
        public override void Save()
        {
            try
            {
                string fullFolderPath = baseFolderName + "\\Logs";
                string fullFilePath = fullFolderPath + "\\" + DateTime.Now.ToShortDateString() + ".txt";

                IfFolderExist(baseFolderName);
                IfFolderExist(fullFolderPath);

                using (StreamWriter writer = new StreamWriter(fullFilePath, true))
                {
                    writer.WriteLine(message);
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine($"FileSaveLog.Save(): {e.Message}");
            }
        }
    }
}
