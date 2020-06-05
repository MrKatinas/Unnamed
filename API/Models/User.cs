using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class User : IdentityUser<int>
    {
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        
        public User() =>
            (Created, LastActive) = (DateTime.Now, DateTime.Now);
    }
}