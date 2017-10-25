using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace KataYatzy.Test
{
    [TestFixture]
    public class OnesCombinationFixture : CombinationFixture<OnesCombination>
    {
        protected override OnesCombination CreateTestee()
        {
            return new OnesCombination();
        }

        protected override CombinationType ExpectedCombinationType => CombinationType.Ones;

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
    }
}