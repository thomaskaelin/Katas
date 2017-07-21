namespace KataDatastructures
{
    public class List<TItem>
    {
        private TItem[] _items;

        public List()
        {
            _items = new TItem[0];
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

        public TItem Get(int index)
        {
            return _items[index];
        }

        public int Size()
        {
            return _items.Length;
        }
    }
}
