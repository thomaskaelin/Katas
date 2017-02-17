using System;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Decorator;

namespace Patterns.Test.Decorator
{
    [TestFixture]
    public class CalculatorFixture
    {
        private Calculator _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Calculator();
        }

        [Test]
        public void DivideWithValidValues_ReturnsCorrectResult()
        {
            // Arrange

            // Act
            var result = _testee.Divide(100, 10);

            // Assert
            result.Should().Be(10);
        }

        [Test]
        public void DivideByZero_ThrowsException()
        {
            //Arrange
            Action action = () => _testee.Divide(1, 0);

            // Act & Assert
            action.ShouldThrow<DivideByZeroException>();
        }
    }
}
