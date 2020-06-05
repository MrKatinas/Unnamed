using System;
using System.Collections;
using Scripts.Web.Dtos;
using Newtonsoft.Json;
using Web.Helpers.WebRequests;
using Web.Models;
using Web.Settings.Services;

namespace Web.Services
{
    public class AuthService
    {
        public IEnumerator Login(UserForLoginDto user, Action<User, string> viewCallback)
        {
            var json = JsonConvert.SerializeObject(user);
            var loginUrl  = ServicesSettings.Get.AuthConfig.LoginUrl;

            var requestArguments = new HttpHandler.RequestArguments<User>(loginUrl, json, LoginCallback, viewCallback);
            
            yield return HttpHandler.Post(requestArguments);
        }

        private void LoginCallback(string json, Action<User, string> viewCallback)
        {
            var user = JsonConvert.DeserializeObject<User>(json);
            var token = JsonConvert.DeserializeObject<JwtToken>(json);

            user.JwtToken = token;
            
            viewCallback(user, null);
        }
        
        
        public IEnumerator Register(UserForRegisterDto user, Action<User, string> viewCallback)
        {
            var json = JsonConvert.SerializeObject(user);
            var registerUrl  = ServicesSettings.Get.AuthConfig.RegisterUrl;
            
            var requestArguments = new HttpHandler.RequestArguments<User>(registerUrl, json, RegisterCallback, viewCallback);
            
            yield return HttpHandler.Post(requestArguments);
        }
        
        private void RegisterCallback(string json, Action<User, string> viewCallback)
        {
            var user = JsonConvert.DeserializeObject<User>(json);
            var token = JsonConvert.DeserializeObject<JwtToken>(json);

            user.JwtToken = token;

            viewCallback(user, null);
        }
    }
}
