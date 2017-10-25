using FakeItEasy;
using FluentAssertions;
using KataYatzy.Combinations;
using NUnit.Framework;

namespace KataYatzy.Test
{
    [TestFixture]

    public class GameAcceptanceFixture
    {
        [Test]
        public void OnePlayer_WithTwoCombinations_WithTwoTosses()
        {
            var scoreBoard = new ScoreBoard();
            var player1 = CreatePlayer();
            scoreBoard.AddPlayer(player1);

            var onesCombination = CreateOnesCombination();
            var tripletCombination = CreateTripletCombination();
            scoreBoard.AddCombination(onesCombination);
            scoreBoard.AddCombination(tripletCombination);

            var firstToss = CreateToss(1,1,1,6,6);
            scoreBoard.AssignToss(player1, firstToss, CombinationType.Ones);

            var pointsForFirstCombination = scoreBoard.GetPointsForCombination(player1, CombinationType.Ones);
            pointsForFirstCombination.Value.Should().Be(3);

            var totalPoints = scoreBoard.GetTotalPoints(player1);
            totalPoints.Value.Should().Be(3);

            var secondToss = CreateToss(1,1,1,4,5);
            scoreBoard.AssignToss(player1, secondToss, CombinationType.Triplet);

            var pointsForSecondCombination = scoreBoard.GetPointsForCombination(player1, CombinationType.Triplet);
            pointsForSecondCombination.Value.Should().Be(12);

            totalPoints = scoreBoard.GetTotalPoints(player1);
            totalPoints.Value.Should().Be(15);
        }

        private IPlayer CreatePlayer()
        {
            return new Player("Kevin");
        }

        private IToss CreateToss(params int[] diceValues)
        {
            // TODO Dices in Konstruktor übergeben?
            var toss = new Toss();

            foreach (var diceValue in diceValues)
            {
                toss.AddDice(new Dice(diceValue));
            }

            return toss;
        }

        private ICombination CreateOnesCombination()
        {
            return new OnesCombination();
        }

        private ICombination CreateTripletCombination()
        {
            return new TripletCombination();
        }
    }
}