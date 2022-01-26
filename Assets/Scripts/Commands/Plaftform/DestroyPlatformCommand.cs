using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Commands.Platform
{
    [Serializable]
    public class DestroyPlatformCommand : KeylessBaseCommand
    {
        [SerializeField]
        private GameObject _destructiveObject;

        public override Task Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}