using System;
using System.Collections.Generic;
using System.Text;

namespace ULogger.Types
{
    /// <summary>
    /// 
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Not an error, but needs to be logged
        /// </summary>
        Info,
        /// <summary>
        /// Something is wrong, but the app can continue
        /// </summary>
        Warn,
        /// <summary>
        /// Attention is needed
        /// </summary>
        Error
    }
}
