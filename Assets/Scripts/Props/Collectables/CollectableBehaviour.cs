using Game.ScriptableObjects.Events;
using UnityEngine;

namespace Game.Props
{
    public class CollectableBehaviour : MonoBehaviour
    {
        [SerializeField]
        private bool _isYinPart;

        [SerializeField]
        private BoolGameEvent _collectEvent;
    }
}