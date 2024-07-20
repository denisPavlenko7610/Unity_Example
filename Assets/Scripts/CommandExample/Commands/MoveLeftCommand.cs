using UnityEngine;

namespace Command
{
    public class MoveLeftCommand : IMoveCommand
    {
        Player _player;

        public MoveLeftCommand(Player player)
        {
            _player = player;
        }

        
        public void Execute()
        {
            _player.transform.position += Vector3.left;
        }

        public void Undo()
        {
            _player.transform.position -= Vector3.left;
        }
    }
}