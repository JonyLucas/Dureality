using Game.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class CollectableCounter : MonoBehaviour
    {
        [SerializeField]
        private GameEvent collectAllEvent;

        [SerializeField]
        private Text _yangCollectableCounter;

        [SerializeField]
        private Text _yinCollectableCounter;

        private int _yinCount = 0;
        private int _yangCount = 0;
        private int _yinMaxCount;
        private int _yangMaxCount;

        // Start is called before the first frame update
        private void Start()
        {
            _yinMaxCount = GameObject.FindGameObjectsWithTag("YinCollectable").Length;
            _yangMaxCount = GameObject.FindGameObjectsWithTag("YangCollectable").Length;

            _yangCollectableCounter.text = $"{_yangCount}/{_yangMaxCount}";
            _yinCollectableCounter.text = $"{_yinCount}/{_yinMaxCount}";
        }

        public void UpdateCount(bool isYinCollected)
        {
            if (isYinCollected)
            {
                _yinCollectableCounter.text = $"{++_yinCount}/{_yinMaxCount}";
            }
            else
            {
                _yangCollectableCounter.text = $"{++_yangCount}/{_yangMaxCount}";
            }

            if (_yinCount == _yinMaxCount && _yangCount == _yangMaxCount)
            {
                collectAllEvent.OnOcurred();
            }
        }
    }
}