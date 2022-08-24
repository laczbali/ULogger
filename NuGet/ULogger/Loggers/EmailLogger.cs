using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using ULogger.Types;

namespace ULogger.Loggers
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailLogger : ILogger
    {
        private SmtpClient _smtpClient;
        private MailMessage _sendObject;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smtpConfig"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        public EmailLogger(SmtpConfig smtpConfig, string fromAddress, string toAddress)
        {
            SetupClass(smtpConfig, fromAddress, new string[] { toAddress });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smtpConfig"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddresses"></param>
        public EmailLogger(SmtpConfig smtpConfig, string fromAddress, string[] toAddresses)
        {
            if (toAddresses.Length == 0) { throw new ArgumentException("Must provide at least one address"); }
            SetupClass(smtpConfig, fromAddress, toAddresses);
        }

        /// <summary>
        /// Sets email adresses, sets up SmtpClient
        /// </summary>
        /// <param name="smtpConfig"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddresses"></param>
        private void SetupClass(SmtpConfig smtpConfig, string fromAddress, string[] toAddresses)
        {
            // setup output
            _sendObject = new MailMessage();
            _sendObject.From = new MailAddress(fromAddress);
            foreach (var address in toAddresses)
            {
                _sendObject.To.Add(new MailAddress(address));
            }

            // setup client
            _smtpClient = new SmtpClient(smtpConfig.host);
            _smtpClient.Credentials = new NetworkCredential(smtpConfig.username, smtpConfig.password);
            _smtpClient.Port = (int)smtpConfig.port;
            _smtpClient.EnableSsl = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        void ILogger.Log(string message, LogLevel level)
        {
            string assemblyName = "ULog";
            try
            {
                assemblyName = Assembly.GetEntryAssembly().FullName.Split(',')[0];
            }
            catch(Exception e)
            {
                var exceptionMessage = e.InnerException == null ? e.Message : e.InnerException.Message;
                Console.WriteLine("[ULOG] Failed to get entry assembly name, defaulting to 'Ulog'. Details: " + exceptionMessage);
            }

            _sendObject.Subject = $"[{level.ToString().ToUpper()}] {assemblyName}";
            _sendObject.Body = $"New log from <b>{assemblyName}</b><br>";
            _sendObject.Body += $"Created at: <b>{DateTime.Now}</b><br>";
            _sendObject.Body += $"Level: <b>{level}</b><br><br>";
            _sendObject.Body += message;
            _sendObject.IsBodyHtml = true;

            try
            {
                _smtpClient.Send(_sendObject);
            }
            catch(Exception e)
            {
                var exceptionMessage = e.InnerException == null ? e.Message : e.InnerException.Message;
                Console.WriteLine("[ULOG] Failed to send email! Details: " + exceptionMessage);
            }
        }
    }
}
