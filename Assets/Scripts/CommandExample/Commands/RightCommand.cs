using UnityEngine;

namespace Command
{
    public class RightCommand : ICommand
    {
        Player _player;

        public RightCommand(Player player)
        {
            _player = player;
        }
        
        public void Execute()
        {
            _player.MoveRight();
        }

        public void Undo()
        {
            _player.MoveLeft();
        }
    }
}