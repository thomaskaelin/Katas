using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.FactoryMethod;

namespace Patterns.Test.FactoryMethod
{
    [TestFixture]
    public class AscendingSortStrategyFixture
    {
        private AscendingSortStrategy _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new AscendingSortStrategy();
        }

        [Test]
        public void Sort_ReturnsExpectedResult()
        {
            // Arrange
            var list = new List<string> { "B", "A", "C" };

            // Act
            _testee.Sort(list);

            // Assert
            var expectedList = new List<string> {"A", "B", "C"};
            list.ShouldAllBeEquivalentTo(expectedList);
        }

    }
}