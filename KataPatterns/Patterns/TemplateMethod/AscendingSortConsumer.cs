using System.Collections.Generic;

namespace Patterns.TemplateMethod
{
    public class AscendingSortConsumer : Consumer
    {
        protected override List<string> Sort(List<string> unsortedStrings)
        {
            throw new System.NotImplementedException();
        }
    }
}