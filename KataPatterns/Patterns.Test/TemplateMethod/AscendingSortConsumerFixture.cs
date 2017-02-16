using System.Collections.Generic;
using Patterns.TemplateMethod;

namespace Patterns.Test.TemplateMethod
{
    public class AscendingSortConsumerFixture : ConsumerFixtureBase
    {
        protected override List<string> GetExpectedResultOfConsume()
        {
            return new List<string> {"A", "B", "C"};
        }

        protected override Consumer CreateTestee()
        {
            return new AscendingSortConsumer();
        }
    }
}
