using UnityEngine;

namespace Command
{
    public class ForwardCommand : ICommand
    {
        Player _player;

        public ForwardCommand(Player player)
        {
            _player = player;
        }
        
        public void Execute()
        {
            _player.MoveForward();
        }

        public void Undo()
        {
            _player.MoveBack();
        }
    }
}