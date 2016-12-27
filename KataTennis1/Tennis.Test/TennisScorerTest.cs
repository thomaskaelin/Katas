using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tennis.Test
{
    [TestFixture]
    public class TennisScorerTest
    {
        private TennisScorer _testee;
        
        private void CallGetScoreAndCheckResult(string expectedResult)
        {
            var result = _testee.GetScore();
            result.Should().Be(expectedResult);
        }

        [SetUp]
        public void SetUp()
        {
            _testee = new TennisScorer();
        }

        [Test]
        public void GetScore_NoOneScored_0to0()
        {
            // Act
            var result = _testee.GetScore();

            // Assert
            result.Should().Be("0-0");
        }

        [Test]
        public void GetScore_A_15to0()
        {
            // Arrange
            _testee.PlayerAScores();

            // Act & Assert
            CallGetScoreAndCheckResult("15-0");
        }

        [Test]
        public void GetScore_B_0to15()
        {
            // Arrange
            _testee.PlayerBScores();

            // Act
            CallGetScoreAndCheckResult("0-15");
        }

        [Test]
        public void GetScore_ABA_30to15()
        {
            // Arrange
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();

            // Act & Assert
            CallGetScoreAndCheckResult("30-15");
        }


        [Test]
        public void GetScore_BAA_30to15()
        {
            // Arrange
            _testee.PlayerBScores();
            _testee.PlayerAScores();
            _testee.PlayerAScores();

            // Act & Assert
            CallGetScoreAndCheckResult("30-15");
        }

        [Test]
        public void GetScore_AAA_40to0()
        {
            // Arrange
            _testee.PlayerAScores();
            _testee.PlayerAScores();
            _testee.PlayerAScores();

            // Act & Assert
            CallGetScoreAndCheckResult("40-0");
        }

        [Test]
        public void GetScore_AAAA_GameA()
        {
            // Arrange
            _testee.PlayerAScores();
            _testee.PlayerAScores();
            _testee.PlayerAScores();
            _testee.PlayerAScores();

            // Act & Assert
            CallGetScoreAndCheckResult("GameA");
        }

        [Test]
        public void GetScore_BBBB_GameB()
        {
            // Arrange
            _testee.PlayerBScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();

            // Act & Assert
            CallGetScoreAndCheckResult("GameB");
        }

        [Test]
        public void GetScore_ABABAB_40to40()
        {
            // Arrange
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();

            // Act & Assert
            CallGetScoreAndCheckResult("40-40");
        }

        [Test]
        public void GetScore_AABBABA_AdvantageA()
        {
            // Arrange
            _testee.PlayerAScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();

            // Act & Assert
            CallGetScoreAndCheckResult("AdvantageA");
        }

        [Test]
        public void GetScore_AABBABB_AdvantageB()
        {
            // Arrange
            _testee.PlayerAScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();

            // Act & Assert
            CallGetScoreAndCheckResult("AdvantageB");
        }

        [Test]
        public void GetScore_AABBABAB_40t40()
        {
            // Arrange
            _testee.PlayerAScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();

            // Act & Assert
            CallGetScoreAndCheckResult("40-40");
        }

        [Test]
        public void GetScore_AABBABBA_40t40()
        {
            // Arrange
            _testee.PlayerAScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();
            _testee.PlayerAScores();

            // Act & Assert
            CallGetScoreAndCheckResult("40-40");
        }

        [Test]
        public void GetScore_AAAAA_ThrowsException()
        {
            // Arrange
            _testee.PlayerAScores();
            _testee.PlayerAScores();
            _testee.PlayerAScores();
            _testee.PlayerAScores();

            // Act & Assert
            Action act = () => { _testee.PlayerAScores(); };
            act.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void GetScore_BBBBB_ThrowsException()
        {
            // Arrange
            _testee.PlayerBScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();
            _testee.PlayerBScores();

            // Act & Assert
            Action act = () => { _testee.PlayerBScores(); };
            act.ShouldThrow<InvalidOperationException>();
        }
    }
}
