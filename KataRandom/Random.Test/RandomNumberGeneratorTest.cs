using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class RandomNumberGeneratorTest
    {
        private RandomNumberGenerator _target;

        [SetUp]
        public void SetUp()
        {
            _target = new RandomNumberGenerator();
        }

        [Test]
        public void GetRandomNumber_ReturnsValidNumber()
        {
            // Arrange
            var validNumbers = new List<int> { 0, 1, 2 };

            // Act
            var result = _target.GetRandomNumber(validNumbers.Count);

            // Assert
            validNumbers.Should().Contain(result);
        }
    }
}