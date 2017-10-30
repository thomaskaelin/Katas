using FluentAssertions;
using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;
using KataYatzy.Shared.Test.Helper;
using NUnit.Framework;

namespace KataYatzy.Shared.Test.Combinations
{
    [TestFixture]
    public abstract class CombinationFixture<TTestee>
        where TTestee : Combination
    {
        [SetUp]
        public void SetUp()
        {
            Testee = CreateTestee();
        }

        #region Protected Properties and Methods

        protected TTestee Testee { get; private set; }

        protected abstract TTestee CreateTestee();

        protected abstract CombinationType ExpectedCombinationType { get; }

        protected void TestCalculate(int[] diceValues, int expectedPoints)
        {
            // Arrange
            var fakeToss = FakeCreator.CreateFakeToss(diceValues);

            // Act
            var result = Testee.Calculate(fakeToss);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().Be(expectedPoints);
        }

        #endregion

        #region Tests

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

        #endregion
    }
}