using FluentAssertions;
using NUnit.Framework;
using Patterns.Observer;

namespace Patterns.Test.Observer
{
    [TestFixture]
    public class ModelFixture : SubjectFixtureBase
    {
        private Model _testee;

        public override Subject CreateTestee()
        {
            _testee = new Model();
            return _testee;
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