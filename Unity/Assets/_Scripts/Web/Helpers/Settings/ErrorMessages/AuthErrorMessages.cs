using System;
using UnityEngine;

namespace Settings.ErrorMessages
{
    [Serializable]
    public class AuthErrorMessages
    {
        #region Login Error Messagse


        #endregion
        
        #region Register Error Messages

        [Space(10)]
        public string InvalidUsername = "Please Write Valid Username";
            
        public string InvalidPassword = "Please Write Valid Password";
            
        public string InvalidEmail = "Please Write Valid Email";

        #endregion
    }
}