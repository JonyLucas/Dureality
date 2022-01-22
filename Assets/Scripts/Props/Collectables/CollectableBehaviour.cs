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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                _collectEvent.OnOcurred(_isYinPart);
                gameObject.SetActive(false);
            }
        }
    }
}