using Game.Commands.Factories;
using Game.Commands.Movement;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Player Control", fileName = "Player Control", order = 55)]
    public class PlayerControl : ScriptableObject
    {
        [SerializeField]
        private List<MoveCommandFactory> _commandsFactory;

        private List<BaseMoveCommand> _moveCommands;

        private List<BaseMoveCommand> _reverseCommands;

        public List<BaseMoveCommand> MoveCommands
        { get { return _moveCommands; } }

        public List<BaseMoveCommand> ReverseCommands
        { get { return _reverseCommands; } }

        private void OnEnable()
        {
            _moveCommands = new List<BaseMoveCommand>();
            _reverseCommands = new List<BaseMoveCommand>();
            _commandsFactory.ForEach(command => _moveCommands.Add(command.Create()));
            _commandsFactory.ForEach(command => _reverseCommands.Add(command.Create(true)));
        }

        public void InitializeCommands(GameObject gameObject)
        {
            _moveCommands.ForEach(command => command.InitializeFields(gameObject));
            _reverseCommands.ForEach(command => command.InitializeFields(gameObject));
        }
    }
}