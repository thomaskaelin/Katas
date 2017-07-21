using System;
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
        public void Set_WithValidIndex_ReplacesItemAtPosition()
        {
            // Arrange
            _testee.Add("2");

            // Act
            _testee.Set(0, "1");

            // Assert
            _testee.Get(0).Should().Be("1");
        }

        [Test]
        public void Set_WithInvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Action act = () => _testee.Set(0, "Error");

            // Act & Assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Index_Get_ReturnsExpectedItem()
        {
            // Arrange
            _testee.Add("1");

            // Act
            var result = _testee[0];

            // Assert
            result.Should().Be("1");
        }

        [Test]
        public void Index_Set_SetsItemAtPosition()
        {
            // Arrange
            _testee.Add("1");

            // Act
            _testee[0] = "2";

            // Assert
            _testee[0].Should().Be("2");
        }

        [Test]
        public void Remove_WithValidIndex_WithElementAtTheEndOfList_RemovesItemAtPosition()
        {
            // Arrange
            _testee.Add("1");
            _testee.Add("2");
            _testee.Add("3");

            // Act
            _testee.Remove(2);

            // Assert
            _testee.Size().Should().Be(2);
            _testee.Get(0).Should().Be("1");
            _testee.Get(1).Should().Be("2");
        }

        [Test]
        public void Remove_WithValidIndex_WithElementAtBeginningOfList_RemovesItemAtPosition()
        {
            // Arrange
            _testee.Add("1");
            _testee.Add("2");
            _testee.Add("3");

            // Act
            _testee.Remove(0);

            // Assert
            _testee.Size().Should().Be(2);
            _testee.Get(0).Should().Be("2");
            _testee.Get(1).Should().Be("3");
        }

        [Test]
        public void Remove_WithValidIndex_WithElementAtMiddleOfList_RemovesItemAtPosition()
        {
            // Arrange
            _testee.Add("1");
            _testee.Add("2");
            _testee.Add("3");

            // Act
            _testee.Remove(1);

            // Assert
            _testee.Size().Should().Be(2);
            _testee.Get(0).Should().Be("1");
            _testee.Get(1).Should().Be("3");
        }

        [Test]
        public void Remove_WithInvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Action act = () => _testee.Remove(0);

            // Act & Assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
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
