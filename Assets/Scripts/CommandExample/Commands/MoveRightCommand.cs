using UnityEngine;

namespace Command
{
    public class MoveRightCommand : IMoveCommand
    {
        Player _player;

        public MoveRightCommand(Player player)
        {
            _player = player;
        }


        public void Execute()
        {
            _player.transform.position += Vector3.right;
        }

        public void Undo()
        {
            _player.transform.position -= Vector3.right;
        }
    }
}