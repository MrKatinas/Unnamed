using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Loggers
{
    [CreateAssetMenu(fileName = "Network Data.asset", menuName = "Helpers/Loggers/Create Network Data")]
    public class NetworkData : ScriptableObject
    {
        [ReorderableList] public List<NetworkLog> BasicLogs = new List<NetworkLog>();
        [ReorderableList] public List<NetworkLog> WarningLogs = new List<NetworkLog>();
        [ReorderableList] public List<NetworkLog> ErrorLogs = new List<NetworkLog>();
            
        [Button("Reset Basic Logs")] private void ResetBasicLogs() => BasicLogs = new List<NetworkLog>();
        [Button("Reset Warning Logs")] private void ResetWarningLogs() => WarningLogs = new List<NetworkLog>();
        [Button("Reset Error Logs")] private void ResetErrorLogs() => ErrorLogs = new List<NetworkLog>();
    }
}