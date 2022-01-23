using Game.Extensions;
using Game.ScriptableObjects.Events;
using System.Collections;
using UnityEngine;

namespace Game.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        private GameEvent _playerDeathEvent;

        [SerializeField]
        private string _deathAnimationName;

        private Animator _animator;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void PlayerDeath()
        {
            _playerDeathEvent.OnOcurred();
            _rigidbody.simulated = false;
            StartCoroutine(DeathCoroutine());
        }

        private IEnumerator DeathCoroutine()
        {
            var clipDuration = _animator.GetAnimationClipDuration(_deathAnimationName);
            _animator.SetTrigger("deadTrigger");
            yield return new WaitForSeconds(clipDuration);
            gameObject.SetActive(false);
        }
    }
}