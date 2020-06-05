using System;
using System.Text;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using Web.ViewLogic.AuthLogic;
using Random = System.Random;

public class AuthAutoFiller : MonoBehaviour
{
    // To turn on or off this Mono behaviour
    [SerializeField] private bool _isActivated = true;
    
    // Fill admin data to input fields
    [SerializeField] private bool _isAdminUser = true;
    
    // To turn off generating random sign up data
    [SerializeField] private bool _useSignUpGenerator = true;
    
    // login 
    [Space(10)]
    [SerializeField] private TMP_InputField _loginUsernameInputField;
    [SerializeField] private TMP_InputField _loginPasswordInputField;

    [Space(5)]
    [SerializeField] private string _loginUsername = "user";
    [SerializeField] private string _loginPassword = "pass";
    
    [Space(5)]
    [SerializeField] private string _loginAdminUsername = "admin";
    [SerializeField] private string _loginAdminPassword = "pass";
    
    // SignUp
    [Space(10)]
    [SerializeField] private TMP_InputField _signUpUsernameInputField;
    [SerializeField] private TMP_InputField _signUpPasswordInputField;
    [SerializeField] private TMP_InputField _signUpEmailInputField;
    
    [Space(5)]
    [SerializeField] private string _signUpUsername;
    [SerializeField] private string _signUpPassword;
    [SerializeField] private string _signUpEmail;
    
    
    private readonly UserInputChecker _inputChecker = new UserInputChecker();
    
    void Start()
    {
        if (!_isActivated)
            return;

        FillLoginData();
        
        return;
        
        FillSignUpData();
    }

    
    private void FillLoginData()
    {
        if (_isAdminUser)
        {
            _loginUsernameInputField.text = _loginAdminUsername;
            _loginPasswordInputField.text = _loginAdminPassword;
            return;
        }
        
        _loginUsernameInputField.text = _loginUsername;
        _loginPasswordInputField.text = _loginPassword;
    }
    
    private void FillSignUpData()
    {
        if (_useSignUpGenerator | _inputChecker.IsUsernameInvalid(_signUpUsername) | _inputChecker.IsPasswordInvalid(_signUpPassword) | _inputChecker.IsEmailInvalid(_signUpEmail))
        {
            GenerateSignUpData();
            return;
        }

        _signUpUsernameInputField.text = _signUpUsername;
        _signUpPasswordInputField.text = _signUpPassword;
        _signUpEmailInputField.text = _signUpEmail;
    }

    [Button("Generate New Sign Up Data")]
    private void GenerateSignUpData()
    {
        // Moved Random out, to don't have the same values
        var random = new Random((int)DateTime.Now.Ticks);
        
        _signUpUsernameInputField.text = GenerateRandomString(random);
        _signUpPasswordInputField.text = GenerateRandomString(random);
        _signUpEmailInputField.text = GenerateRandomString(random) + "@fake.email";
    }

    private string GenerateRandomString(Random random = null, int minLength = 5, int maxLength = 12)
    {
        var characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        
        var length = random.Next(minLength, maxLength);

        var stringBuilder = new StringBuilder(length);
        
        for (var i = 0; i < length; i++) {
            stringBuilder.Append(characters[random.Next(characters.Length)]);
        }
        
        return stringBuilder.ToString();
    }
}
