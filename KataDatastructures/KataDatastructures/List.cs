namespace KataDatastructures
{
    public class List<TItem>
    {
        private TItem[] _items;

        public List()
        {
            _items = new TItem[1];
        }

        public void Add(TItem item)
        {
            _items[0] = item;
        }

        public TItem Get(int index)
        {
            return _items[0];
        }
    }
}
