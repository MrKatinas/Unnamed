using Settings;
using UnityEngine;

namespace Web.Settings.Services
{
    [CreateAssetMenu(fileName = "ServicesSettings.asset", menuName = "Helpers/Settings/Create  Services Settings")]
    public class ServicesSettings : ScriptableObject
    {
        #region Singleton

        private static ServicesSettings _servicesSettings;
    
        public static ServicesSettings Get
        {
            get
            {
                if (_servicesSettings != null) return _servicesSettings;

                _servicesSettings = Resources.Load<ServicesSettings>(ScriptableObjectLocations.Get.ServicesSettingsLocation);
            
                return _servicesSettings;
            }
        }

        #endregion

        [Space(10)] public string BaseUrl = "http://localhost:5000/api/";

        [Space(10)] public AuthConfig AuthConfig;
    }
}