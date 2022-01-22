using UnityEngine;

namespace Game.Commands.Movement
{
    public class DescendingCommand : BaseMoveCommand
    {
        public override string AnimationParameter { get => "isClimbing"; }

        public DescendingCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }

        protected override void ExecuteAction(GameObject gameObject)
        {
            moveScript.IsUsingLadder = true;
            moveScript.ClimbDirection = Vector2.down;
            moveScript.StopMovement();
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            gameObject.transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
            //animator.SetBool(AnimationParameter, true);
        }

        protected override bool ExecutionCodition(GameObject gameObject)
        {
            return moveScript.CanUseLadder && !moveScript.IsMoving && moveScript.ClimbDirection != Vector2.up;
        }

        public override void FinalizeAction(GameObject gameObject)
        {
            moveScript.IsUsingLadder = false;
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}