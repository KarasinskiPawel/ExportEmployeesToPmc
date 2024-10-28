using ExportEmployeesToPmc.FileSupport;
using ExportEmployeesToPmc.LinuxFileManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.Handlers
{
    internal class SaveNewFileOnSsh : BaseHandler
    {
        public override void HandleRequest(HandlerRequest request)
        {
            if (request.FileCreated)
            {
                new FileSaveLog("Zapis pliku w lokalizacji docelowej...").Save();

                if (new SshNewFileCopy().Save(new FileSaveCsv().GetFullFilePath()))
                {
                    new FileSaveLog("Nowy plik zapisany w lokalizacji docelowej.").Save();
                }
                else
                {
                    new FileSaveLog("Nieokreślony bład podczas zapisu pliku!").Save();
                }
            }

            base.HandleRequest(request);
        }
    }
}
