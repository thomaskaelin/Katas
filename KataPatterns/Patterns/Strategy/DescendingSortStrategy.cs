using System.Collections.Generic;

namespace Patterns.Strategy
{
    public class DescendingSortStrategy : ISortStrategy
    {
        public void Sort(List<string> list)
        {
            list.Sort();
            list.Reverse();
        }
    }
}