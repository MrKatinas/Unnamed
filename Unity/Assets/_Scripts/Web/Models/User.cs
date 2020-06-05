using System;
using Newtonsoft.Json;
using Web.Helpers.WebRequests;

namespace Web.Models
{
    public class User
    {
        public int UserId { get; set; }
        public JwtToken JwtToken { get; set; }
    
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    
        [JsonProperty("Created")] 
        public DateTime DateOfCreation { get; set; }
        public DateTime LastActive { get; set; }

        [JsonProperty("Roles")]
        public UserRoles UserRoles { get; set; }

        public override string ToString()
        {
            return $"{nameof(Username)}: {Username}\t" +
                   $"{nameof(Email)}: {Email}\t" +
                   $"{nameof(UserRoles)}: {UserRoles}\t";
        }
    }
}
