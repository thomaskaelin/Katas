using System;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class RolledNumberToStringConverterTest
    {
        private RolledNumberToResultStringConverter _target;

        [SetUp]
        public void SetUp()
        {
            _target = new RolledNumberToResultStringConverter();
        }

        [TestCase(1, "Oh no! You got a 1. :-(")]
        [TestCase(2, "Try harder! You only got a 2.")]
        [TestCase(3, "You are below average! You got a 3.")]
        [TestCase(4, "You are above average! You got a 4.")]
        [TestCase(5, "Nice one! You got a 5.")]
        [TestCase(6, "Awesome roll! You got a 6. :-)")]
        public void Convert_WithValidInput_ReturnExpectedResult(int rolledNumber, string expectedResult)
        {
            // Act
            var result = _target.Convert(rolledNumber);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestCase(0)]
        [TestCase(8)]
        [TestCase(90)]
        [TestCase(83)]
        public void Convert_WithInValidInput_ThrowException(int rolledNumber)
        {
            // Arrange
            Action act = () => _target.Convert(rolledNumber);

            // Act & Assert
            act.ShouldThrow<InvalidNumberException>();
        }
    }
}