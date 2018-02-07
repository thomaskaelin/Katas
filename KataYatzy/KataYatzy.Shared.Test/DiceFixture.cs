using FluentAssertions;
using NUnit.Framework;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class DiceFixture
    {
        private Dice _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Dice(3);
        }

        [Test]
        public void Constructor_InitializesValue()
        {
            // Assert
            _testee.Value.Should().Be(3);
        }
    }
}
