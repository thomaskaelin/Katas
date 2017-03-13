using FluentAssertions;
using NUnit.Framework;
using Patterns.State;

namespace Patterns.Test.State
{
    [TestFixture]
    public class AirStatueFixture
    {
        private AirState _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new AirState();
        }

        [Test]
        public void Move_Returns_ExpectedResult()
        {
            // Act
            var result = _testee.Move();

            // Assert
            result.Should().Be("Fly");
        }

        [Test]
        public void MakeNois_Returns_ExpectedResult()
        {
            // Act
            var result = _testee.MakeNoise();

            // Assert
            result.Should().Be("Fluup");
        }

    }
}