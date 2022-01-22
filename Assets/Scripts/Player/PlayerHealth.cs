using Game.ScriptableObjects.Events;
using UnityEngine;

namespace Game.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        private GameEvent _playerDeathEvent;

        public void PlayerDeath()
        {
            _playerDeathEvent.OnOcurred();
            gameObject.SetActive(false);
        }
    }
}