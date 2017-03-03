using System.Collections.Generic;

namespace Patterns.Adapter
{
    public class SortStrategy : ISortStrategy
    {
        public void Sort(List<string> list)
        {
            list.Sort();
        }
    }
}