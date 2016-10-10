using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class DiceValueToResultStringMappingTest
    {
        private DiceValueToResultStringMapping _target;

        [SetUp]
        public void SetUp()
        {
            _target = new DiceValueToResultStringMapping();
        }

        [Test]
        public void DiceValues_WithoutMappings_ReturnsEmptyEnumerable()
        {
            // Act
            var result = _target.DiceValues;

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void DiceValues_WithMappings_ReturnsValuesFromMappings()
        {
            // Arrange
            const int diceValue1 = 1;
            const int diceValue2 = 2;

            _target.AddMapping(diceValue1, "Result String #1");
            _target.AddMapping(diceValue2, "Result String #2");

            // Act
            var result = _target.DiceValues.ToList();

            // Assert
            result.Should().Contain(diceValue1);
            result.Should().Contain(diceValue2);
        }

        [Test]
        public void HasMapping_WithInvalidDiceValue_ReturnsFalse()
        {
            // Act
            var result = _target.HasMapping(0);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void HasMapping_WithValidDiceValue_ReturnsTrue()
        {
            // Arrange
            const int diceValue = 1;
            const string resultString = "String Result";

            _target.AddMapping(diceValue, resultString);

            // Act
            var result = _target.HasMapping(diceValue);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void GetResultString_ReturnsResultStringFromMapping()
        {
            // Arrange
            const int diceValue = 1;
            const string resultString = "String Result";

            _target.AddMapping(diceValue, resultString);

            // Act
            var result = _target.GetResultString(diceValue);

            // Assert
            result.Should().Be(resultString);
        }
    }
}