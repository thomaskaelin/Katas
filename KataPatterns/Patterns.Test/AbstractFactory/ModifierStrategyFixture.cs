using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Abstract_Factory;

namespace Patterns.Test.AbstractFactory
{
    [TestFixture]
    public class ModifierStrategyFixture
    {
        private ModifierStrategy _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new ModifierStrategy();
        }

        [Test]
        public void Modify_ReturnsModifiedList()
        {
            // Arrange
            var unmodifiedList = new List<string>{"A", "B", "C"};
            // Act
            var result = _testee.Modify(unmodifiedList);

            // Assert
            var modifiedList = new List<string> { "A", "A", "B", "B", "C", "C"};
            result.Should().BeEquivalentTo(modifiedList);
        }
    }
}