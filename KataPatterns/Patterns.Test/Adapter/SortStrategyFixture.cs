using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Adapter;

namespace Patterns.Test.Adapter
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
        public void Sort_Returns_ExpectedResult()
        {
            // Arrange
            var unsortedList = new List<string>{"B","C","A"};
            
            // Act
            _testee.Sort(unsortedList);

            // Assert
            var sortedList = new List<string> { "A", "B", "C" };
            unsortedList.Should().BeEquivalentTo(sortedList);
        }

    }
}