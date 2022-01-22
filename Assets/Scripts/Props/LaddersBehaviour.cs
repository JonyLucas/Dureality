using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.Props
{
    public class LaddersBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _ladderDirection;

        private PlayerMovement _moveScript;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (_moveScript == null)
                {
                    _moveScript = collision.transform.GetComponent<PlayerMovement>();
                }

                _moveScript.ClimbDirection = _ladderDirection;

                if (!_moveScript.IsUsingLadder)
                {
                    _moveScript.CanUseLadder = true;
                }
                else
                {
                    _moveScript.StopClimbing();
                    StartCoroutine(StopClimbingCoroutine());
                }
            }
        }

        private IEnumerator StopClimbingCoroutine()
        {
            _moveScript.CanUseLadder = false;
            yield return new WaitForSeconds(0.5f);
            _moveScript.CanUseLadder = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (_moveScript == null)
                {
                    _moveScript = collision.transform.GetComponent<PlayerMovement>();
                }

                _moveScript.ClimbDirection = Vector2.zero;

                if (!_moveScript.IsUsingLadder)
                {
                    _moveScript.CanUseLadder = false;
                }
            }
        }
    }
}