using System;
using System.Collections;
using System.Text;
using Loggers;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Web.Helpers.WebRequests 
{
    public class HttpHandler
    {
        #region POST method and overloads

        public static IEnumerator Post<T>(RequestArguments<T> requestArguments) where T : class
        {
            var bytes = Encoding.UTF8.GetBytes(requestArguments.JsonToSend);
            
            // Way to send the raw json in unity is to use Put method and then change the method
            using (var www = UnityWebRequest.Put(requestArguments.Url, bytes))
            {
                www.method = "POST";

                www.SetRequestHeader("Content-Type", "application/json");
                www.SetRequestHeader("Accept", "application/json");

                yield return www.SendWebRequest();
            
                if (www.isNetworkError)
                {
                    LoggingManager.Get.Log(NetworkLogType.RequestError, www);
                    
                    requestArguments.SendErrorToViewCallback(www.error);
                    
                    yield break;
                }
                
                if (www.isHttpError)
                {
                    LoggingManager.Get.Log(NetworkLogType.RequestError, www);
                    
                    requestArguments.SendErrorToViewCallback(www.downloadHandler.text);
                    
                    yield break;
                }
                
                requestArguments.SendDataToServiceCallback(www.downloadHandler.text);
            }
        }
        
        #endregion
        
        public class RequestArguments<T> where T : class
        {
            public string Url { get; set; }
            public string JsonToSend { get; set; }
            
            private Action<string, Action<T, string>> ServiceCallBack { get; set; }
            private Action<T, string> ViewCallBack { get; set; }

            public RequestArguments(string url, string jsonToSend, Action<string, Action<T, string>> serviceCallBack, Action<T, string> viewCallBack)
            {
                Url = url;
                JsonToSend = jsonToSend;
                ServiceCallBack = serviceCallBack;
                ViewCallBack = viewCallBack;
            }

            public void SendDataToServiceCallback(string jsonToReturn) =>
                ServiceCallBack(jsonToReturn, ViewCallBack);
            
            public void SendErrorToViewCallback(string errorMessage) =>
                ViewCallBack(null, errorMessage);

        }
    }
}
