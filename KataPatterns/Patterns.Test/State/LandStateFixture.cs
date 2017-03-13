using FluentAssertions;
using NUnit.Framework;
using Patterns.State;

namespace Patterns.Test.State
{
    public class LandStateFixture
    {
        private LandState _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new LandState();
        }

        [Test]
        public void Move_Returns_ExpectedResult()
        {
            // Act
            var result = _testee.Move();

            // Assert
            result.Should().Be("Run");
        }

        [Test]
        public void MakeNois_Returns_ExpectedResult()
        {
            // Act
            var result = _testee.MakeNoise();

            // Assert
            result.Should().Be("Wuaaaaa");
        }
    }
}