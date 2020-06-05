using UnityEngine;

namespace Settings
{
    // TODO think of better way to manage locations of scriptable objects
    [CreateAssetMenu(fileName = "Scriptable Object Locations.asset", menuName = "Helpers/Create Scriptable Object Locations")]
    public class ScriptableObjectLocations : ScriptableObject
    {
        #region Singleton
         
             private const string SettingsPath = "Helpers/Scriptable Object Locations";
             private static ScriptableObjectLocations _scriptableObjectLocations;
         
             public static ScriptableObjectLocations Get
             {
                 get
                 {
                     if (_scriptableObjectLocations != null) return _scriptableObjectLocations;
     
                     _scriptableObjectLocations = Resources.Load<ScriptableObjectLocations>(SettingsPath);
                 
                     return _scriptableObjectLocations;
                 }
             }
             
        #endregion
        
        [Space(10)] public string CustomSceneManagerLocation = "Helpers/Custom Scene Manager";
        [Space(2)] public string ErrorMessagesLocation = "Helpers/ErrorMessages";
        
        [Space(10)] public string ServicesSettingsLocation = "Helpers/Settings/Services";
        
        [Space(10)] public string DebugDataLocation = "Helpers/Logs/Debug Data";
        [Space(2)] public string NetworkDataLocation = "Helpers/Logs/Network Data";
    }
}