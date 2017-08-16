using System;
using KataDatastructures.Node;

namespace KataDatastructures.List
{
    public class ListWithNode<TItem> : IList<TItem>
    {
        public INode<TItem> CurrentNode;

        public TItem this[int key]
        {
            get { return Get(key); }
            set { Set(key, value); }
        }

        public void Add(TItem item)
        {
            var newNode = new Node<TItem>();
            newNode.Element = item;
            if (CurrentNode == null)
            {
                InitializeHeadAndTail(newNode);
            }
            else
            {
                ConnectNodes(newNode);
            }
        }

        private void InitializeHeadAndTail(Node<TItem> newNode)
        {
            CurrentNode = newNode;
            CurrentNode.Tail = newNode;
            CurrentNode.Head = newNode;
        }

        private void ConnectNodes(INode<TItem> newNode)
        {
            var currentTail = CurrentNode.Tail;
            CurrentNode.Tail = newNode;
            newNode.Previous = currentTail;
            currentTail.Next = newNode;
        }

        public TItem Get(int index)
        {
            var currentNode = GetNodeAtIndex(index);   
            return currentNode.Element;
        }

        private INode<TItem> GetNodeAtIndex(int index)
        {
            var counter = 0;
            var currentNode = CurrentNode.Head;
            while (counter <= index)
            {
                if (currentNode.HasNext() && index != counter)
                    currentNode = currentNode.Next;
                counter++;
            }
            return currentNode;
        }

        public void Remove(int index)
        {
            ThrowArgumentOurOfRangeExceptionIfIndexIsInvalid(index);
            var node = GetNodeAtIndex(index);
            node.Remove();
        }

        public void Set(int index, TItem item)
        {
            ThrowArgumentOurOfRangeExceptionIfIndexIsInvalid(index);
            var newNode = new Node<TItem>();
            newNode.Element = item;

            var node = GetNodeAtIndex(index);
            if (node == null)
            {
                CurrentNode.Tail = newNode;
                newNode.Previous = GetNodeAtIndex(index - 1);
            }
            else
            {
                node.Element = item;
            }
        }

        public int Size()
        {
            return CurrentNode?.Size() ?? 0;
        }

        private void ThrowArgumentOurOfRangeExceptionIfIndexIsInvalid(int index)
        {
            if (index >= Size())
                throw new ArgumentOutOfRangeException();
        }
    }
}
