﻿using FluentAssertions;
using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations.Helper;
using KataYatzy.Shared.Test.Helper;
using NUnit.Framework;

namespace KataYatzy.Shared.Test.Combinations.Helper
{
    [TestFixture]
    public class TossAnalyzerFixture
    {
        private TossAnalyzer _testee;
        private IToss _fakeToss;

        private void CreateTestee(params int[] diceValues)
        {
            _fakeToss = FakeCreator.CreateFakeToss(diceValues);
            _testee = new TossAnalyzer(_fakeToss);
        }

        [Test]
        public void Toss_Returns_ParameterOfConstructor()
        {
            // Arrange
            CreateTestee();

            // Assert
            _testee.Toss.Should().BeSameAs(_fakeToss);
        }

        [Test]
        public void SumOfAllDiceValues_WithEmptyToss_ReturnsZero()
        {
            // Arrange
            CreateTestee();

            // Assert
            _testee.SumOfAllDiceValues().Should().Be(0);
        }

        [Test]
        public void SumOfAllDiceValues_WithNonEmptyToss_ReturnsSum()
        {
            // Arrange
            CreateTestee(1, 1, 2, 6, 6);

            // Assert
            _testee.SumOfAllDiceValues().Should().Be(16);
        }

        [Test]
        public void CountOccurencesOfDiceValue_WithEmptyToss_ReturnsZero()
        {
            // Arrange
            CreateTestee();

            // Act
            var result = _testee.CountOccurencesOfDiceValue(1);

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void CountOccurencesOfDiceValue_WithNonEmptyToss_WhenDiceValueOccurs_ReturnsCount()
        {
            // Arrange
            CreateTestee(1, 2, 2, 2, 4);

            // Act
            var result = _testee.CountOccurencesOfDiceValue(2);

            // Assert
            result.Should().Be(3);
        }

        [Test]
        public void CountOccurencesOfDiceValue_WithNonEmptyToss_WhenDiceValueNotOccurs_ReturnsZero()
        {
            // Arrange
            CreateTestee(1, 2, 2, 2, 4);

            // Act
            var result = _testee.CountOccurencesOfDiceValue(3);

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void AnyDiceValueOccursAtLeastXTimes_WithEmptyToss_ReturnsFalse()
        {
            // Arrange
            CreateTestee();

            // Act
            var result = _testee.AnyDiceValueOccursAtLeastXTimes(1);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void AnyDiceValueOccursAtLeastXTimes_WithNonEmptyToss_WhenNoDiceValueOccursXTimes_ReturnsFalse()
        {
            // Arrange
            CreateTestee(1, 1, 2, 2, 3);

            // Act
            var result = _testee.AnyDiceValueOccursAtLeastXTimes(3);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void AnyDiceValueOccursAtLeastXTimes_WithNonEmptyToss_WhenAnyDiceValueOccursXTimes_ReturnsTrue()
        {
            // Arrange
            CreateTestee(1, 1, 2, 2, 3);

            // Act
            var result = _testee.AnyDiceValueOccursAtLeastXTimes(2);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void GetOccurencesPerDiceValues_WithEmptyToss_ReturnsEmptyDictionary()
        {
            // Arrange
            CreateTestee();

            // Act
            var result = _testee.GetOccurencesPerDiceValue();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void GetOccurencesPerDiceValues_With12345_ReturnsCorrectDictionary()
        {
            // Arrange
            CreateTestee(1, 2, 3, 4, 5);

            // Act
            var result = _testee.GetOccurencesPerDiceValue();

            // Assert
            result.Count.Should().Be(5);
            result[1].Should().Be(1);
            result[2].Should().Be(1);
            result[3].Should().Be(1);
            result[4].Should().Be(1);
            result[5].Should().Be(1);
        }

        [Test]
        public void GetOccurencesPerDiceValues_With33344_ReturnsCorrectDictionary()
        {
            // Arrange
            CreateTestee(3, 3, 3, 4, 4);

            // Act
            var result = _testee.GetOccurencesPerDiceValue();

            // Assert
            result.Count.Should().Be(2);
            result[3].Should().Be(3);
            result[4].Should().Be(2);
        }
    }
}