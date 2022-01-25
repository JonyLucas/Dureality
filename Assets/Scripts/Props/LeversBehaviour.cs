using Game.Commands.Platform;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Props
{
    public class LeversBehaviour : MonoBehaviour
    {
        [SerializeField]
        private List<MovePlatformCommand> _moveCommands;

        [SerializeField]
        private List<RotatePlatformCommand> _rotateCommands;

        [SerializeField]
        private bool _runOnce = false;

        private Collider2D _collider;
        private Animator _animator;
        private bool _isActive = false;

        private void Start()
        {
            _collider = GetComponent<Collider2D>();
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                _moveCommands.ForEach(command => command.Execute());
                _rotateCommands.ForEach(command => command.Execute());
                _isActive = !_isActive;
                _animator.SetBool("isActive", _isActive);

                if (_runOnce)
                {
                    _collider.enabled = false;
                }
            }
        }
    }
}