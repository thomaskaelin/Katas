using System.Collections.Generic;

namespace Random
{
    public class Dice
    {
        public virtual IEnumerable<int> Values { get; private set; }

        public Dice(IEnumerable<int> values)
        {
            Values = values;
        }
    }
}