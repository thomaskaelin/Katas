using System.Collections.Generic;
using Patterns.TemplateMethod;

namespace Patterns.Test.TemplateMethod
{
    public class DescendingSortConsumerFixture : ConsumerFixtureBase
    {
        protected override List<string> GetExpectedResultOfConsume()
        {
            return new List<string> { "C", "B", "A" };
        }

        protected override Consumer CreateTestee()
        {
            return new DescendingSortConsumer();
        }
    }
}