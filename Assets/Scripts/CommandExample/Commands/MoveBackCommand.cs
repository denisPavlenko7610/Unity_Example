using UnityEngine;

namespace Command
{
    public class MoveBackCommand : IMoveCommand
    {
        Player _player;

        public MoveBackCommand(Player player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.MoveBack();
        }

        public void Undo()
        {
            _player.MoveForward();
        }
    }
}