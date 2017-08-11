using System.Collections.Generic;

namespace KataDatastructures.Set
{
    public class Set <TItem>
    {
        private Dictionary<TItem, object> _dictionary;

        public Set()
        {
            _dictionary = new Dictionary<TItem, object>();
        }

        public bool Add(TItem item)
        {
            if (!Contains(item))
            {
                _dictionary.Add(item, null);
                return true;
            }
            return false;
        }

        public bool Contains(TItem item)
        {
            return _dictionary.ContainsKey(item);
        }
    }
}