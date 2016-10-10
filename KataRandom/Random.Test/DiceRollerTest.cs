using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class DiceRollerTest
    {
        private DiceRoller _target;
        private readonly List<int> _diceValues = new List<int> { 19, 42, 5 };
        private Dice _fakeDice;
        private LongRunningOperation _fakeLongRunningOperation;
        private RandomNumberGenerator _fakeRandomNumberGenerator;

        [SetUp]
        public void SetUp()
        {
            _fakeDice = A.Fake<Dice>();
            _fakeLongRunningOperation = A.Fake<LongRunningOperation>();
            _fakeRandomNumberGenerator = A.Fake<RandomNumberGenerator>();

            _target = new DiceRoller(_fakeDice, _fakeLongRunningOperation, _fakeRandomNumberGenerator);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Roll_ReturnsExpectedResult(int returnedIndex)
        {
            // Arrange
            A.CallTo(() => _fakeDice.Values).Returns(_diceValues);
            A.CallTo(() => _fakeRandomNumberGenerator.GetRandomNumber(A<int>.Ignored)).Returns(returnedIndex);
            A.CallTo(() => _fakeLongRunningOperation.DoSomething()).DoesNothing();
            
            // Act
            var result = _target.Roll();

            // Assert
            var expectedDiceValue = _diceValues[returnedIndex];
            result.Should().Be(expectedDiceValue);
        }
    }
}