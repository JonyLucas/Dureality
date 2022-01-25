using System;
using Game.Extensions;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Commands.Platform
{
    [Serializable]
    public class MovePlatformCommand : KeylessBaseCommand
    {
        [SerializeField]
        private Vector3 _destinationPosition;

        [SerializeField]
        private float _moveRate = 0.2f;

        public override async void Execute()
        {
            var delay = _moveRate * 1000;
            var currentPosition = associatedObject.transform.position;
            var originalPosition = currentPosition;

            _destinationPosition.z = currentPosition.z;
            var distance = _destinationPosition - currentPosition;

            while (distance.magnitude > 0 && Application.isPlaying)
            {
                await Task.Delay((int)delay);
                distance.GetProminentVectorComponent();
                associatedObject.transform.position += distance * _moveRate;

                currentPosition = associatedObject.transform.position;
                distance = _destinationPosition - currentPosition;

                if (distance.magnitude < _moveRate)
                {
                    associatedObject.transform.position = _destinationPosition;
                    break;
                }
            }

            if (currentPosition != _destinationPosition)
            {
                associatedObject.transform.position = originalPosition;
            }
        }
    }
}