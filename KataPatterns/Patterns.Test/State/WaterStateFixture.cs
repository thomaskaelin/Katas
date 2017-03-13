using FluentAssertions;
using NUnit.Framework;
using Patterns.State;

namespace Patterns.Test.State
{
    public class WaterStateFixture
    {
        private WaterState _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new WaterState();
        }

        [Test]
        public void Move_Returns_ExpectedResult()
        {
            // Act
            var result = _testee.Move();

            // Assert
            result.Should().Be("Swim");
        }

        [Test]
        public void MakeNois_Returns_ExpectedResult()
        {
            // Act
            var result = _testee.MakeNoise();

            // Assert
            result.Should().Be("BluppBlupp");
        }
    }
}