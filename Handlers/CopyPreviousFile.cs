using ExportEmployeesToPmc.FileSupport;
using ExportEmployeesToPmc.LinuxFileManagement;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.Handlers
{
    internal class CopyPreviousFile : BaseHandler
    {
        public override void HandleRequest(HandlerRequest request)
        {
            if (request.FileCreated)
            {
                new FileSaveLog("Kopiowanie aktualnie dostępnego na serwerze pliku...").Save();

                if (new SshFileCopy().Save())
                {
                    request.PreviousFileWasCopied = true;

                    new FileSaveLog("Plik przeniesiony do folderu old.").Save();
                }
            }
            else
            {
                new FileSaveLog("Brak danych - kopiowanie pliku anulowane!").Save();
            }

            base.HandleRequest(request);
        }
    }
}
