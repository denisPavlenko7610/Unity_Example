using System;
using UnityEngine;
using UnityEngine.UI;

namespace Command
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] InputButton[] _buttons;
        [SerializeField] Button _go;
        [SerializeField] Button _undo;
        [SerializeField] Player _player;

        public Action<IMoveCommand> OnButtonPressed;
        public Action OnGoButtonPressed;
        public Action OnUndoButtonPressed;

        void Awake()
        {
            foreach (InputButton inputButton in _buttons)
            {
                inputButton.Button.onClick.AddListener(() => MoveButtonPressed(inputButton));
            }
            
            _go.onClick.AddListener(GoButtonPressed);
            _undo.onClick.AddListener(UndoButtonPressed);
        }

        void OnDestroy()
        {
            foreach (InputButton inputButton in _buttons)
            {
                inputButton.Button.onClick.RemoveAllListeners();
            }
        }

        void MoveButtonPressed(InputButton inputButton) => OnButtonPressed?.Invoke(GetCommand(inputButton));
        void GoButtonPressed() => OnGoButtonPressed?.Invoke();
        void UndoButtonPressed() => OnUndoButtonPressed?.Invoke();

        IMoveCommand GetCommand(InputButton button)
        {
            return button.ButtonDirection switch
            {
                InputButton.Directions.Right => new MoveRightCommand(_player),
                InputButton.Directions.Left => new MoveLeftCommand(_player),
                InputButton.Directions.Back => new MoveBackCommand(_player),
                InputButton.Directions.Forward => new MoveForwardCommand(_player),
            };
        }
    }
}