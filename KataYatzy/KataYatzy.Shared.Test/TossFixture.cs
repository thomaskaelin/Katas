using FakeItEasy;
using FluentAssertions;
using KataYatzy.Contracts;
using NUnit.Framework;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class TossFixture
    {
        private Toss _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Toss();
        }

        [Test]
        public void Constructor_InitializesDices()
        {
            // Assert
            _testee.Dices.Should().BeEmpty();
        }

        [Test]
        public void AddDices_AddsParameterToDices()
        {
            // Arrange
            var fakeDice = A.Fake<IDice>();

            // Act
            _testee.AddDice(fakeDice);

            // Assert
            _testee.Dices.Count.Should().Be(1);
            _testee.Dices.Should().Contain(fakeDice);
        }
    }
}
