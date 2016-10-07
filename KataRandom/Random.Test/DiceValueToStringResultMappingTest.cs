using FluentAssertions;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class DiceValueToStringResultMappingTest
    {
        private DiceValueToStringResultMapping _target;

        [SetUp]
        public void SetUp()
        {
            _target = new DiceValueToStringResultMapping();
        }

        [Test]
        public void HasMapping_WithInvalidRolledNumber_ReturnsFalse()
        {
            var result = _target.HasMapping(0);
            result.Should().BeFalse();
        }

        [Test]
        public void HasMapping_WithValidRolledNumber_ReturnsTrue()
        {
            _target.AddMapping(1, string.Empty);
            var result = _target.HasMapping(1);
            result.Should().BeTrue();
        }

        [Test]
        public void GetStringResult_ReturnsResultFromMapping()
        {
            const int rolledNumber = 1;
            const string stringResult = "sugus";
            _target.AddMapping(rolledNumber,stringResult);
            var result = _target.GetStringResult(rolledNumber);
            result.Should().Be(stringResult);
        }
    }
}