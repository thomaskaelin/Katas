﻿using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;
using NUnit.Framework;

namespace KataYatzy.Shared.Test.Combinations
{
    [TestFixture]
    public class SmallStreetCombinationFixture : CombinationFixture<SmallStreetCombination>
    {
        #region Overrides

        protected override CombinationType ExpectedCombinationType => CombinationType.SmallStreet;

        protected override SmallStreetCombination CreateTestee()
        {
            return new SmallStreetCombination();
        }

        #endregion

        #region Tests

        [Test]
        public void Calculate_With_22233_Returns_0()
        {
            TestCalculate(new[] { 2, 2, 2, 3, 3 }, 0);
        }

        [Test]
        public void Calculate_With_12341_Returns_30()
        {
            TestCalculate(new[] { 1, 2, 3, 4, 1}, 30);
        }

        [Test]
        public void Calculate_With_12345_Returns_30()
        {
            TestCalculate(new[] { 1, 2, 3, 4, 5 }, 30);
        }

        #endregion
    }
}