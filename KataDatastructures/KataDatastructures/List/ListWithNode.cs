using System;

namespace KataDatastructures.List
{
    public class ListWithNode<TItem> : IList<TItem>
    {
        public TItem this[int key]
        {
            get { return Get(key); }
            set { Set(key, value); }
        }

        public void Add(TItem item)
        {
            throw new NotImplementedException();
        }

        public TItem Get(int index)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }

        public void Set(int index, TItem item)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}
