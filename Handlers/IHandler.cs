using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.Handlers
{
    internal interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void HandleRequest(HandlerRequest request);
    }
}
