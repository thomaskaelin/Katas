using System.Collections.Generic;

namespace Patterns.Abstract_Factory
{
    public interface ISortStrategy
    {
        List<string> Sort(List<string> list);
    }
}