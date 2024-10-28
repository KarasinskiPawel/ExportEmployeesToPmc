using ExportEmployeesToPmc.Dto;
using ExportEmployeesToPmc.FileSupport;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.Mappers
{
    internal class MPracownicyExportPMC
    {
        DataTable table;
        List<EmployeeDto> employees = new List<EmployeeDto>(); 

        public MPracownicyExportPMC(DataTable dataTable)
        {
            table = dataTable;
        }

        public List<EmployeeDto> GetEmployees()
        {
            try
            {
                employees = table
                    .AsEnumerable()
                    .Select(a => new EmployeeDto
                    {
                        IdPracownika = a.Field<int>("IdPracownika"),
                        Login = a.Field<string>("Login"),
                        Osokod = a.Field<string>("Osokod"),
                        Nazwisko = a.Field<string>("Nazwisko"),
                        Imie = a.Field<string>("Imie"),
                        RegionPion = a.Field<string>("RegionPion"),
                        LokalizacjaDzial = a.Field<string>("LokalizacjaDzial"),
                        MiejsceStruktura = a.Field<string>("MiejsceStruktura"),
                        StatusPracownika = a.Field<string>("StatusPracownika"),
                        DataZmianyStanowiska = a.Field<string?>("DataZmianyStanowiska"),
                        DataZwolnienia = a.Field<string>("DataZwolnienia"),
                        StatusZatrudnienia = a.Field<string>("StatusZatrudnienia"),
                        IdPracownikPrzelozony = a.Field<int?>("IdPracownikaPrzelozony"),
                        NazwiskoPrzelozony = a.Field<string>("NazwiskoPrzelozony"),
                        ImiePrzelozony = a.Field<string>("ImiePrzelozony"),
                        Etat = a.Field<string>("Etat"),
                        Email = a.Field<string>("Email"),
                        Telefon = a.Field<string>("Telefon")
                    }).ToList();
            }
            catch(Exception e)
            {
                new FileSaveError("MPracownicyExportPMC", "GetEmployees", e).Save();
            }

            return employees;
        }

        private string ConvertDateToString(dynamic date)
        {
            string output = string.Empty;

            try
            {
                if (date == null)
                    return output;

                if (date.HasValue)
                {
                    if (DateTime.TryParse(date, out DateTime result))
                    {
                        output = result.ToShortDateString();
                    }
                    else
                    {
                        output = date;
                    }
                }
            }
            catch(Exception e)
            {
                new FileSaveError("MPracownicyExportPMC", "ConvertDateToString", e).Save();
            }

            return output;
        }
    }
}
