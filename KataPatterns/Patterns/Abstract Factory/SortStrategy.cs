using System.Collections.Generic;
using System.Collections.Specialized;

namespace Patterns.Abstract_Factory
{
    public class SortStrategy : ISortStrategy
    {
        public List<string> Sort(List<string> list)
        {
            var sortedList = new List<string>(list);
            sortedList.Sort();

            return sortedList;
        }
    }
}