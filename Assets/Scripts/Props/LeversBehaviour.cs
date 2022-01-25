using Game.Commands.Platform;
using UnityEngine;

namespace Game.Props
{
    public class LeversBehaviour : MonoBehaviour
    {
        [SerializeField]
        private MovePlatformCommand _moveCommand;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _moveCommand.Execute();
        }
    }
}