using System.Runtime.InteropServices;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Command;

namespace Patterns.Test.Command
{
    [TestFixture]
    public class BoldCommandFixture
    {
        private BoldCommand _testee;
        private WikiText _wikiText;

        [SetUp]
        public void SetUp()
        {
            var content = "TestContent";
            _wikiText = new WikiText(content);
            _testee = new BoldCommand(_wikiText);
        }

        [Test]
        public void Do_ReturnsBoldContent()
        {
            // Act
            _testee.Do();

            // Assert
            _wikiText.Content.Should().Be("*TestContent*");
        }

        [Test]
        public void UnDo_ReturnsExpectedContentContent()
        {
            // Assert
            _testee.Do();

            // Act
            _testee.Undo();

            // Assert
            _wikiText.Content.Should().Be("TestContent");
        }
    }
}