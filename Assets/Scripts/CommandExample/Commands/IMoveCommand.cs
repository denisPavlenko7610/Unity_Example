namespace Command
{
    public interface IMoveCommand
    {
        void Execute();
        void Undo();
    }
}