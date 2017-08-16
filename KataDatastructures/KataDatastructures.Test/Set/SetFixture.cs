using System;
using FluentAssertions;
using KataDatastructures.Set;
using NUnit.Framework;

namespace KataDatastructures.Test.Set
{
    public class SetFixture
    {
        private Set<string> _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Set<string>();
        }

        [Test]
        public void Add_WithNewElement_ReturnsTrue()
        {
            // Act
            var result = _testee.Add("1");

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Add_WithExistingElement_ReturnsFalse()
        {
            // Arrange
            _testee.Add("1");

            // Act
            var result = _testee.Add("1");

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void Contains_WithExistingElement_ReturnsTrue()
        {
            // Arrange
            _testee.Add("1");

            // Act
            var result = _testee.Contains("1");

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Contains_WithoutExistingElement_ReturnsFalse()
        {
            // Act
            var result = _testee.Contains("1");

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void Remove_WithExtistingElement_RemovesElemen()
        {
            // Arrange
            _testee.Add("1");
            _testee.Add("2");

            // Act
            _testee.Remove("1");

            // Assert
            _testee.Contains("1").Should().BeFalse();
            _testee.Size().Should().Be(1);
        }

        [Test]
        public void Remove_WithoutExistingElement_ThrowsInvalidOperationException()
        {
            // Act & Assert
            Action a = () => _testee.Remove("1");
            a.ShouldThrow<InvalidOperationException>();
        }
    }
}