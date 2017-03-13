using FluentAssertions;
using NUnit.Framework;
using Patterns.Observer;

namespace Patterns.Test.Observer
{
    [TestFixture]
    public class ModelFixture
    {
        private Model _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Model();
        }

        [Test]
        public void Refresh_RefreshsValue()
        {
            // Act
            _testee.Refresh();

            // Assert
            _testee.Value.Should().Be("NewValue");
        }
    }
}