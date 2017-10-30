using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;
using NUnit.Framework;

namespace KataYatzy.Shared.Test.Combinations
{
    [TestFixture]
    public class OnesCombinationFixture : CombinationFixture<OnesCombination>
    {
        #region Overrides

        protected override CombinationType ExpectedCombinationType => CombinationType.Ones;

        protected override OnesCombination CreateTestee()
        {
            return new OnesCombination();
        }

        #endregion

        #region Tests

        [Test]
        public void Calculate_With_23456_Returns_0()
        {
            TestCalculate(new []{ 2,3,4,5,6 }, 0);
        }

        [Test]
        public void Calculate_With_11123_Returns_3()
        {
            TestCalculate(new []{ 1,1,1,2,3 }, 3);
        }

        #endregion
    }
}