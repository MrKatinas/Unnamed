using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers
{
    /// <summary>
    /// This class is used only for buttons
    /// </summary>
    public class CustomSceneLoaderForButtons : MonoBehaviour
    {
        [SerializeField] private UnitySceneName _unitySceneName;
        
        public void LoadScene()
        {
            CustomSceneManager.Get.LoadScene(_unitySceneName);
        }
    }
}