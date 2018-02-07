using FluentAssertions;
using NUnit.Framework;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class PlayerFixture
    {
        private Player _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Player("Loana");
        }

        [Test]
        public void Constructor_InitializesName()
        {
            // Assert
            _testee.Name.Should().Be("Loana");
        }
    }
}
