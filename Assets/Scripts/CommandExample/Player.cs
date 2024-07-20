using Command;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _targetObject;
    [SerializeField] float _visibilityThreshold = 0.5f;
    [SerializeField] PlayerInput _playerInput;
    
    private readonly Stack<IMoveCommand> _commandStack = new();

    void Start()
    {
        _playerInput.OnButtonPressed += Move;
        _playerInput.OnGoButtonPressed += Go;
        _playerInput.OnUndoButtonPressed += Undo;
    }

    void OnDestroy()
    {
        _playerInput.OnButtonPressed -= Move;
    }
    
    void Move(IMoveCommand command)
    {
        command.Execute();
        _commandStack.Push(command);
    }

    void Go()
    {
        foreach (var command in _commandStack)
        {
          command.Execute();  
        }
    }

    void Undo()
    {
        if (!_commandStack.Any())
            return;
        
        IMoveCommand command = _commandStack.Pop();
        command.Undo();
    }
}