import os
import sys
import clr

sys.path.append(os.getcwd())
clr.AddReference("ULogger")

from ULogger import ULog

x = ULog.SumNums(1,2)
print(x)