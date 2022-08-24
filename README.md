# ULogger
General purpose, general usage logger library

# Getting started
**Python**
- Setup
  - Install PIP packages from `requirements.txt`
  - (Linux) You need mono ( `sudo apt-get install mono-complete` )
- Usage
```python
from ULoggerNET import ULog, TextLogger, LogLevel

logger = ULog()
logger.AddLogger(TextLogger("c:\\temp\\out.txt"))
logger.Log("Hello there", LogLevel.Warn)
```

**.NET**
- Setup
- Usage
```csharp
using ULogger;
using ULogger.Loggers;

var logger = new ULogger.ULog();
logger.AddLogger(new TextLogger(new string[] { @"c:\temp\out.JSON" }));
logger.Log("ipsum", ULogger.Types.LogLevel.Info);
```

<!-- TOOD: dependency injection usage -->

# Setting up GMail for EmailLogger
1. Go to My Account in Gmail and click on Security
2. Scroll down to choose the Signing into Google option
3. Click on App Password. (Note: You can see this option when two-step authentication is enabled)
4. Here, you can see a list of applications, choose the required one
5. Next, pick the Select Device option and click on the device which is being used to operate Gmail
6. Now, click on Generate
7. After that, enter the Password shown in the Yellow bar
8. Lastly, click on Done
( [thanks](https://stackoverflow.com/a/73214197) )

# Feature goals
- Loggers can be set up so they are only called ABOVE a certain level (eg always log to file, but only end emails for errors)
- Two versions (at least)
  - .NET NuGet package
  - Python PIP package (can a .NET DLL be created, that can be called without an installed .NET runtime?)
 - The logger can be set up to
  - Log to database
