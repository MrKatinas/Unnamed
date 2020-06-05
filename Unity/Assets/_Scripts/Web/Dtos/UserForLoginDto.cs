namespace Scripts.Web.Dtos
{
    public class UserForLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserForLoginDto(string username, string password) => 
            (Username, Password) = (username, password);
    }
}