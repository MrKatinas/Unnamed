using UnityEngine;

namespace Settings.ErrorMessages
{
    [CreateAssetMenu(fileName = "ErrorMessages.asset", menuName = "Helpers/ErrorMessages")]
    public class ErrorMessages : ScriptableObject
    {
        #region Singleton

        private static ErrorMessages _servicesSettings;
    
        public static ErrorMessages Get
        {
            get
            {
                if (_servicesSettings != null) return _servicesSettings;

                _servicesSettings = Resources.Load<ErrorMessages>(ScriptableObjectLocations.Get.ErrorMessagesLocation);
            
                return _servicesSettings;
            }
        }

        #endregion

        public AuthErrorMessages authErrorMessages;
        
        [Space(10)]
        [SerializeField] private string _alreadyTaken = "is already taken";
            
        public string PropertyIsTaken (PropertyName propertyName, string propertyValue) => 
            $"{propertyName} {propertyValue} {_alreadyTaken}";
        
        public enum PropertyName
        {
            Username,
            Email,
        }
    }
}