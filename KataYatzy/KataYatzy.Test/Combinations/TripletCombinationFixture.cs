using KataYatzy.Combinations;
using NUnit.Framework;

namespace KataYatzy.Test.Combinations
{
    [TestFixture]
    public class TripletCombinationFixture : CombinationFixture<TripletCombination>
    {
        protected override TripletCombination CreateTestee()
        {
            return new TripletCombination();
        }

        protected override CombinationType ExpectedCombinationType => CombinationType.Triplet;

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
    }
}