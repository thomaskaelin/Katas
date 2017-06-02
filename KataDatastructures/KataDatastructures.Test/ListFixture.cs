using FluentAssertions;
using NUnit.Framework;

namespace KataDatastructures.Test
{
    [TestFixture]
    public class ListFixture
    {
        private List<string> _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new List<string>();
        }

        [Test]
        public void Add_AddsElementAtTheEndOfTheList()
        {
            // Act
            _testee.Add("1");

            // Assert
            _testee.Get(0).Should().Be("1");
        }
    }
}
