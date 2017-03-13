using System.Collections.Generic;
using System.Xml.Xsl;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Adapter;

namespace Patterns.Test.Adapter
{
    [TestFixture]
    public class NewSortStrategyFixture
    {
        private NewSortStrategy _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new NewSortStrategy();
        }
        
        [Test]
        public void Sort_ReturnsExpectedList()
        {
            // Arrange
            var unsortedList = new List<string> { "B", "C", "A" };

            // Act
            var result = _testee.Sort(unsortedList);

            // Assert
            var sortedList = new List<string> { "A", "B", "C" };
            result.Should().BeEquivalentTo(sortedList);
        }
    }
}