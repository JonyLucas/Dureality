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
            var delay = _moveRate * 500;
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
                    Debug.Log("BREAK");
                    associatedObject.transform.position = _destinationPosition;
                    break;
                }
            }

            currentPosition = associatedObject.transform.position;
            if (currentPosition != _destinationPosition)
            {
                associatedObject.transform.position = originalPosition;
            }
        }
    }
}