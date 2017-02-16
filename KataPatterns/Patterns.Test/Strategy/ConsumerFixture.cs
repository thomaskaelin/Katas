using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Strategy;

namespace Patterns.Test.Strategy
{
    [TestFixture]
    public class ConsumerFixture
    {
        private Consumer _testee;
        private ISortStrategy _fakeSortStrategy;

        [SetUp]
        public void SetUp()
        {
            _fakeSortStrategy = A.Fake<ISortStrategy>();
            _testee = new Consumer(_fakeSortStrategy);
        }

        [Test]
        public void Consume_CallsSort_WithCorrectParameters()
        {
            // Arrange
            var expectedList = new List<string> { "B", "A", "C" };

            A.CallTo(() => _fakeSortStrategy.Sort(A<List<string>>.Ignored)).Invokes((List<string> unsortedList) =>
            {
                // Check parameter values
                unsortedList.Should().BeEquivalentTo(expectedList);

                // Modify parameter value for checking result
                unsortedList.Clear();
                unsortedList.Add("Z");
            });

            // Act
            var result =_testee.Consume();

            // Assert
            result.Count.Should().Be(1);
            result.First().Should().Be("Z");
        }
    }
}