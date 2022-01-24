using UnityEngine;

namespace Game.Commands
{
    public abstract class KeylessBaseCommand
    {
        protected GameObject associatedObject;

        protected KeylessBaseCommand(GameObject gameObject)
        {
            associatedObject = gameObject;
        }

        public abstract void Execute();
    }
}