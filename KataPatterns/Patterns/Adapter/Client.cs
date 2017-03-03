using System.Collections.Generic;

namespace Patterns.Adapter
{
    public class Client
    {
        private readonly INewSortStrategy _sortStrategy;

        public Client(INewSortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public List<string> DoSomething()
        {
            var list = new List<string> { "B", "A", "C" };
            var sortedList = _sortStrategy.Sort(list);

            return sortedList;
        }
    }
}
