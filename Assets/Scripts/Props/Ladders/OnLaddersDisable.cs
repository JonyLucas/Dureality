using Game.Player;
using UnityEngine;

namespace Game.Props
{
    public class OnLaddersDisable : MonoBehaviour
    {
        private PlayerMovement _moveScript;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                _moveScript = collision.transform.GetComponent<PlayerMovement>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player") && !_moveScript.IsUsingLadder)
            {
                _moveScript = null;
            }
        }

        private void OnDisable()
        {
            if (_moveScript != null)
            {
                _moveScript.CanUseLadder = false;
                _moveScript.StopClimbing();
            }
        }
    }
}