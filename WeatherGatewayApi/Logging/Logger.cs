using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Logger1
    {
        private Logger _logger;
        private string _loggerName;
        public  Logger1(string currentClassName)
        {
            _logger = LogManager.GetLogger(currentClassName);
            _loggerName = currentClassName;
        }
        public void Log(string message)
        {
            var eventInfo = new LogEventInfo(LogLevel.Info, _loggerName, message);
            // Add some custom functionality
            eventInfo.Properties["mytimestamp"] = DateTime.Now;
            _logger.Info(eventInfo);

        }
        public void ErrorLog(Exception ex,string message)
        {
            var eventInfo = new LogEventInfo(LogLevel.Error, _loggerName, message);
            // Add some custom functionality
            eventInfo.Properties["mytimestamp"] = DateTime.Now;
            eventInfo.Exception = ex;
            _logger.Error(eventInfo);

        }
        

    }
}
