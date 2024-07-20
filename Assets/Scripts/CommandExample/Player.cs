using Command;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _targetObject;
    [SerializeField] float _visibilityThreshold = 0.5f;
    [FormerlySerializedAs("playerHandler")] [FormerlySerializedAs("_playerInput")] [SerializeField] InputHandler inputHandler;
    
    private readonly Stack<ICommand> _commandStack = new();

    public void addCommand(ICommand command) => _commandStack.Push(command);

    void Move(ICommand command)
    {
        command.Execute();
        _commandStack.Push(command);
    }
    
    public void MoveForward() => transform.Translate(Vector3.forward);

    public void MoveBack() => transform.Translate(Vector3.back);

    public void MoveLeft() => transform.Translate(Vector3.left);

    public void MoveRight() => transform.Translate(Vector3.right);

    public void Go()
    {
        foreach (var command in _commandStack)
        {
          command.Execute();  
        }
    }

    public void Undo()
    {
        if (!_commandStack.Any())
            return;
        
        ICommand command = _commandStack.Pop();
        command.Undo();
    }
}