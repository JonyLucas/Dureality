using System;
using UnityEngine;

namespace Game.Commands
{
    [Serializable]
    public abstract class KeylessBaseCommand
    {
        [SerializeField]
        protected GameObject associatedObject;

        public abstract void Execute();
    }
}