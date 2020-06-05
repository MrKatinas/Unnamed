using System.Collections.Generic;
using Helpers;
using TMPro;

namespace Web.ViewLogic.AuthLogic
{
    public class UserInputChecker
    {
        public bool IsUsernameInvalid(string username) => string.IsNullOrEmpty(username);
        public bool IsPasswordInvalid(string username) => string.IsNullOrEmpty(username);
        public bool IsEmailInvalid(string username) => string.IsNullOrEmpty(username);
    }
}
