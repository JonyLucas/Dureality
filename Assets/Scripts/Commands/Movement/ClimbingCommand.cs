using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Commands.Movement
{
    [Serializable]
    public class ClimbingCommand : BaseMoveCommand
    {
        public override string AnimationParameter { get => "isClimbing"; }

        public ClimbingCommand(KeyCode associatedKey, float speedValue) : base(associatedKey, speedValue)
        {
        }

        protected override void ExecuteAction(GameObject gameObject)
        {
            moveScript.IsUsingLadder = true;
            moveScript.MoveDirection = Vector3.up;
            moveScript.StopMovement();
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            gameObject.transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
            //animator.SetBool(AnimationParameter, true);
        }

        protected override bool ExecutionCodition(GameObject gameObject)
        {
            return moveScript.CanUseLadder && !moveScript.IsMoving;
        }

        public override void FinalizeAction(GameObject gameObject)
        {
            moveScript.IsUsingLadder = false;
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}