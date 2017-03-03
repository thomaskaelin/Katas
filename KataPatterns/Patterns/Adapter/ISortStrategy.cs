using System.Collections.Generic;

namespace Patterns.Adapter
{
    public interface ISortStrategy
    {
        void Sort(List<string> list);
    }
}