using System.Collections.Generic;

namespace Patterns.Command
{
    public class WikiCommandManager
    {
        private Stack<ICommand> _commands;
        private Stack<ICommand> _undoneCommands;

        public WikiCommandManager()
        {
            _commands = new Stack<ICommand>();
            _undoneCommands = new Stack<ICommand>();
        }

        public void Execute(ICommand command)
        {
            _undoneCommands.Clear();
            _commands.Push(command);
            command.Do();
        }

        public void Undo(uint steps)
        {
            for (int i = 1; i <= steps; i++)
            {
                var command = _commands.Pop();
                command.Undo();
                _undoneCommands.Push(command);
            }
        }

        public void Redo(uint steps)
        {
            for (int i = 1; i <= steps; i++)
            {
                var command = _undoneCommands.Pop();
                _commands.Push(command);
                command.Do();
            }
        }
    }
}