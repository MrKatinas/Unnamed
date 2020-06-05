using System;
using System.Globalization;

namespace Loggers
{
    [Serializable]
    public class DebugLog
    {
        public string Message;
        
        public string CreationTime;

        public DebugLog(string message)
        {
            Message = message;
            CreationTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
    }
}