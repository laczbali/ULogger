from enum import Enum
from ULoggerNET import ULog, TextLogger, LogLevel

logger = ULog()
logger.AddLogger(TextLogger("c:\\temp\\out.txt"))
logger.Log("is this working?", LogLevel.Error)
