using System.Collections.Generic;

namespace Patterns.Strategy
{
    public interface ISortStrategy
    {
        List<string> Sort(List<string> unsortedStrings);
    }
}