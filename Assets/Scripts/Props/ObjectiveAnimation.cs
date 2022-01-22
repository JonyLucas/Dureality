using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Props
{
    public class ObjectiveAnimation : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed;

        private Vector3 _currentRotation;

        // Update is called once per frame
        private void Update()
        {
            _currentRotation = transform.rotation.eulerAngles;
            _currentRotation.z += _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(_currentRotation);
        }
    }
}