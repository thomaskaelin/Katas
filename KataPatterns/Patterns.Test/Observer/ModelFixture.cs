using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Observer;

namespace Patterns.Test.Observer
{
    [TestFixture]
    public class ModelFixture : SubjectFixtureBase<Model>, IObserver
    {
        private bool wasCalled = false;
        public override Model CreateTestee()
        {
            return new Model();
        }

        [Test]
        public void Refresh_RefreshsValue()
        {
            // Act
            Testee.Refresh();
            
            // Assert
            Testee.Value.Should().Be("NewValue");
        }

        [Test]
        public void Refresh_CallsNotify()
        {
            // Arrange
            Testee.Attach(this);

            // Act
            Testee.Refresh();

            // Assert
            wasCalled.Should().BeTrue();
        }

        public void Update()
        {
            wasCalled = true;
        }
    }
}