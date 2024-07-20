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
            _player.transform.position += Vector3.forward;
        }

        public void Undo()
        {
            _player.transform.position -= Vector3.forward;
        }
    }
}