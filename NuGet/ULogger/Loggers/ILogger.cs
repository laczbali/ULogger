using System;
using System.Collections.Generic;
using System.Text;
using ULogger.Types;

namespace ULogger.Loggers
{
    public interface ILogger
    {
        void Log(string message, LogLevel level);
    }
}
