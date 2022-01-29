using Game.Audio;
using Game.Commands.Platform;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private List<Task> _tasks;
        private bool _isActive = false;
        private AudioManager _audioManager;

        private void Start()
        {
            var audioManagerObj = GameObject.FindGameObjectWithTag("AudioManager");
            if (audioManagerObj != null)
            {
                _audioManager = audioManagerObj.GetComponent<AudioManager>();
            }

            _collider = GetComponent<Collider2D>();
            _animator = GetComponent<Animator>();
            _tasks = new List<Task>();
        }

        private async void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                await Task.WhenAll(_tasks);
                _tasks = new List<Task>();

                _isActive = !_isActive;
                _animator.SetBool("isActive", _isActive);

                _moveCommands.ForEach(command => _tasks.Add(command.Execute()));
                _rotateCommands.ForEach(command => _tasks.Add(command.Execute()));

                if (_audioManager != null)
                {
                    _audioManager.Play("PullLever");
                }

                if (_runOnce)
                {
                    _collider.enabled = false;
                }
            }
        }
    }
}