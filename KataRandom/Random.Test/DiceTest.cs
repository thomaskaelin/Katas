using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class DiceTest
    {
        private Dice _target;
        private readonly IEnumerable<int> _values = new List<int>{ 1, 2, 3, 4, 5, 6};

        [SetUp]
        public void Setup()
        {
            _target = new Dice(_values);
        }

        [Test]
        public void Constuctor_InitializesValues()
        {
            // Assert
            _target.Values.Should().Equal(_values);
        }
    }
}