using Game.Player.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAssociatedKey : MonoBehaviour
{
    [SerializeField]
    private PlayerControl _playerControl;

    // Check later
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            Debug.Log("Detected Key: " + e.keyCode);
        }
    }
}