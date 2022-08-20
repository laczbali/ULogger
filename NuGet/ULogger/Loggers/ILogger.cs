using System;
using System.Collections.Generic;
using System.Text;
using ULogger.Types;

namespace ULogger.Loggers
{
    /// <summary>
    /// Create logs
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the message to the target specified during instatiation
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        void Log(string message, LogLevel level);
    }
}
