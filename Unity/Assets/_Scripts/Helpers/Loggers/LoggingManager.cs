using UnityEngine.Networking;

namespace Loggers
{
    public class LoggingManager
    {
        #region Singleton

        private static LoggingManager _instance;

        public static LoggingManager Get => _instance ?? (_instance = new LoggingManager());

        #endregion

        private readonly DebugLogger _debugLogger;
        private readonly NetworkLogger _networkLogger;

        private LoggingManager()
        {
            _debugLogger = new DebugLogger();
            _networkLogger = new NetworkLogger();
        }
        
        public void Log(DebugLogType logType, string message)
        {
            _debugLogger.Log(logType, message);
        }

        public void Log(NetworkLogType logType, UnityWebRequest webRequest)
        {
            _networkLogger.Log(logType, webRequest);
        }
    }
}