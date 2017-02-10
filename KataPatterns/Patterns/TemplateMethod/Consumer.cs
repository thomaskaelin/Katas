using System.Collections.Generic;

namespace Patterns.TemplateMethod
{
    public abstract class Consumer
    {
        public List<string> Consume()
        {
            var list = new List<string> { "A", "C", "B" };
            Sort(list);
            return list;
        }

        protected abstract void Sort(List<string> list);
    }
}