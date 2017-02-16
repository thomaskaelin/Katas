using System.Collections.Generic;

namespace Patterns.FactoryMethod
{
    public interface ISortStrategy
    {
        void Sort(List<string> list);
    }
}