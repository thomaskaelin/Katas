using System.Runtime.InteropServices;
using FluentAssertions;
using NUnit.Framework;

namespace KataDatastructures.Test.Dictionary
{
    public class DictionaryFixture
    {
        private KataDatastructures.Dictionary.Dictionary<string, string> _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new KataDatastructures.Dictionary.Dictionary<string, string>();
        }

        [Test]
        public void Get_WithValidKey_ReturnsValue()
        {
            // Arrange
            _testee.Put("1", "eins");
            _testee.Put("2", "zwei");
            _testee.Put("3", "drei");

            // Act
            var result = _testee.Get("2");

            // Assert
            result.Should().Be("zwei");
        }

        [Test]
        public void Get_WithInvalidKey_ReturnsNull()
        {
            // Act
            var result = _testee.Get("1");

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void Put_WithNewKey_AddsKVP()
        {
            // Act
            _testee.Put("1", "eins");

            // Assert
            var result = _testee.Get("1");
            result.Should().Be("eins");
        }

        [Test]
        public void Put_WithExistingKey_UpdatesValue()
        {
            // Arrange
            _testee.Put("1", "eins");

            // Act
            _testee.Put("1", "one");

            // Assert
            var result = _testee.Get("1");
            result.Should().Be("one");
        }
    }
}