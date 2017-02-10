using System.Collections.Generic;

namespace Patterns.Strategy
{
    public class AscendingSortStrategy : ISortStrategy
    {
        public void Sort(List<string> list)
        {
            list.Sort();
        }
    }
}