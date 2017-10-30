using FluentAssertions;
using NUnit.Framework;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class ScoreBoardFixture
    {
        private ScoreBoard _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new ScoreBoard();
        }

        [Test]
        public void Constructor_Initializes_Players()
        {
            // Assert
            _testee.Players.Should().NotBeNull();
            _testee.Players.Should().BeEmpty();
        }

        [Test]
        public void Constructor_Initializes_Combinations()
        {
            // Assert
            _testee.Combinations.Should().NotBeNull();
            _testee.Combinations.Should().BeEmpty();
        }
    }
}
