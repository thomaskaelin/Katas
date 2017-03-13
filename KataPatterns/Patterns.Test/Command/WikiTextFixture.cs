using FluentAssertions;
using NUnit.Framework;
using Patterns.Command;

namespace Patterns.Test.Command
{
    [TestFixture]
    public class WikiTextFixture
    {
        private WikiText _testee;
        private const string Content = "TestText";

        [SetUp]
        public void SetUp()
        {
            _testee = new WikiText(Content);
        }

        [Test]
        public void Constructor_Initializes_Content()
        {
            _testee.Content.Should().Be(Content);
        }

    }
}