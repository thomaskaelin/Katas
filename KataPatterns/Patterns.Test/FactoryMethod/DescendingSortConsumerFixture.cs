using FluentAssertions;
using NUnit.Framework;
using Patterns.FactoryMethod;

namespace Patterns.Test.FactoryMethod
{
    [TestFixture]
    public class DescendingSortConsumerFixture
    {
        private DescendingSortConsumer _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new DescendingSortConsumer();
        }

        [Test]
        public void CreateSortStrategy_ReturnsExpectedSortStrategy()
        {
            // Act
            var result = _testee.CreateSortStrategy();

            // Assert
            result.Should().BeOfType<DescendingSortStrategy>();
        }
    }
}
