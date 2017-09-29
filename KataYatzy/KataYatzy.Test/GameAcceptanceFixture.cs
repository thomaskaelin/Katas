using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace KataYatzy.Test
{
    [TestFixture]

    public class GameAcceptanceFixture
    {
        [Test]
        public void FirstTest()
        {
            var scoreBoard = new ScoreBoard();
            var fakePlayer = CreatePlayer();
            var fakeCombination = CreateCombination();

            scoreBoard.AddPlayer(fakePlayer);
            scoreBoard.AddCombination(fakeCombination);

            var fakeToss = CreateToss();

            scoreBoard.AssignToss(fakePlayer, fakeToss, CombinationType.Ones);

            var pointsForCombination = scoreBoard.GetPointsForCombination(fakePlayer, CombinationType.Ones);
            pointsForCombination.Value.Should().Be(3);

            var totalPoints = scoreBoard.GetTotalPoints(fakePlayer);
            totalPoints.Value.Should().Be(3);
        }

        private IPlayer CreatePlayer()
        {
            return A.Fake<IPlayer>();
        }

        private IToss CreateToss()
        {
            return A.Fake<IToss>();
        }

        private ICombination CreateCombination()
        {
            var combination = A.Fake<ICombination>();
            var points = CreatePoints(3);
            A.CallTo(() => combination.Calculate(A<IToss>.Ignored)).Returns(points);
            return combination;
        }

        private IPoints CreatePoints(int value)
        {
            var points = A.Fake<IPoints>();
            A.CallTo(() => points.Value).Returns(value);
            return points;
        }
    }
}