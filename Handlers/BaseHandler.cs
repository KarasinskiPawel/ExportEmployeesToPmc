using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportEmployeesToPmc.Handlers
{
    internal abstract class BaseHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }
        public virtual void HandleRequest(HandlerRequest request)
        {
            if(_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }
}
