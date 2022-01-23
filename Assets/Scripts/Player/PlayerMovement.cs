using Game.Commands.Movement;
using Game.Player.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        // Fields

        [SerializeField]
        private PlayerControl _control;

        [SerializeField]
        private bool _isReverse = false;

        [SerializeField]
        private float _xLimit = 0.2f;

        private List<BaseMoveCommand> _moveCommands;
        private Animator _animator;

        // Properties

        public bool IsFacingRight { get; set; } = true;
        public bool IsWalking { get; set; } = false;
        public bool CanUseLadder { get; set; } = false;
        public bool IsUsingLadder { get; set; } = false;
        public Vector2 ClimbDirection { get; set; } = Vector2.zero;

        public float XLimit
        { get { return _xLimit; } }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _moveCommands = !_isReverse ? _control.MoveCommands : _control.ReverseCommands;
            _moveCommands.ForEach(command => command.InitializeFields(gameObject));
        }

        private void FixedUpdate()
        {
            if (Input.anyKey)
            {
                var command = _moveCommands.FirstOrDefault(command => Input.GetKey(command.AssociatedKey));

                if (command != null)
                {
                    _animator.speed = 1;
                    command.Execute(gameObject);
                }
            }
            else
            {
                if (IsWalking)
                {
                    StopMovement();
                }

                if (IsUsingLadder)
                {
                    _animator.speed = 0;
                }
            }
        }

        public void StopMovement()
        {
            var command = _moveCommands
                        .FirstOrDefault(command => command.GetType().BaseType == typeof(WalkingCommand));

            if (command != null)
            {
                command.FinalizeAction(gameObject);
            }
        }

        public void StopClimbing()
        {
            var command = _moveCommands
            .FirstOrDefault(command => command.GetType() == typeof(ClimbingCommand) || command.GetType() == typeof(DescendingCommand));

            if (command != null)
            {
                command.FinalizeAction(gameObject);
            }
        }

        public void PlayerDeath()
        {
            StopMovement();
            enabled = false;
        }
    }
}