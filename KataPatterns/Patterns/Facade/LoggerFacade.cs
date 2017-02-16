using System;
using log4net;

namespace Patterns.Facade
{
    public class LoggerFacade
    {
        private readonly ILog _logger;

        public LoggerFacade()
        {
            _logger = LogManager.GetLogger("LoggerFacade");
        }

        public void Log(string message)
        {
            _logger.Info(message);
        }

        public void Log(Exception exception)
        {
            _logger.Info("Exception", exception);
        }
    }
}