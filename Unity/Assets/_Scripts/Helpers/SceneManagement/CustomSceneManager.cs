using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using NaughtyAttributes.Test;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers
{
    [CreateAssetMenu(fileName = "Custom Scene Manager.asset", menuName = "Helpers/Custom Scene Manager")]
    public class CustomSceneManager : ScriptableObject
    {
        #region Singleton

        private static CustomSceneManager _customSceneManager;
    
        public static CustomSceneManager Get
        {
            get
            {
                if (_customSceneManager != null) return _customSceneManager;

                _customSceneManager = Resources.Load<CustomSceneManager>(ScriptableObjectLocations.Get.CustomSceneManagerLocation);
            
                return _customSceneManager;
            }
        }

        #endregion
        
        [ReorderableList]
        [SerializeField] private List<CustomScene> Scenes;

        public void LoadScene(UnitySceneName selectedUnitySceneName) 
            => Scenes.FirstOrDefault(scene => scene.UnitySceneName == selectedUnitySceneName)?.Load();
        
        /// <summary>
        /// Loads scene, if did not found, callback to method for error management. 
        /// </summary>
        /// <param name="selectedUnitySceneName"></param>
        /// <param name="callback"></param>
        public void LoadScene(UnitySceneName selectedUnitySceneName, Action callback)
        {
            var scene = Scenes.FirstOrDefault(customsScene => customsScene.UnitySceneName == selectedUnitySceneName);

            if (scene != null)
            {
                scene.Load();
                return;
            }

            callback();
        }

        [Button()]
        private void CreateSummaries()
        {
            foreach (var scene in Scenes)
            {
                scene.CreateSummary();
            }
        }
        

        [Serializable]
        public class CustomScene
        {
            // Used to easier understand the tool
            [SerializeField] private string _summary;
            
            public string Name;
            public UnitySceneName UnitySceneName;
        
            /// <summary>
            /// Loads this scene;
            /// </summary>
            public void Load()
            {
                SceneManager.LoadScene(Name);
            }

            public void CreateSummary()
            {
                _summary = $"{Name} mimics - {UnitySceneName}";
            }
        }
    }
}