using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class TossFactoryFixture
    {
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(10000)]
        [TestCase(42)]
        public void CreateToss_ReturnsToss_WithExpectedNumberOfDices(int numberOfDices)
        {
            // Arrange
            var testee = new TossFactory(numberOfDices, 1, 6);

            // Act
            var result = testee.CreateToss();

            // Assert
            result.Dices.Count.Should().Be(numberOfDices);
        }

        [TestCase(1,6)]
        [TestCase(0,10)]
        [TestCase(1,1)]
        public void CreateToss_ReturnsToss_WithDiceValueInExpectedRange(int minValue, int maxValue)
        {
            // Arrange
            var testee = new TossFactory(5, minValue,maxValue);

            // Act
            var result = testee.CreateToss();

            // Assert
            var isAnyDiceValueOutOfRange = result.Dices.Select(d => d.Value).Any(dv => dv < minValue || dv > maxValue);
            isAnyDiceValueOutOfRange.Should().BeFalse();
        }
    }
}