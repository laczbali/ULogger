# ULogger
General purpose, general usage logger library

# Requirements
**Python version**
- `setuptools` & `wheel` PIP packages
- Prerelease version of `pythonnet` ( `pip install --pre pythonnet` )
- (Linux) May need to install mono `sudo apt-get install mono-complete`

# Feature goals
- Two versions (at least)
  - .NET NuGet package
  - Python PIP package (can a .NET DLL be created, that can be called without an installed .NET runtime?)
 - The logger can be set up to
  - Log to file (most recent first)
  - Log to database
  - Send an email
