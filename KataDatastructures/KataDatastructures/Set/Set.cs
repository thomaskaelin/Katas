using System;
using System.Collections.Generic;

namespace KataDatastructures.Set
{
    public class Set <TItem>
    {
        private readonly Dictionary<TItem, object> _dictionary;

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

        public void Remove(TItem item)
        {
            if(Contains(item))
                _dictionary.Remove(item);
            else
            {
                throw new InvalidOperationException();
            }
        }

        public int Size()
        {
            return _dictionary.Count;
        }
    }
}