using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Commands.Platform
{
    public class MovePlatform : KeylessBaseCommand
    {
        public MovePlatform(GameObject gameObject, Vector2 movePosition) : base(gameObject)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}