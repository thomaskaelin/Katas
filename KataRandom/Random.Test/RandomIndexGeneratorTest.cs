using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class RandomIndexGeneratorTest
    {
        private RandomIndexGenerator _target;

        [SetUp]
        public void SetUp()
        {
            _target = new RandomIndexGenerator();
        }

        [Test]
        public void GetRandomIndex_ContainsValidNumber()
        {
            var validIndexes = new List<int> {0, 1, 2};

            var result = _target.GetRandomIndex(validIndexes.Count);

            validIndexes.Should().Contain(result);
        }
    }
}