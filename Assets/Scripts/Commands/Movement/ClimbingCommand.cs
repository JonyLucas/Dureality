using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Commands.Movement
{
    [Serializable]
    public class ClimbingCommand : LadderMoveCommand
    {
        protected override Vector2 MoveDirection => Vector2.up;

        public ClimbingCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }
    }
}