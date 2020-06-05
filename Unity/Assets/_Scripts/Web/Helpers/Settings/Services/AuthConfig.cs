using System;
using UnityEngine;

namespace Web.Settings.Services
{
    [Serializable]
    public class AuthConfig
    {
        [SerializeField] private string _baseUrl = "auth/";
        [SerializeField] private string _loginApiName = "login";
        [SerializeField] private string _registerApiName = "register";

        public string BaseUrl => ServicesSettings.Get.BaseUrl + _baseUrl;
    
        public string LoginUrl => BaseUrl + _loginApiName;
        public string RegisterUrl => BaseUrl + _registerApiName;
    }
}