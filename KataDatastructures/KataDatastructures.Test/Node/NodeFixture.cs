using System;
using FluentAssertions;
using NUnit.Framework;

namespace KataDatastructures.Test
{
    public class NodeFixture
    {
        private INode<string> _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = CreateTestee();
        }

        [Test]
        public void PropertyNext_CanBeModified()
        {
            // Arrange
            var oldNode = new Node<string>();
            _testee.Next = oldNode;

            // Act
            _testee.Next = new Node<string>();

            // Assert
            _testee.Next.Should().NotBeSameAs(oldNode);
        }
        [Test]
        public void PropertyNext_ReturnsNode()
        {
            // Arrange
            var node = new Node<string>();
            _testee.Next = node;

            // Act
            var result = _testee.Next;

            result.Should().BeSameAs(node);
        }

        [Test]
        public void PropertyPrevious_CanBeModified()
        {
            // Arrange
            var oldNode = new Node<string>();
            _testee.Previous = oldNode;

            // Act
            _testee.Previous = new Node<string>();

            // Assert
            _testee.Previous.Should().NotBeSameAs(oldNode);
        }

        [Test]
        public void PropertyPrevious_ReturnsNode()
        {
            // Arrange
            var oldNode = new Node<string>();
            _testee.Previous = oldNode;

            // Act
            var result = _testee.Previous;

            result.Should().BeSameAs(oldNode);
        }

        [Test]
        public void PropertyElement_CanBeModified()
        {
            // Arrange
            const string oldElement = "old element";
            _testee.Element = oldElement;

            // Act
            const string newElement = "new element";
            _testee.Element = newElement;

            // Assert
            _testee.Element.Should().Be(newElement);
        }

        [Test]
        public void PropertyElement_ReturnsProperty()
        {
            // Arrange
            const string element = "element";
            _testee.Element = element;

            // Act
            var result = _testee.Element;

            // Assert
            result.Should().Be(element);
        }

        [Test]
        public void HasNext_WithNextNode_ReturnsTrue()
        {
            // Arrange
            _testee.Next = new Node<string>();

            // Act
            var result = _testee.HasNext();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void HasNext_WithoutNextNode_ReturnsFalse()
        {
            // Act
            var result = _testee.HasNext();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void HasPrevious_WithPreviousNode_ReturnsTrue()
        {
            // Arrange
            _testee.Previous = new Node<string>();

            // Act
            var result = _testee.HasPrevious();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void HasPrevious_WithoutPreviousNode_ReturnsFalse()
        {
            // Act
            var result = _testee.HasPrevious();

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void GetFirst_NotOnFirstElements_ReturnsFirstNode()
        {
            // Arrange
            var firstNode = CreateTestee();
            var secondNode = CreateTestee();
            var thirdNode = CreateTestee();

            firstNode.Next = secondNode;
            secondNode.Previous = firstNode;
            secondNode.Next = thirdNode;
            thirdNode.Previous = secondNode;

            // Act
            var result = thirdNode.GetFirst();

            // Assert
            result.Should().Be(firstNode);
        }

        [Test]
        public void GetFirst_OnFirstElement_ReturnsFirstNode()
        {
            // Arrange
            var firstNode = CreateTestee();

            // Act
            var result = firstNode.GetFirst();

            // Assert
            result.Should().Be(firstNode);
        }

        [Test]
        public void GetLast_OnLastElement_ReturnsLastNode()
        {
            // Arrange
            var lastNode = CreateTestee();

            // Act
            var result = lastNode.GetLast();

            // Assert
            result.Should().Be(lastNode);
        }

        [Test]
        public void GetLast_NotOnLastElement_ReturnsLastNode()
        {
            // Arrange
            var firstNode = CreateTestee();
            var secondNode = CreateTestee();
            var thirdNode = new Node<string>();

            firstNode.Next = secondNode;
            secondNode.Next = thirdNode;

            // Act
            var result = firstNode.GetLast();

            // Assert
            result.Should().Be(thirdNode);
        }

        [Test]
        public void AddBefore_WithPreviousNode_AddsNodeBeforeCurrentNode()
        {
            // Arrange
            var firstNode = new Node<string>();
            var secondNode = new Node<string>();
            var newNode = new Node<string>();

            firstNode.Next = secondNode;
            secondNode.Previous = firstNode;

            // Act
            secondNode.AddBefore(newNode);

            // Assert
            firstNode.Next.Should().Be(newNode);
            newNode.Next.Should().Be(secondNode);
            newNode.Previous.Should().Be(firstNode);
            secondNode.Previous.Should().Be(newNode);
        }

        [Test]
        public void AddBefore_WithoutPreviousNode_AddsNodeBeforeCurrentNode()
        {
            // Arrange
            var firstNode = new Node<string>();
            var newNode = new Node<string>();

            // Act
            firstNode.AddBefore(newNode);

            // Assert
            newNode.Next.Should().Be(firstNode);
            firstNode.Previous.Should().Be(newNode);
        }

        private INode<string> CreateTestee()
        {
            return new Node<string>();
        }
    }
}