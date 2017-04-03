using System.Collections.Generic;

namespace Patterns.Adapter
{
    public class NewSortStrategy : INewSortStrategy
    {
        private ISortStrategy _sortStrategy;

        public NewSortStrategy() : this(new SortStrategy())
        {
        }

        public NewSortStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public List<string> Sort(List<string> list)
        {
            var sortedList = new List<string>(list);
            _sortStrategy.Sort(sortedList);

            return sortedList;
        }
    }
}