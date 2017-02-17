using FluentAssertions;
using NUnit.Framework;
using Patterns.FactoryMethod;

namespace Patterns.Test.FactoryMethod
{
    [TestFixture]
    public class AscendingSortConsumerFixture
    {
        private AscendingSortConsumer _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new AscendingSortConsumer();
        }

        [Test]
        public void CreateSortStrategy_ReturnsExpectedSortStrategy()
        {
            // Act
            var result = _testee.CreateSortStrategy();

            // Assert
            result.Should().BeOfType<AscendingSortStrategy>();
        }
    }
}
