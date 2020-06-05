using Scripts.Web.Dtos;
using Helpers;
using TMPro;
using UnityEngine;
using Web.Models;
using Web.Services;

namespace Web.ViewLogic.AuthLogic
{
    public class RegisterLogic : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private TMP_InputField _usernameInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [SerializeField] private TMP_InputField _emailInputField;
        
        [Space(10)]
        [SerializeField] private TextMeshProUGUI _usernameErrorText;
        [SerializeField] private TextMeshProUGUI _passwordErrorText;
        [SerializeField] private TextMeshProUGUI _emailErrorText;

        private AuthService _authService;
        private UserInputChecker _inputChecker;

        private void Start()
        {
            _authService = new AuthService();
            _inputChecker = new UserInputChecker();
        }

        public void Register()
        {
            var username = _usernameInputField.text;
            var password = _passwordInputField.text;
            var email = _emailInputField.text;
            
            // | using to validate all input fields.
            if (IsUsernameInvalid(username) | IsPasswordInvalid(password) | IsEmailInvalid(email))
            {
                return;
            }

            var user = new UserForRegisterDto(username, password, email);
            
            StartCoroutine(_authService.Register(user, RegisterCallback));
        }

        private void RegisterCallback(User user, string errorMessage)
        {
            if (user.UserId != -1)
            {
                CustomSceneManager.Get.LoadScene(UnitySceneName.GameScene);
                return;
            }
            
            // TODO display error message.
            _usernameErrorText.gameObject.SetActive(true);
            _passwordErrorText.gameObject.SetActive(true);
            _emailErrorText.gameObject.SetActive(true);
        }
        
        /// Validates Inputs fields and displays error message.
        #region Validates User Input
        
        // For input fields only and don't remove string parameter.
        public void CheckIfUsernameIsInValid(string username) => IsUsernameInvalid(username);
        public void CheckIfPasswordIsInValid(string password) => IsPasswordInvalid(password);
        public void CheckIfEmailIsInValid(string email) => IsEmailInvalid(email);
        

        private bool IsUsernameInvalid(string username)
        {
            var isValid = _inputChecker.IsUsernameInvalid(username);
            
            _usernameErrorText.gameObject.SetActive(isValid);
            
            return isValid;
        }
        
        private bool IsPasswordInvalid(string password)
        {
            var isValid = _inputChecker.IsPasswordInvalid(password);
            
            _passwordErrorText.gameObject.SetActive(isValid);
            
            return isValid;
        }
        
        private bool IsEmailInvalid(string email)
        {
            var isValid = _inputChecker.IsPasswordInvalid(email);
            
            _emailErrorText.gameObject.SetActive(isValid);
            
            return isValid;
        }

        #endregion
    }
}