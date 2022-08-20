from ULoggerNET import ULog, TextLogger

logger = ULog()
logger.AddLogger(TextLogger(["c:\\temp\\outj.json"]))
logger.Log("is this working?")
