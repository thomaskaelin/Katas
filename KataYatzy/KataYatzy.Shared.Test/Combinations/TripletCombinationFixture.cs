using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;
using NUnit.Framework;

namespace KataYatzy.Shared.Test.Combinations
{
    [TestFixture]
    public class TripletCombinationFixture : CombinationFixture<TripletCombination>
    {
        #region Overrides

        protected override CombinationType ExpectedCombinationType => CombinationType.Triplet;

        protected override TripletCombination CreateTestee()
        {
            return new TripletCombination();
        }

        #endregion

        #region Tests

        [Test]
        public void Calculate_With_23456_Returns_0()
        {
            TestCalculate(new[] { 2, 3, 4, 5, 6 }, 0);
        }

        [Test]
        public void Calculate_With_11123_Returns_8()
        {
            TestCalculate(new[] { 1, 1, 1, 2, 3 }, 8);
        }

        #endregion
    }
}