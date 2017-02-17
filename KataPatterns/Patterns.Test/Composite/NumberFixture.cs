using FluentAssertions;
using NUnit.Framework;
using Patterns.Composite;

namespace Patterns.Test.Composite
{
    [TestFixture]
    public class NumberFixture
    {
        private Number _testee;

        [TestCase(0,0)]
        [TestCase(10,10)]
        [TestCase(100,100)]
        public void Calculate_ReturnsCorrectNumber(int number, int expectedNumber)
        {
            // Arrange
            _testee = new Number(number);

            // Act
            var result = _testee.Calculate();

            // Assert
            result.Should().Be(expectedNumber);
        }
    }
}
