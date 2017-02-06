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

        public void Consume()
        {
            var unsortedList = new List<string> {"Hallo", "Tschau", "Hoi"};
            _sortStrategy.Sort(unsortedList);
        }
    }
}