using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Commands.Platform
{
    public class DestroyPlatform : KeylessBaseCommand
    {
        public DestroyPlatform(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}