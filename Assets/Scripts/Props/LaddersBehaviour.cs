using Game.Player;
using UnityEngine;

namespace Game.Props
{
    public class LaddersBehaviour : MonoBehaviour
    {
        [SerializeField]
        private bool _bottomLadder;

        private PlayerMovement _moveScript;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (_moveScript == null)
                {
                    _moveScript = collision.transform.GetComponent<PlayerMovement>();
                }
                _moveScript.CanUseLadder = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (_moveScript == null)
                {
                    _moveScript = collision.transform.GetComponent<PlayerMovement>();
                }
                _moveScript.CanUseLadder = false;
            }
        }
    }
}