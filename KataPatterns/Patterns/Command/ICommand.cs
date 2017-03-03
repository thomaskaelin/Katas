namespace Patterns.Command
{
    public interface ICommand
    {
        void Do();

        void Undo();
    }
}