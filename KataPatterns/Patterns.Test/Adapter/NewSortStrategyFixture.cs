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
        private ISortStrategy _fakeSortStrategy;

        [SetUp]
        public void SetUp()
        {
            _fakeSortStrategy = A.Fake<ISortStrategy>();
            _testee = new NewSortStrategy(_fakeSortStrategy);
        }

        [Test]
        public void Sort_CallsSortOnSortStrategy()
        {
            // Arrange
            var unsortedList = new List<string> { "B", "C", "A" };
            A.CallTo(() => _fakeSortStrategy.Sort(A<List<string>>.Ignored)).Invokes((List<string> input) =>
            {
                // Assert
                input.Should().BeEquivalentTo(unsortedList);
                input.Add("D");
            });

            // Act
            var result = _testee.Sort(unsortedList);

            // Assert
            var modifiedList = new List<string> { "B", "C", "A", "D" };
            result.Should().BeEquivalentTo(modifiedList);
            result.Should().NotBeSameAs(unsortedList);
        }
    }
}