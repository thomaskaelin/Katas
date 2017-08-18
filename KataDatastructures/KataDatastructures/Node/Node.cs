namespace KataDatastructures.Node
{
    public class Node<TItem> : INode<TItem>
    {
        public Node()
        {
            Head = this;
            Tail = this;
        }
        
        public INode<TItem> Next { get; set; }

        public INode<TItem> Previous { get; set; }
        
        public TItem Element { get; set; }

        public INode<TItem> Head { get; set; }

        public INode<TItem> Tail { get; set; }

        public bool HasNext()
        {
            return Next != null;
        }

        public bool HasPrevious()
        {
            return Previous != null;
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
                newNode.Head = this;
            }
            else if (!HasPrevious())
                newNode.Head = this;
            newNode.Tail = Tail;
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
                newNode.Tail = nextNode.Tail;
            }
            else if (!HasNext())
                newNode.Tail = this;
            newNode.Head = Head;
            newNode.Previous = this;
            Next = newNode;
        }

        public int Size()
        {
            var size = 1;
            if (Head != null)
            {
                var current = Head;
                while (current.HasNext())
                {
                    current = current.Next;
                    size++;
                }
            }
            return size;
        }

        public void Remove()
        {
            var previous = Previous;
            var next = Next;
            RemoveNode();
            ConnectNodes(previous, next);
        }

        private void RemoveNode()
        {
            Next = null;
            Previous = null;
        }

        private void ConnectNodes(INode<TItem> previous, INode<TItem> next)
        {
            if (IsFirstItem(previous, next))
            {
                Head = next;
                next.Previous = null;
            }
            else if (IsLastItem(previous, next))
            {
                Tail = previous;
                previous.Next = null;
            }
            else if(IsMiddleItem(previous, next))
            {
                previous.Next = next;
                next.Previous = previous;
            }
        }
        private static bool IsFirstItem(INode<TItem> previous, INode<TItem> next)
        {
            return previous == null;
        }

        private static bool IsLastItem(INode<TItem> previous, INode<TItem> next)
        {
            return next == null;
        }

        private static bool IsMiddleItem(INode<TItem> previous, INode<TItem> next)
        {
            return previous != null && next != null;
        }
    }
}