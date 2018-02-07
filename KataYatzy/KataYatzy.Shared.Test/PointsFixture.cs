using FluentAssertions;
using NUnit.Framework;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class PointsFixture
    {
        private Points _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Points(321);
        }

        [Test]
        public void Constructor_InitializesValue()
        {
            // Assert
            _testee.Value.Should().Be(321);
        }
    }
}
