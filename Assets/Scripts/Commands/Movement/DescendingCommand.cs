using UnityEngine;

namespace Game.Commands.Movement
{
    public class DescendingCommand : LadderMoveCommand
    {
        protected override Vector2 MoveDirection => Vector2.down;

        public DescendingCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }
    }
}