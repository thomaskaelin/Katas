using System;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class DiceValueToResultStringConverterTest
    {
        private DiceValueToResultStringConverter _target;
        private DiceValueToResultStringMapping _fakeMapping;

        [SetUp]
        public void SetUp()
        {
            _fakeMapping = A.Fake<DiceValueToResultStringMapping>();
            _target = new DiceValueToResultStringConverter(_fakeMapping);
        }

        [Test]
        public void Convert_WithValidInput_ReturnsExpectedResult()
        {
            // Arrange
            const int diceValue = 2;
            const string resultString = "You rolled a 2 - that's not that good.";

            A.CallTo(() => _fakeMapping.HasMapping(diceValue)).Returns(true);
            A.CallTo(() => _fakeMapping.GetResultString(diceValue)).Returns(resultString);

            // Act
            var result = _target.Convert(diceValue);

            // Assert
            result.Should().Be(resultString);
        }

        [Test]
        public void Convert_WithInvalidInput_ThrowsInvalidDiceValueException()
        {
            //Arrange
            const int diceValue = 2;

            A.CallTo(() => _fakeMapping.HasMapping(diceValue)).Returns(false);
            Action act = () => _target.Convert(diceValue);

            // Act & Assert
            act.ShouldThrow<InvalidDiceValueException>();
        }
    }
}