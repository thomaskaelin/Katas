using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace KataDatastructures.Node
{
    public class Node<TItem> : INode<TItem>
    {
        private INode<TItem> _head;
        private INode<TItem> _tail;

        public INode<TItem> Next { get; set; }

        public INode<TItem> Previous { get; set; }
        
        public TItem Element { get; set; }

        public INode<TItem> Head {
            get
            {
                _head = GetFirst();
                return _head;
            }
            set { _head = value; }
        }

        public INode<TItem> Tail {
            get
            {
                _tail = GetLast();
                return _tail;
            }
            set { _tail = value; }
        }

        public bool HasNext()
        {
            if (Next == null)
                return false;
            return true;
        }

        public bool HasPrevious()
        {
            if (Previous == null)
                return false;
            return true;
        }

        public INode<TItem> GetFirst()
        {
            var hasPrevious = HasPrevious();
            INode<TItem> node = this;
            INode<TItem> firstNode = this;
            while (hasPrevious)
            {
                if (node.HasPrevious())
                {
                    node = node.Previous;
                }
                else
                {
                    firstNode = node;
                    hasPrevious = false;
                }
            }
            return firstNode;
        }

        public INode<TItem> GetLast()
        {
            var hasNext = HasNext();
            INode<TItem> node = this;
            INode<TItem> lastNode = this;
            while (hasNext)
            {
                if (node.HasNext())
                {
                    node = node.Next;
                }
                else
                {
                    lastNode = node;
                    hasNext = false;
                }
            }
            return lastNode;
        }

        public void AddBefore(INode<TItem> newNode)
        {
            if (HasPrevious())
            {
                var previousElement = Previous;
                previousElement.Next = newNode;
                newNode.Previous = previousElement;
            }
            newNode.Next = this;
            Previous = newNode;            
        }

        public void AddAfter(INode<TItem> newNode)
        {
            if (HasNext())
            {
                var nextNode = Next;
                Next = newNode;
                nextNode.Next = nextNode;
            }
            newNode.Previous = this;
            Next = newNode;
        }

        public int Size()
        {
            const int currentNode = 1;
            var numberOfNext = GetNumberOfNextNodes();
            var numberOfPrevious = GetNumberOfPreviousNodes();
            return currentNode + numberOfPrevious + numberOfNext;
        }

        private int GetNumberOfNextNodes()
        {
            INode<TItem> nextNode = this;
            var size = 0;
            while (nextNode.HasNext())
            {
                nextNode = nextNode.Next;
                size++;
            }
            return size;
        }

        private int GetNumberOfPreviousNodes()
        {
            INode<TItem> previousNode = this;
            var size = 0;
            while (previousNode.HasPrevious())
            {
                previousNode = previousNode.Previous;
                size++;
            }
            return size;
        }

        public void Remove()
        {
            var previousNode = Previous;
            var nextNode = Next;

            RemovePreviousConnection();
            RemoveNextConenction();
            
            ConnectNodes(previousNode, nextNode);

            ResetRemovedNode();
        }

        private void ResetRemovedNode()
        {
            Next = null;
            Previous = null;
            Element = default(TItem);
        }

        private void RemovePreviousConnection()
        {
            if(HasPrevious())
                Previous = null;

        }

        private void RemoveNextConenction()
        {
            if (HasNext())
                Next = null;
        }

        private void ConnectNodes(INode<TItem> previousNode, INode<TItem> nextNode)
        {
            if (previousNode == null && nextNode != null)
            {
                Tail = nextNode;
                nextNode.Previous = null;
            }
            else if (nextNode == null && previousNode != null)
            {
                Head = previousNode;
                previousNode.Next = null;
            }
            else if(nextNode != null && previousNode!=null)
            {
                previousNode.Next = nextNode;
                nextNode.Previous = previousNode;
            }
        }
    }
}