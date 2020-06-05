namespace Scripts.Web.Dtos
{
    public class UserForRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserForRegisterDto(string username, string password, string email) =>
            (Username, Password, Email) = (username, password, email);
    }
}