from ULoggerNET import ULog, TextLogger, EmailLogger, LogLevel, SmtpConfig
import os
from dotenv import load_dotenv

load_dotenv()

logger = ULog()

#logger.AddLogger(TextLogger("c:\\temp\\out.txt"))

username = os.environ.get("email-username")
password = os.environ.get("email-password")
fromaddress = os.environ.get("email-fromaddress")
toaddress = os.environ.get("email-toaddress")
logger.AddLogger(
    EmailLogger(
        SmtpConfig("smtp.gmail.com", 587, username, password), 
        fromaddress, toaddress
    )
)

logger.Log("is this working?", LogLevel.Warn)
