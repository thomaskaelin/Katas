using System.Collections.Generic;

namespace KataDatastructures.Queue
{
    public class Queue <TItem>
    {
        private List<TItem> _queue;

        public Queue()
        {
            _queue = new List<TItem>();
        }
        
        public void Enqueue(TItem item)
        {
            _queue.Add(item);
        }

        public TItem Dequeue()
        {
            var item = _queue[0];
            _queue.RemoveAt(0);
            return item;
        }
    }
}