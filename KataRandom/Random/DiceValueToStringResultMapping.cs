using System.Collections.Generic;

namespace Random
{
    public class DiceValueToStringResultMapping
    {

        private readonly Dictionary<int, string> _mapping = new Dictionary<int, string>();

        public IEnumerable<int> Values => _mapping.Keys;

        public virtual void AddMapping(int diceValue, string stringResult)
        {
            _mapping.Add(diceValue, stringResult);
        }

        public virtual bool HasMapping(int rolledNumber)
        {
            return _mapping.ContainsKey(rolledNumber);
        }

        public virtual string GetStringResult(int rolledNumber)
        {
            return _mapping[rolledNumber];
        }
    }
}