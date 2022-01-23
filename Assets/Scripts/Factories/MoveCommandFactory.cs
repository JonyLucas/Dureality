using Game.Commands.Movement;
using Game.Enums;
using System;
using UnityEngine;

namespace Game.Commands.Factories
{
    [Serializable]
    public class MoveCommandFactory
    {
        [SerializeField]
        private KeyCode _associatedKey;

        [SerializeField]
        private MoveCommandType _commandType;

        [SerializeField]
        private float _moveSpeed = 1;

        public BaseMoveCommand Create(bool isReverse = false)
        {
            switch (_commandType)
            {
                case MoveCommandType.MoveLeft:
                    if (!isReverse)
                    {
                        return new MoveLeftCommand(_associatedKey, _moveSpeed);
                    }
                    else
                    {
                        return new MoveRightCommand(_associatedKey, _moveSpeed);
                    }

                case MoveCommandType.MoveRight:
                    if (!isReverse)
                    {
                        return new MoveRightCommand(_associatedKey, _moveSpeed);
                    }
                    else
                    {
                        return new MoveLeftCommand(_associatedKey, _moveSpeed);
                    }
                case MoveCommandType.Climb:
                    if (!isReverse)
                    {
                        return new ClimbingCommand(_associatedKey, _moveSpeed);
                    }
                    else
                    {
                        return new DescendingCommand(_associatedKey, _moveSpeed);
                    }
                case MoveCommandType.Descend:
                    if (!isReverse)
                    {
                        return new DescendingCommand(_associatedKey, _moveSpeed);
                    }
                    else
                    {
                        return new ClimbingCommand(_associatedKey, _moveSpeed);
                    }

                default:
                    return null;
            }
        }
    }
}