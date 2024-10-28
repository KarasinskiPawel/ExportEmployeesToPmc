using ExportEmployeesToPmc.FileSupport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.DbCRUD
{
    internal class SpPracownicyExportPMC
    {
        DataTable dataTable = new DataTable();

        public DataTable GetEmployees()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(AppConfiguration.GetConnectionString("DefaultConnection")))
                {
                    sqlConnection.Open();

                    using (SqlCommand command = new SqlCommand("PracownicyExportPMC", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                dataTable = null;
                new FileSaveError("SpPracownicyExportPMC", "GetEmployees", e).Save();
            }
            finally
            {

            }

            return dataTable;
        }
    }
}
