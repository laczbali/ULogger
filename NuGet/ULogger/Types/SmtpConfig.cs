using System;
using System.Collections.Generic;
using System.Text;

namespace ULogger.Types
{
    /// <summary>
    /// Describes an SMPT connection
    /// </summary>
    public class SmtpConfig
    {
        internal string host;
        internal int? port;
        internal string username;
        internal string password;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host">SMTP host (eg: smtp.gmail.com )</param>
        /// <param name="port">Usuallay set to 587</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public SmtpConfig(string host, int port, string username, string password)
        {
            this.host = host;
            this.port = port;
            this.username = username;
            this.password = password;
        }
    }
}
