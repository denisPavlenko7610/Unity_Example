using UnityEngine;
using UnityEngine.UI;

namespace Command
{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] Button _rightButton;
        [SerializeField] Button _LeftButton;
        [SerializeField] Button _forwardButton;
        [SerializeField] Button _backButton;
        
        [SerializeField] Button _go;
        [SerializeField] Button _undo;
        
        [SerializeField] Player _player;

        private IMoveCommand _moveForwardCommand;
        private IMoveCommand _moveBackCommand;
        private IMoveCommand _moveLeftCommand;
        private IMoveCommand _moveRightCommand;

        void Awake()
        {
            _rightButton.onClick.AddListener(OnMoveRightButtonPressed);
            _LeftButton.onClick.AddListener(OnMoveLeftButtonPressed);
            _forwardButton.onClick.AddListener(OnMoveForwardButtonPressed);
            _backButton.onClick.AddListener(OnMoveBackButtonPressed);

            _go.onClick.AddListener(GoButtonPressed);
            _undo.onClick.AddListener(UndoButtonPressed);
        }

        void Start()
        {
            _moveForwardCommand = new MoveForwardCommand(_player);
            _moveBackCommand = new MoveBackCommand(_player);
            _moveLeftCommand = new MoveLeftCommand(_player);
            _moveRightCommand = new MoveRightCommand(_player);
        }

        void OnDestroy()
        {
            _rightButton.onClick.RemoveListener(OnMoveRightButtonPressed);
            _LeftButton.onClick.RemoveListener(OnMoveLeftButtonPressed);
            _forwardButton.onClick.RemoveListener(OnMoveForwardButtonPressed);
            _backButton.onClick.RemoveListener(OnMoveBackButtonPressed);
        }
        
        void GoButtonPressed() => _player.Go();
        void UndoButtonPressed() => _player.Undo();

        void OnMoveForwardButtonPressed()
        {
            _moveForwardCommand.Execute();
            _player.addCommand(_moveForwardCommand);
        }
        
        void OnMoveBackButtonPressed()
        {
            _moveBackCommand.Execute();
            _player.addCommand(_moveBackCommand);
        }
        
        void OnMoveLeftButtonPressed()
        {
            _moveLeftCommand.Execute();
            _player.addCommand(_moveLeftCommand);
        }
        
        void OnMoveRightButtonPressed()
        {
            _moveRightCommand.Execute();
            _player.addCommand(_moveRightCommand);
        }
    }
}