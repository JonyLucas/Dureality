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
            _control.InitializeCommands(gameObject);
            _moveCommands = !_isReverse ? _control.MoveCommands : _control.ReverseCommands;
        }

        private void FixedUpdate()
        {
            if (Input.anyKey)
            {
                var command = _moveCommands.FirstOrDefault(command => Input.GetKey(command.AssociatedKey));

                if (command != null)
                {
                    command.Execute(gameObject);
                }
            }
            else
            {
                if (IsWalking)
                {
                    Debug.Log("STOP");
                    StopMovement();
                }
            }
        }

        public void StopMovement()
        {
            var command = _moveCommands
                        .FirstOrDefault(command => command.GetType() == typeof(MoveLeftCommand));

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