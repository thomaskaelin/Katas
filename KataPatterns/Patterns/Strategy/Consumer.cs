using System.Collections.Generic;

namespace Patterns.Strategy
{
    public class Consumer
    {
        private readonly ISortStrategy _sortStrategy;

        public Consumer(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public List<string> Consume()
        {
            var list = new List<string> {"B", "A", "C"};
            _sortStrategy.Sort(list);

            return list;
        }
    }
}