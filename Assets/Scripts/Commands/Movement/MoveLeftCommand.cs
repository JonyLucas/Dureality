using System;
using UnityEngine;

namespace Game.Commands.Movement
{
    [Serializable]
    public class MoveLeftCommand : WalkingCommand
    {
        protected override Vector2 MoveDirection => Vector2.left;

        public MoveLeftCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }
    }
}