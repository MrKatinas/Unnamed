using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes.Test;
using UnityEngine;

// TODO Think a better way to do it.
/// <summary>
/// Used to turn on or of Login panel in the UI
/// </summary>
public class TurnOnOrOff : MonoBehaviour
{
    /// <summary>
    /// Object that is turned on or off
    /// </summary>
    [SerializeField] private GameObject _object;

    public void ChangeState()
    {
        _object.SetActive(!_object.activeSelf);
    }
}
