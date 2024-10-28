using CsvHelper;
using ExportEmployeesToPmc.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.FileSupport
{
    internal class FileSaveCsv : FileSaveBase
    {
        List<EmployeeDto> employees;

        static string fullFolderPath = baseFolderName + "\\file";
        static string fullFilePath = fullFolderPath + "\\users.csv";

        private bool output = false;

        public FileSaveCsv()
        {
            
        }
        public FileSaveCsv(List<EmployeeDto> employees)
        {
            this.employees = employees;
        }

        public string GetFullFilePath()
        {
            return fullFilePath;
        }

        public override void Save()
        {
            IfFolderExist(baseFolderName);
            IfFolderExist(fullFolderPath);
            IfFileExist(fullFilePath);

            try
            {
                using (StreamWriter writer = new StreamWriter(fullFilePath, false))
                {
                    using (CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvWriter.WriteRecords(employees);
                    }
                }

                output = true;
            }
            catch(Exception e)
            {
                new FileSaveError("FileSaveCsv", "Save", e).Save();
            }
        }

        public bool Output() => output;
    }
}
