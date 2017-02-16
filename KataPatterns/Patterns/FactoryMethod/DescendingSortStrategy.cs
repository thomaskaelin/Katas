using System.Collections.Generic;

namespace Patterns.FactoryMethod
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