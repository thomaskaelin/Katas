using System.Collections.Generic;

namespace Patterns.Strategy
{
    public interface ISortStrategy
    {
        void Sort(List<string> list);
    }
}