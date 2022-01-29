using Game.Commands.Factories;
using Game.Commands.Movement;
using Game.Enums;
using Game.Player.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ChangeAssociatedKey : MonoBehaviour
    {
        [SerializeField]
        private PlayerControl _playerControl;

        [SerializeField]
        private Text _leftCommandText;

        [SerializeField]
        private Text _rightCommandText;

        [SerializeField]
        private Text _climbCommandText;

        [SerializeField]
        private Text _descendCommandText;

        private BaseMoveCommand _selectedMoveCommand;
        private BaseMoveCommand _reverseMoveCommand;

        private List<MoveCommandFactory> _commandsFactory;

        private void Awake()
        {
            UpdateButtonText();
            InitializeFactories();
        }

        public void UpdateButtonText()
        {
            _leftCommandText.text = _playerControl.MoveCommands
                .Find(command => command.CommandType == MoveCommandType.MoveLeft)
                .AssociatedKey.ToString();

            _rightCommandText.text = _playerControl.MoveCommands
                .Find(command => command.CommandType == MoveCommandType.MoveRight)
                .AssociatedKey.ToString();

            _climbCommandText.text = _playerControl.MoveCommands
                .Find(command => command.CommandType == MoveCommandType.Climb)
                .AssociatedKey.ToString();

            _descendCommandText.text = _playerControl.MoveCommands
                .Find(command => command.CommandType == MoveCommandType.Descend)
                .AssociatedKey.ToString();
        }

        private void InitializeFactories()
        {
            _commandsFactory = new List<MoveCommandFactory>();
            _commandsFactory.Add(new MoveCommandFactory { CommandType = MoveCommandType.MoveRight });
            _commandsFactory.Add(new MoveCommandFactory { CommandType = MoveCommandType.MoveLeft });
            _commandsFactory.Add(new MoveCommandFactory { CommandType = MoveCommandType.Climb });
            _commandsFactory.Add(new MoveCommandFactory { CommandType = MoveCommandType.Descend });
        }

        public void SetCommand(int moveCommandType)
        {
            _selectedMoveCommand = _playerControl.MoveCommands.FirstOrDefault(command => command.CommandType == (MoveCommandType)moveCommandType);
            if (_selectedMoveCommand != null)
            {
                _reverseMoveCommand = _playerControl.ReverseCommands.FirstOrDefault(command => command.AssociatedKey == _selectedMoveCommand.AssociatedKey);
            }
        }

        private void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey)
            {
                if (e.keyCode != KeyCode.Escape
                    && _selectedMoveCommand != null
                    && _reverseMoveCommand != null)
                {
                    var factory = _commandsFactory.Find(factory => factory.CommandType == _selectedMoveCommand.CommandType);
                    if (factory != null)
                    {
                        factory.AssociatedKey = e.keyCode;
                        _playerControl.MoveCommands.Add(factory.Create());
                        _playerControl.ReverseCommands.Add(factory.Create(true));
                        _playerControl.MoveCommands.Remove(_selectedMoveCommand);
                        _playerControl.ReverseCommands.Remove(_reverseMoveCommand);
                    }
                }
                Debug.Log("Detected Key: " + e.keyCode);
                UpdateButtonText();
                gameObject.SetActive(false);
            }
        }
    }
}