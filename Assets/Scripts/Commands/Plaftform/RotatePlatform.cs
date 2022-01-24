using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Commands.Platform
{
    public class RotatePlatform : KeylessBaseCommand
    {
        public RotatePlatform(GameObject gameObject, float rotationDegree) : base(gameObject)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}