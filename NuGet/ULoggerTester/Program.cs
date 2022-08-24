using ULogger;
using ULogger.Loggers;
using ULogger.Types;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var settings = config.GetSection("AppSettings");

var logger = new ULogger.ULog();

// test text logger
logger.AddLogger(new TextLogger(new string[] { @"c:\temp\j.JSON", @"c:\temp\t.txt" }));

// test email logger
var emailSettings = settings.GetSection("Email");
var username = emailSettings["username"];
var password = emailSettings["password"];
var fromaddress = emailSettings["fromaddress"];
var toaddress = emailSettings["toaddress"];
logger.AddLogger(
    new EmailLogger(
        new SmtpConfig("smtp.gmail.com", 587, username, password),
        fromaddress,
        toaddress
    )
);

logger.Log("This is my message", ULogger.Types.LogLevel.Info);