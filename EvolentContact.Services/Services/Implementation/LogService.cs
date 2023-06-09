using EvolentContact.Services.Services.Interfaces;
using NLog;

namespace EvolentContact.Services.Services.Implementation
{
    public class LogService : ILogService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
