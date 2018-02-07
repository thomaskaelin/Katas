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

        #region Private Methods

        private static IPlayer CreateFakePlayer()
        {
            return A.Fake<IPlayer>();
        }

        private static ICombination CreateFakeCombination()
        {
            return A.Fake<ICombination>();
        }

        #endregion
    }
}
