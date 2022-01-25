using Game.Extensions;
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

                _moveScript.ClimbDirection = _ladderDirection.GetProminentVectorComponent();

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
            yield return new WaitForSeconds(0.1f);
            _moveScript.CanUseLadder = true;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (_moveScript == null)
                {
                    _moveScript = collision.transform.GetComponent<PlayerMovement>();
                }

                if (_moveScript.IsUsingLadder && collision.transform.position.x != transform.position.x)
                {
                    var newPosition = collision.transform.position;
                    newPosition.x = transform.position.x;
                    newPosition.y += _ladderDirection.GetProminentVectorComponent() == Vector2.down ? 0.1f : -0.1f;
                    collision.transform.position = newPosition;
                }
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

                _moveScript.ClimbDirection = Vector2.zero;

                if (!_moveScript.IsUsingLadder || _moveScript.IsWalking)
                {
                    _moveScript.CanUseLadder = false;
                }
            }
        }
    }
}