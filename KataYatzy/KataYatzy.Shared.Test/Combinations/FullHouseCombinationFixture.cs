using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;
using NUnit.Framework;

namespace KataYatzy.Shared.Test.Combinations
{
    [TestFixture]
    public class FullHouseCombinationFixture : CombinationFixture<FullHouseCombination>
    {
        #region Overrides

        protected override CombinationType ExpectedCombinationType => CombinationType.FullHouse;

        protected override FullHouseCombination CreateTestee()
        {
            return new FullHouseCombination();
        }

        #endregion

        #region Tests

        [Test]
        public void Calculate_With_22233_Returns_25()
        {
            TestCalculate(new[] { 2, 2, 2, 3, 3 }, 25);
        }

        [Test]
        public void Calculate_With_12345_Returns_0()
        {
            TestCalculate(new []{ 1, 2, 3, 4, 5 }, 0);
        }

        [Test]
        public void Calculate_With_12222_Returns_0()
        {
            TestCalculate(new []{1, 2, 2, 2, 2},0);
        }

        [Test]
        public void Calculate_With_11112_Returns_0()
        {
            TestCalculate(new []{1, 1, 1, 1, 2}, 0);
        }
        
        #endregion
    }
}