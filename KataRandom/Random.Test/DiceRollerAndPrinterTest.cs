using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    /// <summary>
    /// Probleme:
    /// 1) Zufälliges Verhalten wg. Random
    /// 2) Output auf Console
    /// 3) Exception bei Spezialfall
    /// 4) Langlaufende Berechnung (simuliert durch Thread.DoSomething)
    /// 
    /// Testfälle:
    /// 0) Ziel: FIRST (Fast, Independent, Repeatable, Self Validating, Timely)
    /// 1) Verhalten bei "normalen" Werten (1-6)
    /// 2) Verhalten bei "invalidem" Wert (0, 7)
    /// 
    /// Designfragen:
    /// 1) SRP eingehalten?
    /// 2) OCP eingehalten?
    /// 3) DIP eingehalten?
    /// 4) DRY eingehalten?
    /// 5) Clean Code - Namen?
    /// 6) Clean Code - Funktionen?
    /// 7) Clean Code - Kommentare?
    /// </summary>
    [TestFixture]
    public class DiceRollerAndPrinterTest
    {
        private DiceRollerAndPrinter _target;
        private RolledNumberGenerator _fakeRolledNumberGenerator;
        private RolledNumberToResultStringConverter _fakeRolledNumberToResultStringConverter;
        private RolledResultStringPrinter _fakeRolledResultStringPrinter;


        [SetUp]
        public void Setup()
        {
            _fakeRolledNumberGenerator = A.Fake<RolledNumberGenerator>();
            _fakeRolledNumberToResultStringConverter = A.Fake<RolledNumberToResultStringConverter>();
            _fakeRolledResultStringPrinter = A.Fake<RolledResultStringPrinter>();

            _target = new DiceRollerAndPrinter(_fakeRolledNumberGenerator, _fakeRolledNumberToResultStringConverter, _fakeRolledResultStringPrinter);
        }

        [Test]
        public void RollAndPrint_HasExpectedFlow()
        {
            // Arrange
            var printWasCalled = false;

            A.CallTo(() => _fakeRolledNumberGenerator.Roll()).Returns(10);
            A.CallTo(() => _fakeRolledNumberToResultStringConverter.Convert(10)).Returns("Super!");
            A.CallTo(() => _fakeRolledResultStringPrinter.Print("Super!")).Invokes(() => printWasCalled = true);

            // Act
            _target.RollAndPrint();

            // Assert
            printWasCalled.Should().BeTrue();
        }
    }
}
