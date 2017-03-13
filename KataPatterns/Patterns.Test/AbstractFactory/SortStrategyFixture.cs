using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Abstract_Factory;

namespace Patterns.Test.AbstractFactory
{
    [TestFixture]
    public class SortStrategyFixture
    {
        private SortStrategy _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new SortStrategy();
        }

        [Test]
        public void Sort_ReturnsSortedList()
        {
            // Arrange
            var unsortedList = new List<string> { "C", "B", "A" };
            // Act
            var result = _testee.Sort(unsortedList);

            // Assert
            var sortedList = new List<string> { "A", "B", "C", };
            result.Should().BeEquivalentTo(sortedList);
        }

    }
}