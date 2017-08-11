using System;
using FluentAssertions;
using NUnit.Framework;

namespace KataDatastructures.Test.Stack
{
    public class StackFixture
    {
        private KataDatastructures.Stack.Stack<string> _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new KataDatastructures.Stack.Stack<string>();
        }

        [Test]
        public void Push_AddsElementAtTopOfStack()
        {
            // Act
            _testee.Push("1");

            // Assert
            var result = _testee.Pop();
            result.Should().Be("1");
        }

        [Test]
        public void Pop_WithoutElementsInStack_ThrowsException()
        {
            // Arrange
            Action act = () => _testee.Pop();

            // Act & Assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void Top_ReturnsTopElement()
        {
            // Arrange
            _testee.Push("1");
            _testee.Push("2");

            // Act
            var result = _testee.Top();

            // Assert
            result.Should().Be("2");
        }
    }
}