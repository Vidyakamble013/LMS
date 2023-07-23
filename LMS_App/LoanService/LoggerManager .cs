using LMS_App.LoanInterface;
using NLog;
using ILogger = NLog.ILogger;

namespace LMS_App.LoanService
{
    public class LoggerManager : ILoggerManager
    {
        //private readonly ILogger logger;
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager()
        {
            //this.logger = logger;
        }

        public void LogInfo(string message) => logger.Info(message);

    }
}
