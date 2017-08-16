using FluentAssertions;
using NUnit.Framework;

namespace KataDatastructures.Test.Queue
{
    public class QueueFixture
    {
        private KataDatastructures.Queue.Queue<string> _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new KataDatastructures.Queue.Queue<string>();
        }

        [Test]
        public void Enqueue_AddsItemAtEndOfQueue()
        {
            // Arrange
            _testee.Enqueue("1");
            _testee.Enqueue("2");

            // Act
            _testee.Enqueue("3");

            // Assert

            _testee.Dequeue();
            _testee.Dequeue();
            
            var result = _testee.Dequeue();
            
            result.Should().Be("3");
        }

        [Test]
        public void Front_WithNonEmptyList_ReturnsFirstElement()
        {
            // Arrange
            _testee.Enqueue("1");
            _testee.Enqueue("2");

            // Act
            var result = _testee.Front();

            // Assert
            result.Should().Be("1");
        }

        [Test]
        public void Front_WithEmptyList_ReturnsNull()
        {
            // Act
            var result = _testee.Front();

            // Assert
            result.Should().BeNullOrEmpty();
        }
    }
}