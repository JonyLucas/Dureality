using System;
using UnityEngine;

namespace Game.Commands.Movement
{
    [Serializable]
    public abstract class LadderMoveCommand : BaseMoveCommand
    {
        public override string AnimationParameter { get => "isClimbing"; }

        protected abstract Vector2 MoveDirection { get; }

        protected LadderMoveCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }

        protected override void ExecuteAction(GameObject gameObject)
        {
            moveScript.IsUsingLadder = true;
            moveScript.StopMovement();
            animator.SetBool(AnimationParameter, true);
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            gameObject.transform.Translate(MoveDirection * speed * Time.fixedDeltaTime);
        }

        protected override bool ExecutionCodition(GameObject gameObject)
        {
            return moveScript.CanUseLadder
                && !moveScript.IsWalking
                && moveScript.ClimbDirection != -MoveDirection
                && !moveScript.IsPaused;
        }

        public override void FinalizeAction(GameObject gameObject)
        {
            moveScript.IsUsingLadder = false;
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            animator.SetBool(AnimationParameter, false);
        }
    }
}