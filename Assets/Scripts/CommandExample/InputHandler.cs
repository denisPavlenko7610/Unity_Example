using UnityEngine;
using UnityEngine.UI;

namespace Command
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] Button _rightButton;
        [SerializeField] Button _LeftButton;
        [SerializeField] Button _forwardButton;
        [SerializeField] Button _backButton;
        
        [SerializeField] Button _go;
        [SerializeField] Button _undo;
        
        [SerializeField] Player _player;

        private ICommand _forwardCommand;
        private ICommand _backCommand;
        private ICommand _leftCommand;
        private ICommand _rightCommand;

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
            _forwardCommand = new ForwardCommand(_player);
            _backCommand = new BackCommand(_player);
            _leftCommand = new LeftCommand(_player);
            _rightCommand = new RightCommand(_player);
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
            _forwardCommand.Execute();
            _player.addCommand(_forwardCommand);
        }
        
        void OnMoveBackButtonPressed()
        {
            _backCommand.Execute();
            _player.addCommand(_backCommand);
        }
        
        void OnMoveLeftButtonPressed()
        {
            _leftCommand.Execute();
            _player.addCommand(_leftCommand);
        }
        
        void OnMoveRightButtonPressed()
        {
            _rightCommand.Execute();
            _player.addCommand(_rightCommand);
        }
    }
}