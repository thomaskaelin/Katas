using System;
using System.Collections.Generic;
using System.Linq;

namespace KataDatastructures.Dictionary
{
    public class Dictionary <TKey, TValue>
    {

        private List<KeyValuePair<TKey, TValue>> _list;

        public Dictionary()
        {
            _list = new List<KeyValuePair<TKey, TValue>>();
        }

        public TValue Get(TKey key)
        {
            var foundKvp = GetKeyValuePair(key);
            if (foundKvp == null)
                return default(TValue);
            return foundKvp.Value;
        }

        private KeyValuePair<TKey, TValue> GetKeyValuePair(TKey key)
        {
            return _list.FirstOrDefault(kvp => kvp.Key.Equals(key));
        }

        public void Put(TKey key, TValue value)
        {
            if (Get(key) == null)
            {
                var keyValuePair = new KeyValuePair<TKey, TValue>
                {
                    Key = key,
                    Value = value
                };
                _list.Add(keyValuePair);
            }
            else
            {
                var kvp = GetKeyValuePair(key);
                kvp.Value = value;
            }
        }

        public int Size()
        {
            return _list.Count;
        }

        public void Remove(TKey key)
        {
            var kvp = GetKeyValuePair(key);
            if(kvp == null)
                throw new InvalidOperationException();
            _list.Remove(kvp);
        }

        public List<KeyValuePair<TKey, TValue>> Entries()
        {
            return _list;
        }
    }
}