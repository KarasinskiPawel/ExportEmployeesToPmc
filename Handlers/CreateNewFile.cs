using ExportEmployeesToPmc.FileSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.Handlers
{
    internal class CreateNewFile : BaseHandler
    {
        public override void HandleRequest(HandlerRequest request)
        {
            new FileSaveLog("Twrzenie lokalnej kopi nowego pliku...").Save();

            if (request.DataDownloaded)
            {
                var fileSaveCsv = new FileSaveCsv(request.Employees);
                fileSaveCsv.Save();

                if (fileSaveCsv.Output())
                    request.FileCreated = true;

                new FileSaveLog("Plik został utworzony!").Save();
            }
            else
            {
                new FileSaveLog("Brak danych - tworzenie pliku anulowane.").Save();
            }

            base.HandleRequest(request);
        }
    }
}
