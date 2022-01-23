using Game.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Props
{
    public class ObjectiveBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameEvent _winEvent;

        private int _playerContact = 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                _playerContact++;
                if (_playerContact == 2)
                {
                    _winEvent.OnOcurred();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                _playerContact--;
            }
        }
    }
}