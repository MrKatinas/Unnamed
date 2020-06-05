using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required] [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 20 characters")]
        public string Password { get; set; }
        
        [Required] [EmailAddress]
        public string Email { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public UserForRegisterDto() =>
            (Created, LastActive) = (DateTime.Now, DateTime.Now);
    }
}