using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Loggers
{
    [CreateAssetMenu(fileName = "Debug Data.asset", menuName = "Helpers/Loggers/Create Debug Data")]
    public class DebugData : ScriptableObject
    {
        [ReorderableList] public List<DebugLog> BasicLogs = new List<DebugLog>();
        [ReorderableList] public List<DebugLog> WarningLogs = new List<DebugLog>();
        [ReorderableList] public List<DebugLog> ErrorLogs = new List<DebugLog>();
            
        [Button("Reset Basic Logs")] private void ResetBasicLogs() => BasicLogs = new List<DebugLog>();
        [Button("Reset Warning Logs")] private void ResetWarningLogs() => WarningLogs = new List<DebugLog>();
        [Button("Reset Error Logs")] private void ResetErrorLogs() => ErrorLogs = new List<DebugLog>();
    }
}