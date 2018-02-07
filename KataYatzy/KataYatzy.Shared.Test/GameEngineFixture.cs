using FakeItEasy;
using FluentAssertions;
using KataYatzy.Contracts;
using NUnit.Framework;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class GameEngineFixture
    {
        private GameEngine _testee;
        private IScoreBoard _fakeScoreBoard;
        private ITossFactory _fakeTossFactory;

        [SetUp]
        public void SetUp()
        {
            _fakeScoreBoard = A.Fake<IScoreBoard>();
            _fakeTossFactory = A.Fake<ITossFactory>();
            _testee = new GameEngine(_fakeScoreBoard, _fakeTossFactory);
        }

        [Test]
        public void Contructor_Initializes_ScoreBoard()
        {
            _testee.ScoreBoard.Should().NotBeNull();
        }
        
        [Test]
        public void Constructor_AddsCombination_OnScoreBoard()
        {
            // Assert
            //A.CallTo(() => fakeScoreboard.AddCombination())
        }
        
    }
}