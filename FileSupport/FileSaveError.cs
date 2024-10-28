using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.FileSupport
{
    internal class FileSaveError : FileSaveBase
    {
        private readonly string className;
        private readonly string methodName;
        private Exception exception;
        public FileSaveError(string className, string methodName, Exception e)
        {
            this.className = className;
            this.methodName = methodName;
            this.exception = e;
        }
        public override void Save()
        {
            try
            {
                string fullFolderPath = baseFolderName + "\\errors";
                string fullFilePath = fullFolderPath + "\\" + DateTime.Now.ToShortDateString() + ".txt";

                IfFolderExist(baseFolderName);
                IfFolderExist(fullFolderPath);

                using (StreamWriter writer = new StreamWriter(fullFilePath, true))
                {
                    writer.WriteLine("----------------------------------------");

                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine("Class: " + className);
                    writer.WriteLine("Method: " + methodName);

                    writer.WriteLine();

                    while (exception != null)
                    {
                        writer.WriteLine(exception.GetType().FullName);
                        writer.WriteLine("InnerException : " + exception.InnerException);
                        writer.WriteLine("Message : " + exception.Message);
                        writer.WriteLine("Source : " + exception.Source);
                        writer.WriteLine("StackTrace : " + exception.StackTrace);
                        writer.WriteLine("TargetSite : " + exception.TargetSite);

                        exception = exception.InnerException;
                    }

                    writer.WriteLine("");
                    writer.WriteLine("----------------------------------------");
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Błąd aplikacji / bład zapisu do pliku / zalecany kontakt z IT: {e.Message}");
            }
        }
    }
}
