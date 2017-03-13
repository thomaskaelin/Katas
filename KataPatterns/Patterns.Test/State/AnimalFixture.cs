using FluentAssertions;
using NUnit.Framework;
using Patterns.State;

namespace Patterns.Test.State
{
    [TestFixture]
    public class AnimalFixture
    {
        private Animal _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Animal();
        }

        [Test]
        public void PerformTrick_WithWaterState_ReturnsExpectedResult()
        {
            // Arrange
            _testee.GoSwimming();

            // Act
            var result = _testee.PerformTrick();

            // Assert
            result.Should().Be("SwimBluppBlupp");
        }

        [Test]
        public void PerformTrick_WithAirState_ReturnsExpectedResult()
        {
            // Arrange
            _testee.GoFlying();

            // Act
            var result = _testee.PerformTrick();

            // Assert
            result.Should().Be("FlyFluup");
        }

        [Test]
        public void PerformTrick_WithLandState_ReturnsExpectedResult()
        {
            // Arrange
            _testee.GoRunning();

            // Act
            var result = _testee.PerformTrick();

            // Assert
            result.Should().Be("RunWuaaaaa");
        }
    }
}