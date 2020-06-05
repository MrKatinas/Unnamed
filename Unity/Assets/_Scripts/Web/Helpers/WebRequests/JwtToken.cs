using System;
using Newtonsoft.Json;

namespace Web.Helpers.WebRequests
{
    public struct JwtToken
    {
        
        [JsonProperty("token")] private readonly string _token;

        public JwtToken(string token) => _token = token;

        public override string ToString() => _token;
    }
}