using System;
using UnityEngine;

namespace Game.Commands.Platform
{
    [Serializable]
    public class RotatePlatformCommand : KeylessBaseCommand
    {
        [SerializeField]
        private float _rotation;

        public override void Execute()
        {
            if (associatedObject != null)
            {
            }
        }
    }
}