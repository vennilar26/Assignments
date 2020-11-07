using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Trace("This is a trace message");
            logger.Debug("This is a debug message");
            logger.Info("This is an informational message");
            logger.Warn("This is a warning message");
            logger.Error("This is an error message");
            logger.Fatal("This is a fatal message");
            Console.ReadKey();
        }
    }
}
