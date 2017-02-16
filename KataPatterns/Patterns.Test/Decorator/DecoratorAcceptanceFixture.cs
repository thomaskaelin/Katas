using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Patterns.Decorator;

namespace Patterns.Test.Decorator
{
    [TestFixture]
    public class DecoratorAcceptanceFixture
    {
        [Test]
        public void DevideAcceptanceTest()
        {
            // Arrange
            var calculator = new Calculator();
            var exceptionDecorator = new ExceptionDecorator(calculator);

            // Act
            var result = exceptionDecorator.Divide(5, 0);

            // Assert
            result.Should().Be(99);
        }

    }
}