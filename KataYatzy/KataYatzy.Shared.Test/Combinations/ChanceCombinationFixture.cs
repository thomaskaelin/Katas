using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;
using NUnit.Framework;

namespace KataYatzy.Shared.Test.Combinations
{
    [TestFixture]
    public class ChanceCombinationFixture : CombinationFixture<ChanceCombination>
    {
        #region Overrides

        protected override CombinationType ExpectedCombinationType => CombinationType.Chance;

        protected override ChanceCombination CreateTestee()
        {
            return new ChanceCombination();
        }

        #endregion

        #region Tests

        [Test]
        public void Calculate_With_22233_Returns_12()
        {
            TestCalculate(new[] { 2, 2, 2, 3, 3 }, 12);
        }

        [Test]
        public void Calculate_With_11111_Returns_5()
        {
            TestCalculate(new []{ 1, 1, 1, 1, 1}, 5);
        }

        #endregion
    }
}