using Game.Commands.Movement;
using Game.Player.ScriptableObjects;
using System.Collections.Generic;
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

        private List<BaseMoveCommand> _moveCommands;

        public bool IsFacingRight { get; set; } = true;
        public bool IsMoving { get; set; } = false;
        public bool CanUseLadder { get; set; } = false;
        public bool IsUsingLadder { get; set; } = false;

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
                if (IsMoving)
                {
                    StopMovement();
                }
            }
        }

        public void StopMovement()
        {
            var command = _moveCommands
                        .FirstOrDefault(command => command.GetType() == typeof(MoveLeftCommand) || command.GetType() == typeof(MoveRightCommand));

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