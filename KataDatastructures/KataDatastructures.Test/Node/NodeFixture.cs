using FluentAssertions;
using KataDatastructures.Node;
using NUnit.Framework;

namespace KataDatastructures.Test.Node
{
    public class NodeFixture
    {
        private INode<string> _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = CreateNode();
        }

        [Test]
        public void Constructor_InitializesProperty_Head()
        {
            // Assert
            _testee.Head.Should().NotBeNull();
        }

        [Test]
        public void Constructor_InitializesProperty_Tail()
        {
            // Assert
            _testee.Tail.Should().NotBeNull();
        }

        [Test]
        public void Property_Next_CanBeModified()
        {
            // Arrange
            var oldNode = CreateNode();
            var newNode = CreateNode();
            _testee.Next = oldNode;

            // Act
            _testee.Next = newNode;

            // Assert
            _testee.Next.Should().Be(newNode);
        }

        [Test]
        public void Property_Previous_CanBeModified()
        {
            // Arrange
            var oldNode = CreateNode();
            var newNode = CreateNode();
            _testee.Previous = oldNode;

            // Act
            _testee.Previous = newNode;

            // Assert
            _testee.Previous.Should().Be(newNode);
        }

        [Test]
        public void Property_Element_CanBeModified()
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
        public void Property_Head_CanBeModified()
        {
            // Arrange
            var head = CreateNode("old");
            var modifiedHead = CreateNode("new");

            _testee.Head = head;

            // Act
            _testee.Head = modifiedHead;

            // Assert
            _testee.Head.Should().BeSameAs(modifiedHead);
            _testee.Head.Element.Should().Be("new");
        }

        [Test]
        public void Property_Tail_CanBeModified()
        {
            // Arrange
            var tail = CreateNode("old");
            var modifiedTail = CreateNode("new");

            _testee.Tail = tail;

            // Act
            _testee.Tail = modifiedTail;

            // Assert
            _testee.Tail.Should().BeSameAs(modifiedTail);
            _testee.Tail.Element.Should().Be("new");
        }

        [Test]
        public void HasNext_WithNextNode_ReturnsTrue()
        {
            // Arrange
            _testee.Next = CreateNode();

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
            _testee.Previous = CreateNode();

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
            var firstNode = CreateNode();
            var secondNode = CreateNode();
            var thirdNode = CreateNode();

            firstNode.AddAfter(secondNode);
            secondNode.AddAfter(thirdNode);

            // Act
            var result = thirdNode.GetFirst();

            // Assert
            result.Should().Be(firstNode);
        }

        [Test]
        public void GetFirst_OnFirstElement_ReturnsFirstNode()
        {
            // Arrange
            var firstNode = CreateNode();

            // Act
            var result = firstNode.GetFirst();

            // Assert
            result.Should().Be(firstNode);
        }

        [Test]
        public void GetLast_OnLastElement_ReturnsLastNode()
        {
            // Arrange
            var lastNode = CreateNode();

            // Act
            var result = lastNode.GetLast();

            // Assert
            result.Should().Be(lastNode);
        }

        [Test]
        public void GetLast_NotOnLastElement_ReturnsLastNode()
        {
            // Arrange
            var firstNode = CreateNode();
            var secondNode = CreateNode();
            var thirdNode = CreateNode();

            firstNode.AddAfter(secondNode);
            secondNode.AddAfter(thirdNode);

            // Act
            var result = firstNode.GetLast();

            // Assert
            result.Should().Be(thirdNode);
        }

        [Test]
        public void AddBefore_WithPreviousNode_AddsNodeBeforeCurrentNode()
        {
            // Arrange
            var firstNode = CreateNode();
            var secondNode = CreateNode();
            var newNode = CreateNode();

            firstNode.AddAfter(secondNode);

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
            var firstNode = CreateNode();
            var newNode = CreateNode();

            // Act
            firstNode.AddBefore(newNode);

            // Assert
            newNode.Next.Should().Be(firstNode);
            firstNode.Previous.Should().Be(newNode);
        }

        [Test]
        public void AddBefore_WithoutPrevioutNode_UpdatesHead()
        {
            // Arrange
            var firstNode = CreateNode();
            var newNode = CreateNode();

            // Act
            firstNode.AddBefore(newNode);

            // Assert
            firstNode.Head.Should().Be(newNode);
        }

        [Test]
        public void AddAfter_WithoutNextNode_AddsNodeAfterCurrentNode()
        {
            // Arrange
            var firstNode = CreateNode();
            var newNode = CreateNode();
            

            // Act
            firstNode.AddAfter(newNode);

            // Assert
            firstNode.Next.Should().Be(newNode);
            newNode.Previous.Should().Be(firstNode);
        }

        [Test]
        public void AddAfter_WithNextNode_AddsNodeAfterCurrentNode()
        {
            // Arrange
            var firstNode = CreateNode();
            var secondNode = CreateNode();
            var newNode = CreateNode();
            firstNode.AddAfter(secondNode);

            // Act
            firstNode.AddAfter(newNode);

            // Assert
            firstNode.Next.Should().Be(newNode);
            newNode.Previous.Should().Be(firstNode);
        }

        [Test]
        public void AddAfter_WithoutNextNode_UpdatesTail()
        {
            // Arrange
            var firstNode = CreateNode();
            var secondNode = CreateNode();
            var newNode = CreateNode();

            firstNode.AddAfter(secondNode);

            // Act
            firstNode.AddAfter(newNode);
        }

        [Test]
        public void Size_ReturnsNumberOfNodes()
        {
            // Arrange
            var firstNode = CreateNode();
            var secondNode = CreateNode();
            var thirdNode = CreateNode();
            firstNode.AddAfter(secondNode);
            secondNode.AddAfter(thirdNode);

            // Act
            var result = secondNode.Size();

            // Assert
            result.Should().Be(3);
        }

        [Test]
        public void Remove_WithNextNode_RemovesNode()
        {
            // Arrange
            var firstNode = CreateNode();
            var secondNode = CreateNode();
            var thirdNode = CreateNode();
            firstNode.AddAfter(secondNode);
            secondNode.AddAfter(thirdNode);

            // Act
            secondNode.Remove();

            // Assert
            secondNode.HasNext().Should().BeFalse();
            secondNode.HasPrevious().Should().BeFalse();
            secondNode.Next.Should().BeNull();
            firstNode.Next.Should().Be(thirdNode);
            thirdNode.Previous.Should().Be(firstNode);
        }

        #region Helper Methods
        
        private static Node<string> CreateNode(string element = "")
        {
            var head = new Node<string> { Element = element };
            return head;
        }

        #endregion
    }
}