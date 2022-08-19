import os
import sys
import clr

sys.path.append(os.getcwd())
clr.AddReference("ULogger")

# below is the definition for the ULogger classes
# they will get loaded at the bottom with the import

class ULog:
    def Log(msg):
        pass

    def AddLogger():
        pass

class TextLogger:
    def __init__(self, filepaths) -> None:
        pass
    pass


from ULogger import ULog # type: ignore
from ULogger.Loggers import TextLogger  # type: ignore