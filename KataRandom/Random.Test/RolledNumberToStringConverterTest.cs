using System;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class RolledNumberToStringConverterTest
    {
        private RolledNumberToResultStringConverter _target;
        private DiceValueToStringResultMapping _fakeMapping;


        [SetUp]
        public void SetUp()
        {
            _fakeMapping = A.Fake<DiceValueToStringResultMapping>();
            _target = new RolledNumberToResultStringConverter(_fakeMapping);
        }

        [Test]
        public void Convert_WithValidInput_ReturnExpectedResult()
        {
            // Arrange
            const int rolledNumber = 2;
            const string stringResult = "Sugus";

            A.CallTo(() => _fakeMapping.HasMapping(rolledNumber)).Returns(true);
            A.CallTo(() => _fakeMapping.GetStringResult(rolledNumber)).Returns(stringResult);

            // Act
            var result = _target.Convert(rolledNumber);

            // Assert
            Assert.AreEqual(stringResult, result);
        }

        [Test]
        public void Convert_WithInvalidInput_ThrowExcpetion()
        {
            //Arrange
            const int rolledNumber = 2;
            A.CallTo(() => _fakeMapping.HasMapping(rolledNumber)).Returns(false);
            Action act = () => _target.Convert(rolledNumber);

            // Act & Assert
            act.ShouldThrow<InvalidNumberException>();
        }
        
    }
}