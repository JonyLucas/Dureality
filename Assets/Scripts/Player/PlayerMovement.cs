using Game.Commands.Movement;
using Game.Player.ScriptableObjects;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private PlayerControl _control;

        [SerializeField]
        private bool _isReverse = false;

        //[SerializeField]
        //private SoundFx _jumpSfx;

        //[SerializeField]
        //private SoundFx _landingSfx;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private AudioSource _audioSource;

        public bool IsFacingRight { get; set; } = true;
        public bool IsMoving { get; set; } = false;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                BaseMoveCommand command = null;
                if (!_isReverse)
                {
                    command = _control.MoveCommands
                        .FirstOrDefault(command => Input.GetKey(command.AssociatedKey));
                }
                else
                {
                    command = _control.ReverseCommands
                        .FirstOrDefault(command => Input.GetKey(command.AssociatedKey));
                }

                if (command != null)
                {
                    HorizontalMovement(command);
                }
            }
            else
            {
                if (IsMoving)
                {
                    StopMovement();
                }
            }
        }

        // Check later
        private void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey)
            {
                Debug.Log("Detected Key: " + e.keyCode);
            }
        }

        private void HorizontalMovement(BaseMoveCommand command)
        {
            if (command.GetType() == typeof(MoveRightCommand))
            {
                command.Execute(gameObject);
                IsFacingRight = true;
                IsMoving = true;
            }
            else if (command.GetType() == typeof(MoveLeftCommand))
            {
                command.Execute(gameObject);
                IsFacingRight = false;
                IsMoving = true;
            }
            else
            {
                StopMovement();
            }
        }

        public void StopMovement()
        {
            IsMoving = false;
            _animator.SetBool("isWalking", IsMoving);
        }

        public void PlayerDeath()
        {
            StopMovement();
            enabled = false;
        }
    }
}