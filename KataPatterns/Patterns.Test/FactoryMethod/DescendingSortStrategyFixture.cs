using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.FactoryMethod;

namespace Patterns.Test.FactoryMethod
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
        public void Sort_ReturnsExpectedResult()
        {
            // Arrange
            var list = new List<string> { "B", "A", "C" };

            // Act
            _testee.Sort(list);

            // Assert
            var expectedList = new List<string> { "C", "B", "A" };
            list.ShouldAllBeEquivalentTo(expectedList);
        }

    }
}