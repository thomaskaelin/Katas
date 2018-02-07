using FluentAssertions;
using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;
using NUnit.Framework;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class GameAcceptanceFixture
    {
        [Test]
        public void OnePlayer_WithFiveCombinations_WithFifthTosses()
        {
            var scoreBoard = new ScoreBoard();

            // Add Players
            var player1 = CreatePlayer("Kevin");
            scoreBoard.AddPlayer(player1);

            // Add Combinations
            var onesCombination = CreateOnesCombination();
            var threeOfAKindCombination = CreateThreeOfAKindCombination();
            var fullHouseCombination = CreateFullHouseCombination();
            var smallStraightCombination = CreateSmallStraightCombination();
            var chanceCombination = CreateChanceCombination();
            scoreBoard.AddCombination(onesCombination);
            scoreBoard.AddCombination(threeOfAKindCombination);
            scoreBoard.AddCombination(fullHouseCombination);
            scoreBoard.AddCombination(smallStraightCombination);
            scoreBoard.AddCombination(chanceCombination);

            // First Toss
            CreateAndAssignToss(scoreBoard, player1, CombinationType.Ones, new[] { 1, 1, 1, 6, 6 });
            CheckPointsForCombination(scoreBoard, player1, CombinationType.Ones, 3);
            CheckTotalPoints(scoreBoard, player1, 3);

            // Second Toss
            CreateAndAssignToss(scoreBoard, player1, CombinationType.ThreeOfAKind, new[] { 1, 1, 1, 4, 5 });
            CheckPointsForCombination(scoreBoard, player1, CombinationType.ThreeOfAKind, 12);
            CheckTotalPoints(scoreBoard, player1, 15);

            // Third Toss
            CreateAndAssignToss(scoreBoard, player1, CombinationType.FullHouse, new []{ 3, 3, 3, 4, 4 });
            CheckPointsForCombination(scoreBoard, player1, CombinationType.FullHouse, 25);
            CheckTotalPoints(scoreBoard, player1, 40);

            // Fourth Toss
            CreateAndAssignToss(scoreBoard, player1, CombinationType.SmallStraight, new[] { 1, 2, 3, 4, 4 });
            CheckPointsForCombination(scoreBoard, player1, CombinationType.SmallStraight, 30);
            CheckTotalPoints(scoreBoard, player1, 70);

            // Fifth Toss
            CreateAndAssignToss(scoreBoard, player1, CombinationType.Chance, new[] { 1, 2, 3, 4, 4 });
            CheckPointsForCombination(scoreBoard, player1, CombinationType.Chance, 14);
            CheckTotalPoints(scoreBoard, player1, 84);
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

        private static ICombination CreateThreeOfAKindCombination()
        {
            return new ThreeOfAKindCombination();
        }

        private static ICombination CreateFullHouseCombination()
        {
            return new FullHouseCombination();
        }

        private static ICombination CreateSmallStraightCombination()
        {
            return new SmallStraightCombination();
        }

        private static ICombination CreateChanceCombination()
        {
            return new ChanceCombination();
        }

        private static IToss CreateToss(params int[] diceValues)
        {
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