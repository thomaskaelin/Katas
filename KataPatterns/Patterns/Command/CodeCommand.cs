﻿namespace Patterns.Command
{
    public class CodeCommand : ICommand
    {
        private readonly WikiText _content;

        public CodeCommand(WikiText content)
        {
            _content = content;
        }

        public void Do()
        {
            _content.Content = $"{{{_content.Content}}}";
        }

        public void Undo()
        {
            _content.Content = _content.Content.Substring(1, _content.Content.Length - 2);
        }
    }
}