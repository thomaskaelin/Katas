using System.Collections.Generic;

namespace Patterns.TemplateMethod
{
    public class DescendingSortConsumer : Consumer
    {
        protected override void Sort(List<string> list)
        {
            list.Sort();
            list.Reverse();
        }
    }
}