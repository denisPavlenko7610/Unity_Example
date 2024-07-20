using UnityEngine;

namespace Command
{
    public class BackCommand : ICommand
    {
        Player _player;

        public BackCommand(Player player)
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