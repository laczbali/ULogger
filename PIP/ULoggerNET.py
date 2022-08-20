from enum import Enum
import os
import sys
import clr

sys.path.append(os.getcwd())
clr.AddReference("ULogger")

# below is the definition for the ULogger classes
# they will get loaded at the bottom with the import

class TextLogger:
    """
    Set up a new TextLogger
     
    Select where should it create a log.
    It can be an existing or a new file.
    The format can be .txt or .json.
    Multiple files can be provided
    """
    def __init__(self, filepaths) -> None:
        pass
    pass

class LogLevel(Enum):
    Info = 0,
    Warn = 1,
    Error = 2,

class ULog:
    """
    Create and use loggers
    """

    def AddLogger(newLoggers : TextLogger):
        """
        Define a new Logger to be used when Log is called

        If multiple are provided, each will be called

        Can provide one or more logger
        """
        pass

    def Log(msg : str, level : LogLevel):
        """
        Creates a log with each added logger
        """
        pass




from ULogger import ULog # type: ignore
from ULogger.Loggers import TextLogger  # type: ignore
