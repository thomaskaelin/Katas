using System;
using FakeItEasy;
using FluentAssertions;
using KataYatzy.Contracts;
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

        [Test]
        public void AddPlayer_AddsParameterToPlayers()
        {
            // Arrange
            var fakePlayer = CreateFakePlayer();

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
            var fakePlayer = CreateFakePlayer();
            Action action = () => _testee.AddPlayer(fakePlayer);
            action();

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Player has already been added.");
        }

        [Test]
        public void AddCombination_AddsParameterToPlayers()
        {
            // Arrange
            var fakeCombination = CreateFakeCombination();

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
            var fakeCombination = CreateFakeCombination();
            Action action = () => _testee.AddCombination(fakeCombination);
            action();

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Combination has already been added.");
        }

        [Test]
        public void AssignToss_AddsNewMapping()
        {
            // Arrange
            var fakePlayer = CreateFakePlayer();
            var fakeToss = CreateFakeToss();
            var fakeCombination = CreateFakeCombination();

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
            var fakeToss = CreateFakeToss();

            Action action = () => _testee.AssignToss(null, fakeToss, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AssignToss_WithUnknownPlayer_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = CreateFakePlayer();
            var fakeToss = CreateFakeToss();

            Action action = () => _testee.AssignToss(fakePlayer, fakeToss, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Player has not been added.");
        }

        [Test]
        public void AssignToss_WithNullToss_ThrowsArgumentNullException()
        {
            // Arrange
            var fakePlayer = CreateFakePlayer();
            _testee.AddPlayer(fakePlayer);

            Action action = () => _testee.AssignToss(fakePlayer, null, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AssignToss_WithUnknownCombinationType_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = CreateFakePlayer();
            var fakeToss = CreateFakeToss();

            _testee.AddPlayer(fakePlayer);

            Action action = () => _testee.AssignToss(fakePlayer, fakeToss, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("CombinationType has not been added.");
        }

        [Test]
        public void AssignToss_WithAlreadyUsedPlayerAndCombinationType_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = CreateFakePlayer();
            var fakeToss = CreateFakeToss();
            var fakeCombination = CreateFakeCombination();

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
            var fakePlayer = CreateFakePlayer();
            var fakeCombination = CreateFakeCombination();
            var fakeToss = CreateFakeToss();
            var fakePoints = CreateFakePoints();

            A.CallTo(() => fakeCombination.Calculate(fakeToss)).Returns(fakePoints);

            _testee.AddPlayer(fakePlayer);
            _testee.AddCombination(fakeCombination);
            _testee.AssignToss(fakePlayer, fakeToss, fakeCombination.Type);

            // Act
            var result = _testee.GetPointsForCombination(fakePlayer, fakeCombination.Type);

            // Assert
            result.Should().BeSameAs(fakePoints);
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
            var fakePlayer = CreateFakePlayer();

            Action action = () => _testee.GetPointsForCombination(fakePlayer, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("Player has not been added.");
        }

        [Test]
        public void GetPointsForCombination_WithUnknownCombinationType_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = CreateFakePlayer();
            _testee.AddPlayer(fakePlayer);

            Action action = () => _testee.GetPointsForCombination(fakePlayer, CombinationType.Ones);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("CombinationType has not been added.");
        }

        [Test]
        public void GetPointsForCombination_WithoutAssignedToss_ThrowsArgumentException()
        {
            // Arrange
            var fakePlayer = CreateFakePlayer();
            var fakeCombination = CreateFakeCombination();

            _testee.AddPlayer(fakePlayer);
            _testee.AddCombination(fakeCombination);

            Action action = () => _testee.GetPointsForCombination(fakePlayer, fakeCombination.Type);

            // Act & Assert
            action.ShouldThrow<ArgumentException>().WithMessage("No toss assigned for this Player and CombinationType.");
        }

        #region Private Methods

        private static IPlayer CreateFakePlayer()
        {
            return A.Fake<IPlayer>();
        }

        private static ICombination CreateFakeCombination(CombinationType combinationType = CombinationType.Ones)
        {
            var fakeCombination = A.Fake<ICombination>();

            A.CallTo(() => fakeCombination.Type).Returns(combinationType);

            return fakeCombination;
        }

        private static IToss CreateFakeToss()
        {
            return A.Fake<IToss>();
        }

        private static IPoints CreateFakePoints()
        {
            return A.Fake<IPoints>();
        }

        #endregion
    }
}
