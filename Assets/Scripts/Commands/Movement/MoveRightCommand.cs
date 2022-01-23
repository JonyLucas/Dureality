using System;
using UnityEngine;

namespace Game.Commands.Movement
{
    [Serializable]
    public class MoveRightCommand : WalkingCommand
    {
        protected override Vector2 MoveDirection => Vector2.right;

        public MoveRightCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }
    }
}