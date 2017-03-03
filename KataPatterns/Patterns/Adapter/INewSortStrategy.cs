using System.Collections.Generic;

namespace Patterns.Adapter
{
    public interface INewSortStrategy
    {
        List<string> Sort(List<string> list);
    }
}