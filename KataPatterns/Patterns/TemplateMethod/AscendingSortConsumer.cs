using System.Collections.Generic;

namespace Patterns.TemplateMethod
{
    public class AscendingSortConsumer : Consumer
    {
        protected override void Sort(List<string> list)
        {
            list.Sort();
        }
    }
}