using UnityEngine;

namespace Game.Props
{
    public class BlockAnimation : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 2;

        [SerializeField]
        private float _finalYPosition = 10;

        private Vector2 _moveDirection = Vector2.up;

        private void Start()
        {
            if (transform.position.y > _finalYPosition)
            {
                _moveDirection = Vector2.up;
            }
            else
            {
                _moveDirection = Vector2.down;
            }
        }

        private void FixedUpdate()
        {
            transform.Translate(_moveDirection * _speed * Time.fixedDeltaTime);
            if (Mathf.Abs(transform.position.y) > Mathf.Abs(_finalYPosition))
            {
                gameObject.SetActive(false);
            }
        }
    }
}