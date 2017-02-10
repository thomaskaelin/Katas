using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.TemplateMethod;

namespace Patterns.Test.TemplateMethod
{
    [TestFixture]
    public class ConsumerFixture
    {
        private Consumer _testee;

        [Test]
        public void Sort_WithAscendingSort_ReturnsAscendingSortedString()
        {
            // Arrange
            _testee = new AscendingSortConsumer();
           
            // Act
            var result =_testee.Consume();

            // Assert
            var expectedList = new List<string> {"A", "B", "C"};
            result.Should().Equal(expectedList);
        }

        [Test]
        public void Sort_WithDescendingSort_ReturnsDescendingSortedString()
        {
            // Arrange
            _testee = new DescendingSortConsumer();

            // Act
            var result = _testee.Consume();

            // Assert
            var expectedList = new List<string> { "C", "B", "A" };
            result.Should().Equal(expectedList);
        }


    }
}