using System;
using System.Collections.Generic;

namespace API.Dtos
{
    public class UserWithRolesDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public IList<string> Roles { get; set; }
    }
}