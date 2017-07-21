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
            _testee.Size().Should().Be(1);
            _testee.Get(0).Should().Be("1");
        }

        [Test]
        public void Add_WithTwoItems_AddsEveryItemToTheEndOfTheList()
        {
            // Act
            _testee.Add("1");
            _testee.Add("2");

            // Assert
            _testee.Size().Should().Be(2);
            _testee.Get(0).Should().Be("1");
            _testee.Get(1).Should().Be("2");

        }
        
        [Test]
        public void Size_WithoutElements_Returns0()
        {
            // Act
            var result = _testee.Size();

            // Assert
            result.Should().Be(0);
        }

        
    }
}
