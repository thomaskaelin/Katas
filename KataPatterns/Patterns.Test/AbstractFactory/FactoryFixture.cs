using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Abstract_Factory;

namespace Patterns.Test.AbstractFactory
{
    [TestFixture]
    public class FactoryFixture
    {
        private Factory _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Factory();
        }

        [Test]
        public void CreateSortStrategy_ReturnsExpectedStrategy()
        {
            // Act
            var result =_testee.CreateSortStrategy();

            // Assert
            result.Should().BeOfType<SortStrategy>();
        }

        [Test]
        public void CreateModifyStrategy_ReturnsExpectedStrategy()
        {
            // Act
            var result = _testee.CreateModifierStrategy();

            // Assert
            result.Should().BeOfType<ModifierStrategy>();
        }

    }
}