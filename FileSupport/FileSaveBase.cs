using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.FileSupport
{
    internal abstract class FileSaveBase : IFileSave
    {
        protected const string baseFolderName = @"C:\ExportEmployeesToPmc";
        public abstract void Save();

        internal void IfFolderExist(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

        internal void IfFileExist(string filePath)
        {
            if(File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
