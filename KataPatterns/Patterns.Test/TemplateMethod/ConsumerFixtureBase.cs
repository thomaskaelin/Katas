using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.TemplateMethod;

namespace Patterns.Test.TemplateMethod
{
    [TestFixture]
    public abstract class ConsumerFixtureBase
    {
        [Test]
        public void Consume_ReturnsCorrectResult()
        {
            // Arrange
            var testee = CreateTestee();

            // Act
            var result = testee.Consume();

            // Assert
            var expectedResult = GetExpectedResultOfConsume();
            result.Should().BeEquivalentTo(expectedResult);
        }

        protected abstract List<string> GetExpectedResultOfConsume();

        protected abstract Consumer CreateTestee();
     }
}