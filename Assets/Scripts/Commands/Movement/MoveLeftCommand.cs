using System;
using UnityEngine;

namespace Game.Commands.Movement
{
    [Serializable]
    public class MoveLeftCommand : BaseMoveCommand
    {
        public override string AnimationParameter { get => "isWalking"; }

        public MoveLeftCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }

        protected override void ExecuteAction(GameObject gameObject)
        {
            moveScript.IsFacingRight = false;
            moveScript.IsMoving = true;
            gameObject.transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
            animator.SetBool(AnimationParameter, true);
            renderer.flipX = true;
        }

        protected override bool ExecutionCodition(GameObject gameObject)
        {
            var xPosition = moveScript.transform.position.x;
            return !moveScript.IsUsingLadder && Mathf.Abs(xPosition) >= Mathf.Abs(moveScript.XLimit);
        }

        public override void FinalizeAction(GameObject gameObject)
        {
            moveScript.IsMoving = false;
            animator.SetBool(AnimationParameter, false);

            var xPosition = moveScript.transform.position.x;
            if (Mathf.Abs(xPosition) < Mathf.Abs(moveScript.XLimit))
            {
                var newPosition = moveScript.transform.position;
                newPosition.x = moveScript.XLimit;
                moveScript.transform.position = newPosition;
            }
        }
    }
}