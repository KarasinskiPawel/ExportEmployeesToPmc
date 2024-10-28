using ExportEmployeesToPmc.DbCRUD;
using ExportEmployeesToPmc.Dto;
using ExportEmployeesToPmc.FileSupport;
using ExportEmployeesToPmc.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.Handlers
{
    internal class PrepareEmployeesData : BaseHandler
    {
        List<EmployeeDto> employees;
        public override void HandleRequest(HandlerRequest request)
        {
            try
            {
                new FileSaveLog("Pobieranie danych...").Save();

                employees = new MPracownicyExportPMC(
                        new SpPracownicyExportPMC().GetEmployees()
                    ).GetEmployees();

                if(employees is not null && employees.Count > 0)
                {
                    request.DataDownloaded = true;
                    request.Employees = employees;

                    new FileSaveLog("Dane pobrane!").Save();
                }
                else
                {
                    new FileSaveLog("Brak danych! Error?").Save();
                }
            }
            catch (Exception e)
            {
                new FileSaveError("PrepareEmployeesData", "HandleRequest", e).Save();
            }
            finally
            {
                base.HandleRequest(request);
            }
        }
    }
}
