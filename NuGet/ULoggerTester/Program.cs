using ULogger;
using ULogger.Loggers;

var logger = new ULogger.ULog();
logger.AddLogger(new TextLogger(new string[] { @"c:\temp\j.JSON" }));
logger.Log("ipsum", ULogger.Types.LogLevel.Info);