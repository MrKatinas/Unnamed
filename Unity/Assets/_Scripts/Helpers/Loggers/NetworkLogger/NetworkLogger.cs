using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Settings;
using UnityEngine;
using UnityEngine.Networking;

namespace Loggers
{
    public class NetworkLogger
    {
        private readonly NetworkData _networkData;
        public NetworkLogger()
        {
            _networkData = Resources.Load<NetworkData>(ScriptableObjectLocations.Get.NetworkDataLocation);
        }
        
        public void Log(NetworkLogType type, UnityWebRequest webRequest)
        {
            var log = new NetworkLog(webRequest);
            
            switch (type)
            {
                case 
                    NetworkLogType.Basic:
                    _networkData.BasicLogs.Add(log);
                    break;
                case NetworkLogType.Warning:
                    _networkData.WarningLogs.Add(log);
                    break;
                case NetworkLogType.RequestError:
                    _networkData.ErrorLogs.Add(log);
                    break;
                default:
                    LoggingManager.Get.Log(DebugLogType.Error, $"ArgumentOutOfRangeException of type {nameof(type)}");
                    break;
            }
        }
    }
}