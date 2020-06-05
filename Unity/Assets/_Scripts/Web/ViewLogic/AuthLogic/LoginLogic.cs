using Scripts.Web.Dtos;
using Helpers;
using TMPro;
using UnityEngine;
using Web.Models;
using Web.Services;

namespace Web.ViewLogic.AuthLogic
{
    public class LoginLogic : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private TMP_InputField _usernameInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        
        [Space(10)] 
        [SerializeField] private TextMeshProUGUI _errorMessage;
        
        private AuthService _authService;
        private UserInputChecker _inputChecker;

        private void Start()
        {
            _authService = new AuthService();
            _inputChecker = new UserInputChecker();
        }

        public void Login()
        {
            var username = _usernameInputField.text;
            var password = _passwordInputField.text;
            
            // | using to validate both input fields.
            if (IsUsernameInvalid(username) | IsPasswordInvalid(password))
                return;

            var user = new UserForLoginDto(username, password);

            StartCoroutine(_authService.Login(user, LoginCallback));
        }

        private void LoginCallback(User user, string errorMessage)
        {
            if (errorMessage != null)
            {
                _errorMessage.text = errorMessage;
                _errorMessage.gameObject.SetActive(true);
                
                return;
            }
            
            CustomSceneManager.Get.LoadScene(UnitySceneName.GameScene);
        }
        
        /// Validates Inputs fields and displays error message.
        #region Validates User Input
        
        // For input fields only and don't remove string parameter.
        public void CheckIfUsernameIsInValid(string username) => IsUsernameInvalid(username);
        public void CheckIfPasswordIsInValid(string password) => IsPasswordInvalid(password);
        
        private bool IsUsernameInvalid(string username)
        {
            var isValid = _inputChecker.IsUsernameInvalid(username);
            
            _errorMessage.gameObject.SetActive(isValid);
            
            return isValid;
        }
        
        private bool IsPasswordInvalid(string password)
        {
            var isValid = _inputChecker.IsPasswordInvalid(password);
            
            _errorMessage.gameObject.SetActive(isValid);
            
            return isValid;
        }

        #endregion
    }
}