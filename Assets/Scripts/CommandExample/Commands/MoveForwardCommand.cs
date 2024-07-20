using UnityEngine;

namespace Command
{
    public class MoveForwardCommand : IMoveCommand
    {
        Player _player;

        public MoveForwardCommand(Player player)
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