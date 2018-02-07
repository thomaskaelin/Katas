using System;
using FluentAssertions;
using KataYatzy.Contracts;
using KataYatzy.Shared.Test.Helper;
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
            _testee.Players.Should().NotBeNull().And.BeEmpty();
        }

        [Test]
        public void Constructor_Initializes_Combinations()
        {
            // Assert
            _testee.Combinations.Should().NotBeNull().And.BeEmpty();
        }

        [Test]
        public void AddPlayer_AddsParameterToPlayers()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();

            // Act
            _testee.AddPlayer(fakePlayer);

            // Assert
            _testee.Players.Count.Should().Be(1);
            _testee.Players.Should().Contain(fakePlayer);
        }

        [Test]
        public void AddPlayer_WithNullPlayer_ThrowsArgumentNullException()
        {
            // Arrange
            Action action = () => _testee.AddPlayer(null);

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddPlayer_WithAlreadyAddedPlayer_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            Action action = () => _testee.AddPlayer(fakePlayer);
            action();

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Player has already been added.");
        }

        [Test]
        public void AddCombination_AddsParameterToPlayers()
        {
            // Arrange
            var fakeCombination = FakeCreator.CreateFakeCombination();

            // Act
            _testee.AddCombination(fakeCombination);

            // Assert
            _testee.Combinations.Count.Should().Be(1);
            _testee.Combinations.Should().Contain(fakeCombination);
        }

        [Test]
        public void AddCombination_WithNullCombination_ThrowsArgumentNullException()
        {
            // Arrange
            Action action = () => _testee.AddCombination(null);

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddCombination_WithAlreadyAddedCombination_ThrowsArgumentException()
        {
            // Arrange
            var fakeCombination = FakeCreator.CreateFakeCombination();
            Action action = () => _testee.AddCombination(fakeCombination);
            action();

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Combination has already been added.");
        }

        [Test]
        public void AssignToss_AddsNewMapping()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            var fakeToss = FakeCreator.CreateFakeToss();
            var fakeCombination = FakeCreator.CreateFakeCombination();

            _testee.AddPlayer(fakePlayer);
            _testee.AddCombination(fakeCombination);

            // Act
            _testee.AssignToss(fakePlayer, fakeToss, fakeCombination.Type);

            // Assert
            _testee.HasPointsForCombination(fakePlayer, fakeCombination.Type).Should().BeTrue();
        }

        [Test]
        public void AssignToss_WithNullPlayer_ThrowsArgumentNullException()
        {
            // Arrange
            var fakeToss = FakeCreator.CreateFakeToss();

            Action action = () => _testee.AssignToss(null, fakeToss, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AssignToss_WithUnknownPlayer_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            var fakeToss = FakeCreator.CreateFakeToss();

            Action action = () => _testee.AssignToss(fakePlayer, fakeToss, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Player has not been added.");
        }

        [Test]
        public void AssignToss_WithNullToss_ThrowsArgumentNullException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            _testee.AddPlayer(fakePlayer);

            Action action = () => _testee.AssignToss(fakePlayer, null, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AssignToss_WithUnknownCombinationType_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            var fakeToss = FakeCreator.CreateFakeToss();

            _testee.AddPlayer(fakePlayer);

            Action action = () => _testee.AssignToss(fakePlayer, fakeToss, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("CombinationType has not been added.");
        }

        [Test]
        public void AssignToss_WithAlreadyUsedPlayerAndCombinationType_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            var fakeToss = FakeCreator.CreateFakeToss();
            var fakeCombination = FakeCreator.CreateFakeCombination();

            _testee.AddPlayer(fakePlayer);
            _testee.AddCombination(fakeCombination);

            Action action = () => _testee.AssignToss(fakePlayer, fakeToss, fakeCombination.Type);
            action();

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Already assigned a toss for this Player and CombinationType.");
        }

        [Test]
        public void GetPointsForCombination_ReturnsPointsFromAssignToss()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            var fakeCombination = FakeCreator.CreateFakeCombination(CombinationType.Ones, 25);
            var fakeToss = FakeCreator.CreateFakeToss();

            _testee.AddPlayer(fakePlayer);
            _testee.AddCombination(fakeCombination);
            _testee.AssignToss(fakePlayer, fakeToss, fakeCombination.Type);

            // Act
            var result = _testee.GetPointsForCombination(fakePlayer, fakeCombination.Type);

            // Assert
            result.Value.Should().Be(25);
        }

        [Test]
        public void GetPointsForCombination_WithNullPlayer_ThrowsArgumentNullException()
        {
            // Arrange
            Action action = () => _testee.GetPointsForCombination(null, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetPointsForCombination_WithUnknownPlayer_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();

            Action action = () => _testee.GetPointsForCombination(fakePlayer, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Player has not been added.");
        }

        [Test]
        public void GetPointsForCombination_WithUnknownCombinationType_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            _testee.AddPlayer(fakePlayer);

            Action action = () => _testee.GetPointsForCombination(fakePlayer, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("CombinationType has not been added.");
        }

        [Test]
        public void GetPointsForCombination_WithoutAssignedToss_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            var fakeCombination = FakeCreator.CreateFakeCombination();

            _testee.AddPlayer(fakePlayer);
            _testee.AddCombination(fakeCombination);

            Action action = () => _testee.GetPointsForCombination(fakePlayer, fakeCombination.Type);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("No toss assigned for this Player and CombinationType.");
        }

        [TestCase(false, false)]
        [TestCase(true, true)]
        public void HasPointsForCombination_ReturnsCorrectResult(bool callAssignToss, bool expectedResult)
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            var fakeCombination = FakeCreator.CreateFakeCombination();
            var fakeToss = FakeCreator.CreateFakeToss();

            _testee.AddPlayer(fakePlayer);
            _testee.AddCombination(fakeCombination);

            if (callAssignToss)
            {
                _testee.AssignToss(fakePlayer, fakeToss, fakeCombination.Type);
            }

            // Act
            var result = _testee.HasPointsForCombination(fakePlayer, fakeCombination.Type);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void HasPointsForCombination_WithNullPlayer_ThrowsArgumentNullException()
        {
            // Arrange
            Action action = () => _testee.HasPointsForCombination(null, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void HasPointsForCombination_WithUnknownPlayer_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();

            Action action = () => _testee.HasPointsForCombination(fakePlayer, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Player has not been added.");
        }

        [Test]
        public void HasPointsForCombination_WithUnknownCombinationType_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            _testee.AddPlayer(fakePlayer);

            Action action = () => _testee.HasPointsForCombination(fakePlayer, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("CombinationType has not been added.");
        }

        [Test]
        public void GetTotalPoints_ReturnsCorrectResult()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            var fakeCombination1 = FakeCreator.CreateFakeCombination(CombinationType.FullHouse, 10);
            var fakeCombination2 = FakeCreator.CreateFakeCombination(CombinationType.Chance, 20);
            var fakeToss = FakeCreator.CreateFakeToss();

            _testee.AddPlayer(fakePlayer);
            _testee.AddCombination(fakeCombination1);
            _testee.AddCombination(fakeCombination2);
            _testee.AssignToss(fakePlayer, fakeToss, fakeCombination1.Type);
            _testee.AssignToss(fakePlayer, fakeToss, fakeCombination2.Type);

            // Act
            var result = _testee.GetTotalPoints(fakePlayer);

            // Assert
            result.Value.Should().Be(30);
        }

        [Test]
        public void GetTotalPoints_WithNullPlayer_ThrowsArgumentNullException()
        {
            // Arrange
            Action action = () => _testee.GetTotalPoints(null);

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetTotalPoints_WithUnknownPlayer_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();

            Action action = () => _testee.GetTotalPoints(fakePlayer);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Player has not been added.");
        }

        [Test]
        public void ClearPoints_RemovesAllAssignments()
        {
            // Arrange
            var fakePlayer = FakeCreator.CreateFakePlayer();
            var fakeCombination = FakeCreator.CreateFakeCombination();
            var fakeToss = FakeCreator.CreateFakeToss();

            _testee.AddPlayer(fakePlayer);
            _testee.AddCombination(fakeCombination);
            _testee.AssignToss(fakePlayer, fakeToss, fakeCombination.Type);

            // Act
            _testee.ClearPoints();

            // Assert
            var result = _testee.HasPointsForCombination(fakePlayer, fakeCombination.Type);

            result.Should().BeFalse();
        }
    }
}
