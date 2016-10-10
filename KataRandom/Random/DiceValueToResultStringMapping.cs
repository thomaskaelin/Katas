using System.Collections.Generic;

namespace Random
{
    public class DiceValueToResultStringMapping
    {
        private readonly Dictionary<int, string> _mapping = new Dictionary<int, string>();

        public IEnumerable<int> DiceValues => _mapping.Keys;

        public virtual void AddMapping(int diceValue, string resultString)
        {
            _mapping.Add(diceValue, resultString);
        }

        public virtual bool HasMapping(int diceValue)
        {
            return _mapping.ContainsKey(diceValue);
        }

        public virtual string GetResultString(int diceValue)
        {
            return _mapping[diceValue];
        }
    }
}