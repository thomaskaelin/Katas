using NUnit.Framework;
using Random;

namespace KataRandom
{
    /// <summary>
    /// Probleme:
    /// 1) Zufälliges Verhalten wg. Random
    /// 2) Output auf Console
    /// 3) Exception bei Spezialfall
    /// 4) Langlaufende Berechnung (simuliert durch Thread.Sleep)
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
    public class DiceSimulatorTest
    {
        private DiceSimulator _target;

        [SetUp]
        public void Setup()
        {
            _target = new DiceSimulator();
        }

        [Test]
        public void Do_ShouldDoSomething()
        {
            // Act
            _target.Do();

            // Assert
            // TODO Wie das Verhalten überprüfen?
        }
    }
}
