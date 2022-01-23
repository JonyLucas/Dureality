using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Commands.Movement
{
    [Serializable]
    public abstract class WalkingCommand : BaseMoveCommand
    {
        public override string AnimationParameter { get => "isWalking"; }

        protected abstract Vector2 MoveDirection { get; }

        protected WalkingCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }

        protected override void ExecuteAction(GameObject gameObject)
        {
            moveScript.IsFacingRight = true;
            moveScript.IsWalking = true;
            gameObject.transform.Translate(MoveDirection * speed * Time.fixedDeltaTime);
            animator.SetBool(AnimationParameter, true);
            renderer.flipX = MoveDirection == Vector2.left;
        }

        protected override bool ExecutionCodition(GameObject gameObject)
        {
            var xPosition = moveScript.transform.position.x;
            return !moveScript.IsUsingLadder && Mathf.Abs(xPosition) >= Mathf.Abs(moveScript.XLimit);
        }

        public override void FinalizeAction(GameObject gameObject)
        {
            moveScript.IsWalking = false;
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