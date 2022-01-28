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
            var rotationDirection = _rotation > 0 ? Vector3.forward : Vector3.back;

            while (Mathf.Abs(distance) > 0 && Application.isPlaying)
            {
                await Task.Delay((int)delay);

                if (associatedObject == null)
                {
                    return;
                }

                associatedObject.transform.Rotate(rotationDirection);
                currentRotation = associatedObject.transform.rotation;
                distance = (float)Math.Round(_rotation - currentRotation.eulerAngles.z);
                Debug.Log(distance);
            }

            // round the z angle to prevent unintentional behaviour
            currentRotation = associatedObject.transform.rotation;
            var roundedZangle = (float)Math.Round(currentRotation.eulerAngles.z);
            associatedObject.transform.eulerAngles = new Vector3(currentRotation.x, currentRotation.y, roundedZangle);
            currentRotation = associatedObject.transform.rotation;

            if (roundedZangle != _rotation)
            {
                associatedObject.transform.rotation = originalRotation;
            }

            _rotation = originalRotation.eulerAngles.z;
        }
    }
}