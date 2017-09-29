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
            return new Player("Kevin");
        }

        private IToss CreateToss()
        {
            var toss = new Toss();
            toss.AddDice(new Dice(1));
            toss.AddDice(new Dice(1));
            toss.AddDice(new Dice(1));
            toss.AddDice(new Dice(6));
            toss.AddDice(new Dice(6));

            return toss;
        }

        private ICombination CreateCombination()
        {
            return new OnesCombination();
        }

        private IPoints CreatePoints(int value)
        {
            return new Points(value);
        }
    }
}