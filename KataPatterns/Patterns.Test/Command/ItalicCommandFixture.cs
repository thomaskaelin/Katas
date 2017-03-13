using FluentAssertions;
using NUnit.Framework;
using Patterns.Command;

namespace Patterns.Test.Command
{
    public class ItalicCommandFixture
    {
        private ItalicCommand _testee;
        private WikiText _wikiText;

        [SetUp]
        public void SetUp()
        {
            var content = "TestContent";
            _wikiText = new WikiText(content);
            _testee = new ItalicCommand(_wikiText);
        }

        [Test]
        public void Do_ReturnsItalicContent()
        {
            // Act
            _testee.Do();

            // Assert
            _wikiText.Content.Should().Be("#TestContent#");
        }

        [Test]
        public void UnDo_ReturnsExpectedContent()
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