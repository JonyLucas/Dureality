using Game.Extensions;
using System.Collections;
using UnityEngine;

namespace Game.Props
{
    public class BreakingFloorBehaviour : MonoBehaviour
    {
        private Animator _animator;
        private float _clipDuration;
        private Collider2D _collider;

        private void OnEnable()
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
                _clipDuration = _animator.GetAnimationClipDuration("breaking_floor_black");
                _collider = GetComponent<Collider2D>();
            }

            StartCoroutine(BreakCoroutine());
        }

        private IEnumerator BreakCoroutine()
        {
            _animator.SetTrigger("break");

            yield return new WaitForSeconds(_clipDuration / 2);
            if (_collider != null)
            {
                _collider.enabled = false;
            }

            yield return new WaitForSeconds(_clipDuration / 2);
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _collider.enabled = true;
        }
    }
}