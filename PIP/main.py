from ULoggerNET import ULog, TextLogger

logger = ULog()
logger.AddLogger(TextLogger(["c:\\temp\\outj.json"]))
logger.Log("is this working?")

# use https://github.com/dotnet/ILMerge ?