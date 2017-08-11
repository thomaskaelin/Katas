namespace KataDatastructures
{
    public class Node<TItem> : INode<TItem>
    {
        public INode<TItem> Next { get; set; }

        public INode<TItem> Previous { get; set; }

        public TItem Element { get; set; }
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
    }
}