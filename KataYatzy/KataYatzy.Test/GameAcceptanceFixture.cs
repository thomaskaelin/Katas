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

            // Add Players
            var player1 = CreatePlayer("Kevin");
            scoreBoard.AddPlayer(player1);

            // Add Combinations
            var onesCombination = CreateOnesCombination();
            var tripletCombination = CreateTripletCombination();
            scoreBoard.AddCombination(onesCombination);
            scoreBoard.AddCombination(tripletCombination);

            // First Toss
            CreateAndAssignToss(scoreBoard, player1, CombinationType.Ones, new[] { 1, 1, 1, 6, 6 });
            CheckPointsForCombination(scoreBoard, player1, CombinationType.Ones, 3);
            CheckTotalPoints(scoreBoard, player1, 3);

            // Second Toss
            CreateAndAssignToss(scoreBoard, player1, CombinationType.Triplet, new[] { 1, 1, 1, 4, 5 });
            CheckPointsForCombination(scoreBoard, player1, CombinationType.Triplet, 12);
            CheckTotalPoints(scoreBoard, player1, 15);
        }

        #region Private Methods

        private static IPlayer CreatePlayer(string name)
        {
            return new Player(name);
        }

        private static ICombination CreateOnesCombination()
        {
            return new OnesCombination();
        }

        private static ICombination CreateTripletCombination()
        {
            return new TripletCombination();
        }

        private static IToss CreateToss(params int[] diceValues)
        {
            // TODO Dices in Konstruktor übergeben?
            var toss = new Toss();

            foreach (var diceValue in diceValues)
            {
                toss.AddDice(new Dice(diceValue));
            }

            return toss;
        }

        private static void CreateAndAssignToss(
            IScoreBoard scoreBoard,
            IPlayer player,
            CombinationType combinationType,
            int[] diceValues)
        {
            var toss = CreateToss(diceValues);
            scoreBoard.AssignToss(player, toss, combinationType);
        }

        private static void CheckPointsForCombination(
            IScoreBoard scoreBoard,
            IPlayer player,
            CombinationType combinationType,
            int expectedPoints)
        {
            var pointsForCombination = scoreBoard.GetPointsForCombination(player, combinationType);
            pointsForCombination.Value.Should().Be(expectedPoints);
        }

        private static void CheckTotalPoints(
            IScoreBoard scoreBoard,
            IPlayer player,
            int expectedTotalPoints)
        {
            var totalPoints = scoreBoard.GetTotalPoints(player);
            totalPoints.Value.Should().Be(expectedTotalPoints);
        }

        #endregion
    }
}