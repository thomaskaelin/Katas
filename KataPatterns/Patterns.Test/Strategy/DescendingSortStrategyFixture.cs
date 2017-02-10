using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Strategy;

namespace Patterns.Test.Strategy
{
    [TestFixture]
    public class DescendingSortStrategyFixture
    {
        private DescendingSortStrategy _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new DescendingSortStrategy();
        }

        [Test]
        public void Sort_ReturnsDescendingList()
        {
            // Arrange
            var unsortedList = new List<string> { "A", "C", "B" };

            // Act
            _testee.Sort(unsortedList);
            var result = unsortedList;

            // Assert
            var sortedList = new List<string> { "C", "B", "A" };
            result.Should().Equal(sortedList);
        }



    }
}
