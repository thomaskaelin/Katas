using FluentAssertions;
using NUnit.Framework;
using Patterns.State;

namespace Patterns.Test.State
{
    [TestFixture]
    public class StateAcceptanceTest
    {
        [Test]
        public void AcceptanceTest()
        {
            // Arrange
            var animal = new Animal();

            // Act
            var waterAnimalResult = animal.PerformTrick();
            waterAnimalResult.Should().Be("SwimBluppBlupp");

            animal.GoRunning();
            var landAnimalResult = animal.PerformTrick();
            landAnimalResult.Should().Be("RunWuaaaaa");

            animal.GoFlying();
            var airAnimalResult = animal.PerformTrick();
            airAnimalResult.Should().Be("FlyFluup");
        }
    }
}