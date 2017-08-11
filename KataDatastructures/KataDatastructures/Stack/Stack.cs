using System;
using System.Collections.Generic;

namespace KataDatastructures.Stack
{
    public class Stack <TItem>
    {
        private List<TItem> _stack;

        public Stack()
        {
            _stack = new List<TItem>();
        }

        public void Push(TItem item)
        {
            _stack.Add(item);
        }

        public TItem Pop()
        {
            if (_stack.Count == 0)
                throw new InvalidOperationException();
            var item = _stack[_stack.Count - 1];
            _stack.RemoveAt(_stack.Count - 1);
            return item;
        }

        public TItem Top()
        {
            return _stack[_stack.Count - 1];
        }
    }
}