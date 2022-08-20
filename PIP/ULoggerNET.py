from enum import IntEnum
import os
import sys
import clr

# no need to import this, easier to just define here
class LogLevel(IntEnum):
    # it will actually use the 'int' version of the Log() method
    # as PythonNET can't deal with proper enums
    Info = 0,
    Warn = 1,
    Error = 2,

# below is the definition for the ULogger classes
# they will get loaded at the bottom with the 
# but defining them here provides hints for the classes
class TextLogger:
    """
     
    Select where should it create a log.
    It can be an existing or a new file.
    The format can be .txt or .json.
    Multiple files can be provided
    """
    def __init__(self, filepaths) -> None:
        pass
    pass

class ULog:
    """
    Create and use loggers
    """

    def AddLogger(self, newLoggers : TextLogger):
        """
        Define a new Logger to be used when Log is called

        If multiple are provided, each will be called

        Can provide one or more logger
        """
        pass

    def Log(self, msg : str, level : LogLevel):
        """
        Creates a log with each added logger
        """
        pass

# add DLL
sys.path.append(os.getcwd())
clr.AddReference("ULogger")
# import from DLL (need to disable errors, as the hinter has no idea about the DLL)
from ULogger import ULog # type: ignore
from ULogger.Loggers import TextLogger  # type: ignore
