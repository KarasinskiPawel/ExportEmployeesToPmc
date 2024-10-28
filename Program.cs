using ExportEmployeesToPmc.FileSupport;
using ExportEmployeesToPmc.Handlers;



namespace ExportEmployeesToPmc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new FileSaveLog($"Start: {DateTime.Now}").Save();

            var handlerA = new PrepareEmployeesData();
            var handlerB = new CreateNewFile(); 
            var handlerC = new CopyPreviousFile();
            var handlerD = new SaveNewFileOnSsh();

            handlerA.SetNext(handlerB).SetNext(handlerC).SetNext(handlerD);
            handlerA.HandleRequest(new HandlerRequest());

            new FileSaveLog($"Stop: {DateTime.Now}").Save();
            new FileSaveLog($"").Save();     
        }
    }
}
