using System;

namespace KataDatastructures
{
    public class List<TItem>
    {
        private TItem[] _items;

        public List()
        {
            _items = new TItem[0];
        }

        public TItem this[int key]
        {
            get { return Get(key); }
            set { Set(key, value); }
        }

        public void Add(TItem item)
        {
            var tempItems = new TItem[_items.Length + 1];

            for (int i = 0; i < _items.Length; i++)
            {
                tempItems[i] = _items[i];
            }
            tempItems[_items.Length] = item;
            _items = tempItems;
        }

        public void Set(int index, TItem item)
        {
            ThrowArgumentOurOfRangeExceptionIfIndexIsInvalid(index);
            _items[index] = item;
        }

        public TItem Get(int index)
        {
            return _items[index];
        }

        public int Size()
        {
            return _items.Length;
        }

        public void Remove(int index)
        {
            ThrowArgumentOurOfRangeExceptionIfIndexIsInvalid(index);

            var tempItems = new TItem[Size() - 1];
            for (int i = 0; i < index; i++)
            {
                tempItems[i] = _items[i];
            }
            for (int i = index+1; i < Size(); i++)
            {
                tempItems[i-1] = _items[i];
            }
            _items = tempItems;
        }

        private void ThrowArgumentOurOfRangeExceptionIfIndexIsInvalid(int index)
        {
            if (index >= Size())
                throw new ArgumentOutOfRangeException();
        }
    }
}