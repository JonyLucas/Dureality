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

        private Vector3 _auxDestinationPosition;
        private Vector3 _originalPosition;

        public override async void Execute()
        {
            if (associatedObject == null || _moveRate <= 0)
            {
                return;
            }

            // Initialize variables
            var delay = _moveRate * 500;
            var currentPosition = associatedObject.transform.position;
            _originalPosition = currentPosition;

            if (_auxDestinationPosition == default)
            {
                _auxDestinationPosition = _destinationPosition;
                _auxDestinationPosition.z = currentPosition.z;
            }
            var distance = _auxDestinationPosition - currentPosition;

            // Translate
            while (distance.magnitude > 0 && Application.isPlaying)
            {
                if (distance.magnitude < _moveRate || _moveRate == 0)
                {
                    associatedObject.transform.position = _auxDestinationPosition;
                    break;
                }

                await Task.Delay((int)delay);

                if (associatedObject == null)
                {
                    return;
                }

                associatedObject.transform.position += distance.GetProminentVectorComponent() * _moveRate;

                currentPosition = associatedObject.transform.position;
                distance = _auxDestinationPosition - currentPosition;
            }

            currentPosition = associatedObject.transform.position;
            if (currentPosition != _auxDestinationPosition)
            {
                associatedObject.transform.position = _originalPosition;
            }

            // Swaps positions for reverse execution
            var swap = _destinationPosition;
            _auxDestinationPosition = _originalPosition;
            _originalPosition = swap;
        }
    }
}