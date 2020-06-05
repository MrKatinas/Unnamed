using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

namespace Loggers
{
    [Serializable]
    public class NetworkLog
    {
        public string Summary;
        
        public string CreationTime;

        public UnityWebRequestLog WebRequestLog;

        public NetworkLog(UnityWebRequest webRequest)
        {
            CreationTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            
            WebRequestLog = new UnityWebRequestLog(webRequest);

            Summary = $"{webRequest.error}\t{CreationTime}\t{webRequest.uri}  {webRequest.downloadHandler.text}";
        }
        
        [Serializable]
        public class UnityWebRequestLog
        {
            public string ErrorMessage;
            public string Method;
            public string Url;
            
            public UnityWebRequest WebRequest;

            public UnityWebRequestLog(UnityWebRequest webRequest)
            {
                Url = webRequest.url;
                Method = webRequest.method;
                ErrorMessage = webRequest.error;
                WebRequest = webRequest;
            }
        }
    }
}