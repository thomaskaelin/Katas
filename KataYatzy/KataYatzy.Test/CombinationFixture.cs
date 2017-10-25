using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace KataYatzy.Test
{
    [TestFixture]
    public abstract class CombinationFixture<TTestee>
        where TTestee : Combination
    {
        protected TTestee Testee { get; private set; }

        [SetUp]
        public void SetUp()
        {
            Testee = CreateTestee();
        }

        protected abstract TTestee CreateTestee();

        protected abstract CombinationType ExpectedCombinationType { get; }

        protected IToss CreateFakeToss(params int[] diceValues)
        {
            var fakeDices = new List<IDice>();

            foreach (var diceValue in diceValues)
            {
                var fakeDice = A.Fake<IDice>();
                A.CallTo(() => fakeDice.Value).Returns(diceValue);
                fakeDices.Add(fakeDice);
            }

            var fakeToss = A.Fake<IToss>();
            A.CallTo(() => fakeToss.Dices).Returns(fakeDices);

            return fakeToss;
        }

        protected void TestCalculate(int[] diceValues, int expectedPoints)
        {
            // Arrange
            var fakeToss = CreateFakeToss(diceValues);

            // Act
            var result = Testee.Calculate(fakeToss);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().Be(expectedPoints);
        }

        [Test]
        public void Constructor_Initializes_Type()
        {
            Testee.Type.Should().Be(ExpectedCombinationType);
        }

        [Test]
        public void Calculate_WithNoDices_Returns_0()
        {
            TestCalculate(new int[0], 0);
        }

    }
}