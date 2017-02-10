using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Strategy;

namespace Patterns.Test.Strategy
{
    [TestFixture]
    public class AscendingSortStrategyFixture
    {
        private AscendingSortStrategy _testee;

        [SetUp]
        public void Setup()
        {
            _testee = new AscendingSortStrategy();
        }

        [Test]
        public void Sort_ReturnsAscendingList()
        {
            // Arrange
            var unsortedList = new List<string> { "A", "C", "B"};

            // Act
            _testee.Sort(unsortedList);
            var result = unsortedList;

            // Assert
            var sortedList = new List<string> {"A", "B", "C"};
            result.Should().Equal(sortedList);
        }

    }
}