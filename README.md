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

# Feature goals
- Two versions (at least)
  - .NET NuGet package
  - Python PIP package (can a .NET DLL be created, that can be called without an installed .NET runtime?)
 - The logger can be set up to
  - Log to file (most recent first)
  - Log to database
  - Send an email
