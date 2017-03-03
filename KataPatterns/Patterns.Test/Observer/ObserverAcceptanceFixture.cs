using FluentAssertions;
using NUnit.Framework;

namespace Patterns.Test.Observer
{
    [TestFixture]
    public class ObserverAcceptanceFixture
    {
        [Test]
        public void AcceptanceTest()
        {
            // Arrange
            var observer = new Patterns.Observer.Observer();

            // Act
            observer.Refresh();

            // Assert
            observer.Value.Should().Be("NewValue");
        }
    }
}