using UnityEngine;

namespace Command
{
    public class LeftCommand : ICommand
    {
        Player _player;

        public LeftCommand(Player player)
        {
            _player = player;
        }
        
        public void Execute()
        {
            _player.MoveLeft();
        }

        public void Undo()
        {
            _player.MoveRight();
        }
    }
}