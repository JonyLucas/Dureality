using Game.Enums;
using System;
using UnityEngine;

namespace Game.Commands.Movement
{
    [Serializable]
    public class ClimbingCommand : LadderMoveCommand
    {
        protected override Vector2 MoveDirection => Vector2.up;
        public override MoveCommandType CommandType { get => MoveCommandType.Climb; }

        public ClimbingCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }
    }
}