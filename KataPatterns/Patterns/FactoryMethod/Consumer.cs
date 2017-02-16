using System.Collections.Generic;

namespace Patterns.FactoryMethod
{
    public abstract class Consumer
    {
        public List<string> Consume()
        {
            var list = new List<string> {"B", "A", "C"};
            var sortStrategy = CreateSortStrategy();
            sortStrategy.Sort(list);

            return list;
        }

        public abstract ISortStrategy CreateSortStrategy();
    }
}