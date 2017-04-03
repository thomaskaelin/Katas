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

        private void CreateTestee(string content)
        {
            _wikiText = new WikiText(content);
            _testee = new BoldCommand(_wikiText);
        }

        [Test]
        public void Do_ReturnsBoldContent()
        {
            // Arrange
            CreateTestee("TestContent");

            // Act
            _testee.Do();

            // Assert
            _wikiText.Content.Should().Be("*TestContent*");
        }

        [Test]
        public void UnDo_ReturnsExpectedContentContent()
        {
            // Assert
            CreateTestee("*TestContent*");

            // Act
            _testee.Undo();

            // Assert
            _wikiText.Content.Should().Be("TestContent");
        }
    }
}