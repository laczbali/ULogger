using System;
using System.Collections.Generic;
using ULogger.Loggers;
using ULogger.Types;

namespace ULogger
{
    /// <summary>
    /// Create and use loggers
    /// </summary>
    public class ULog
    {
        private List<ILogger> _loggers = new List<ILogger>();

        /// <summary>
        /// 
        /// </summary>
        public ULog() { }

        /// <summary>
        /// Define a new Logger to be used when Log is called
        /// 
        /// If multiple are provided, each will be called
        /// </summary>
        /// <param name="newLogger"></param>
        public void AddLogger(ILogger newLogger)
        {
            _loggers.Add(newLogger);
        }

        /// <summary>
        /// Define new Loggers to be used when Log is called
        /// 
        /// If multiple are provided, each will be called
        /// </summary>
        /// <param name="newLoggers"></param>
        public void AddLogger(List<ILogger> newLoggers)
        {
            foreach (var logger in newLoggers)
            {
                AddLogger(logger);
            }
        }

        /// <summary>
        /// Creates a log with each added logger
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (_loggers.Count == 0)
            {
                Console.WriteLine("[ULOG] No loggers are specified!");
            }

            foreach (var logger in _loggers)
            {
                logger.Log(message, level);
            }
        }
    }
}
