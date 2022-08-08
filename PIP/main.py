import os
import sys
import clr

sys.path.append(os.getcwd())
clr.AddReference("ULogger")

from ULogger import ULog # type: ignore

x = ULog.SumNums(1,2)
print(x)