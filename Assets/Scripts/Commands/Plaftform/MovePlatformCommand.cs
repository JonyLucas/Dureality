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

        [SerializeField]
        private float _speed = 1;

        public override async void Execute()
        {
            if (associatedObject == null || _moveRate <= 0)
            {
                return;
            }

            var delay = _moveRate * 500;
            var currentPosition = associatedObject.transform.position;
            var originalPosition = currentPosition;

            _destinationPosition.z = currentPosition.z;
            var distance = _destinationPosition - currentPosition;

            while (distance.magnitude > 0 && Application.isPlaying)
            {
                if (distance.magnitude < _moveRate || _speed == 0)
                {
                    associatedObject.transform.position = _destinationPosition;
                    break;
                }

                await Task.Delay((int)delay);

                if (associatedObject == null)
                {
                    return;
                }

                associatedObject.transform.position += distance.GetProminentVectorComponent() * _speed;

                currentPosition = associatedObject.transform.position;
                distance = _destinationPosition - currentPosition;
            }

            currentPosition = associatedObject.transform.position;
            if (currentPosition != _destinationPosition)
            {
                associatedObject.transform.position = originalPosition;
            }
        }
    }
}