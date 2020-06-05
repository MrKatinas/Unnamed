using System;
using System.Collections.Generic;
using Helpers;
using Settings;
using UnityEngine;

namespace Loggers
{
    public class DebugLogger
    {
        private readonly DebugData _debugData;
        public DebugLogger()
        {
            _debugData = Resources.Load<DebugData>(ScriptableObjectLocations.Get.DebugDataLocation);
        }
        
        public void Log(DebugLogType logType, string message)
        {
            var log = new DebugLog(message);
            
            switch (logType)
            {
                case DebugLogType.Basic:
                    _debugData.BasicLogs.Add(log);
                    break;
                case DebugLogType.Warning:
                    _debugData.WarningLogs.Add(log);
                    break;
                case DebugLogType.Error:
                    _debugData.ErrorLogs.Add(log);
                    break;
                default:
                    _debugData.ErrorLogs.Add(new DebugLog($"ArgumentOutOfRangeException of type {nameof(logType)}"));
                    break;
            }
        }
    }
}