using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Commands.Platform
{
    [Serializable]
    public class DestroyPlatformCommand : KeylessBaseCommand
    {
        [SerializeField]
        private GameObject _breakingFloorPrefab;

        private static GameObject _breakingFloorParent;
        private GameObject _breakingFloorInstance;

        private static void InitializeParent()
        {
            if (_breakingFloorParent == null)
            {
                _breakingFloorParent = GameObject.Instantiate(new GameObject());
                _breakingFloorParent.transform.position = Vector3.zero;
            }
        }

        public override Task Execute()
        {
            InitializeParent();
            associatedObject.SetActive(!associatedObject.activeInHierarchy);

            if (_breakingFloorInstance == null)
            {
                _breakingFloorInstance = GameObject.Instantiate(_breakingFloorPrefab, _breakingFloorParent.transform);
            }

            _breakingFloorInstance.SetActive(!associatedObject.activeInHierarchy);
            _breakingFloorInstance.transform.position = associatedObject.transform.position;
            _breakingFloorInstance.transform.rotation = associatedObject.transform.rotation;
            _breakingFloorInstance.transform.localScale = associatedObject.transform.localScale;

            return Task.CompletedTask;
        }
    }
}