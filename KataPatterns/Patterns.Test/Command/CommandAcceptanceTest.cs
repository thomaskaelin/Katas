using FluentAssertions;
using NUnit.Framework;
using Patterns.Command;

namespace Patterns.Test.Command
{
    [TestFixture]
    public class CommandAcceptanceTest
    {
        [Test]
        public void WikitextFormatter_AcceptanceTest()
        {
            // Arrange
            var wikiCommandManager = new WikiCommandManager();
            var text = new WikiText("Hallo Loana");
            
            var boldCommand = new BoldCommand(text);
            var italicCommand = new ItalicCommand(text);
            var codeCommand = new CodeCommand(text);

            // Act
            wikiCommandManager.Execute(boldCommand);
            wikiCommandManager.Execute(italicCommand);
            wikiCommandManager.Execute(boldCommand);
            wikiCommandManager.Execute(codeCommand);

            wikiCommandManager.Undo(2);
            wikiCommandManager.Execute(codeCommand);

            text.Content.Should().Be("{#*Hallo Loana*#}");

            wikiCommandManager.Undo(3);
            text.Content.Should().Be("Hallo Loana");

            wikiCommandManager.Redo(3);
            text.Content.Should().Be("{#*Hallo Loana*#}");

            // Assert

        }
    }
}