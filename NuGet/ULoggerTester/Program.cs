using ULogger;
using ULogger.Loggers;

var logger = new ULogger.ULog();
//logger.AddLogger(new TextLogger(new string[] { @"c:\temp\test.txt", @"c:\temp\j.JSON" }));
logger.Log("lorem", ULogger.Types.LogLevel.Info);