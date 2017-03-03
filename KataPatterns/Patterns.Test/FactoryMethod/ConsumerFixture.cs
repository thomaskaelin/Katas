using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Patterns.FactoryMethod;

namespace Patterns.Test.FactoryMethod
{
    [TestFixture]
    public class ConsumerFixture
    {
        private TestConsumer _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new TestConsumer();
        }

        [Test]
        public void Consume_CreatesSortStrategyAndUsesIt()
        {
            // Arrange
            A.CallTo(() => _testee.FakeSortStrategy.Sort(A<List<string>>.Ignored)).Invokes((List<string> input) =>
            {
                // Assert
                var expectedList = new List<string> { "B", "A", "C" };
                input.Should().BeEquivalentTo(expectedList);
                input.Clear();
                input.Add("D");
            });
            
            // Act
            var result = _testee.Consume();

            // Assert
            var expectedResultList = new List<string> { "D" };
            result.Should().BeEquivalentTo(expectedResultList);
        }

        private class TestConsumer : Consumer
        {
            public TestConsumer()
            {

                FakeSortStrategy = A.Fake<ISortStrategy>();
            }

            public ISortStrategy FakeSortStrategy { get; private set; }

            public override ISortStrategy CreateSortStrategy()
            {
                return FakeSortStrategy;
            }
        }
        
    }
}