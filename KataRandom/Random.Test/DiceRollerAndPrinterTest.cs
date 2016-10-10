using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class DiceRollerAndPrinterTest
    {
        private DiceRollerAndPrinter _target;
        private DiceRoller _fakeRoller;
        private DiceValueToResultStringConverter _fakeConverter;
        private ResultStringPrinter _fakePrinter;

        [SetUp]
        public void Setup()
        {
            _fakeRoller = A.Fake<DiceRoller>();
            _fakeConverter = A.Fake<DiceValueToResultStringConverter>();
            _fakePrinter = A.Fake<ResultStringPrinter>();

            _target = new DiceRollerAndPrinter(_fakeRoller, _fakeConverter, _fakePrinter);
        }

        [Test]
        public void RollAndPrint_HasExpectedFlow()
        {
            // Arrange
            const int rolledDiceValue = 10;
            const string resultString = "Super!";
            var printWasCalled = false;

            A.CallTo(() => _fakeRoller.Roll()).Returns(rolledDiceValue);
            A.CallTo(() => _fakeConverter.Convert(rolledDiceValue)).Returns(resultString);
            A.CallTo(() => _fakePrinter.Print(resultString)).Invokes(() => printWasCalled = true);

            // Act
            _target.RollAndPrint();

            // Assert
            printWasCalled.Should().BeTrue();
        }
    }
}