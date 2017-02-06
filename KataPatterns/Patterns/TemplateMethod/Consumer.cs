using System.Collections.Generic;

namespace Patterns.TemplateMethod
{
    public abstract class Consumer
    {
        public void Consume()
        {
            var unsortedList = new List<string> { "Hallo", "Tschau", "Hoi" };
            Sort(unsortedList);
        }

        protected abstract List<string> Sort(List<string> unsortedStrings);
    }
}