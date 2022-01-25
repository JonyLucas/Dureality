using System;
using UnityEngine;

namespace Game.Commands.Platform
{
    [Serializable]
    public class DestroyPlatformCommand : KeylessBaseCommand
    {
        [SerializeField]
        private GameObject _destructiveObject;

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}