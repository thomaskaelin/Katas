using System.Collections.Generic;
using System.Xml.Xsl;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Adapter;

namespace Patterns.Test.Adapter
{
    [TestFixture]
    public class NewSortStrategyFixture
    {
        private NewSortStrategy _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new NewSortStrategy();
        }
        
        [Test]
        public void Sort_ReturnsExpectedList()
        {
            // Arrange
            var unsortedList = new List<string> { "B", "C", "A" };

            // Act
            var result = _testee.Sort(unsortedList);

            // Assert
            var sortedList = new List<string> { "A", "B", "C" };
            result.Should().BeEquivalentTo(sortedList);
        }

        [Test]
        public void Sort_CallsSortOnSortStrategy()
        {
            // Arrange
            var unsortedList = new List<string> { "B", "C", "A" };
            var fakeSort = A.Fake<ISortStrategy>();
            A.CallTo(() => fakeSort.Sort(A<List<string>>.Ignored)).Invokes((List<string> input) =>
            {
                // Assert
                var expectedList = new List<string> { "A", "B", "C" };
                input.Should().BeEquivalentTo(expectedList);
            });
            // Act
            _testee.Sort(unsortedList);

            // Assert
            A.CallTo(() => fakeSort.Sort(A<List<string>>.Ignored)).MustHaveHappened();
        }
    }
}