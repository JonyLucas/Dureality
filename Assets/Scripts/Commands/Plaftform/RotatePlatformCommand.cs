using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Commands.Platform
{
    [Serializable]
    public class RotatePlatformCommand : KeylessBaseCommand
    {
        [SerializeField]
        private float _rotation;

        [SerializeField]
        private float _rotationRate = 0.1f;

        public override async Task Execute()
        {
            if (associatedObject == null || _rotationRate <= 0)
            {
                return;
            }

            var delay = _rotationRate * 500;
            var currentRotation = associatedObject.transform.rotation;
            var originalRotation = currentRotation;

            var distance = _rotation - currentRotation.eulerAngles.z;

            while (distance > 0 && Application.isPlaying)
            {
                await Task.Delay((int)delay);

                associatedObject.transform.Rotate(Vector3.forward);
                currentRotation = associatedObject.transform.rotation;
                distance = _rotation - currentRotation.eulerAngles.z;
            }

            currentRotation = associatedObject.transform.rotation;
            if (currentRotation.eulerAngles.z != _rotation)
            {
                associatedObject.transform.rotation = originalRotation;
            }
        }
    }
}