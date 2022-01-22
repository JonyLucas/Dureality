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
            return !moveScript.IsUsingLadder;
        }

        public override void FinalizeAction(GameObject gameObject)
        {
            moveScript.IsMoving = false;
            animator.SetBool(AnimationParameter, false);
        }
    }
}