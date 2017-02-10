using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Strategy;

namespace Patterns.Test.Strategy
{
    [TestFixture]
    public class ConsumerFixture
    {
        private Consumer _testee;

        [Test]
        public void Consume_WithAscendingSortStrategy_ReturnsAscendingSortedList()
        {
            // Arrange
            var sortStrategy = new AscendingSortStrategy();
            _testee = new Consumer(sortStrategy);
          
            // Act
            var result = _testee.Consume();

            // Assert
            var expectedList = new List<string> {"A", "B", "C"};
            result.Should().Equal(expectedList);
        }

        [Test]
        public void Consume_WithDescendingSortStrategy_ReturnsDescendingSortedList()
        {
            // Arrange
            var sortStrategy = new DescendingSortStrategy();
            _testee = new Consumer(sortStrategy);

            // Act
            var result = _testee.Consume();

            // Assert
            var expectedList = new List<string> { "C", "B", "A" };
            result.Should().Equal(expectedList);
        }
    }
}