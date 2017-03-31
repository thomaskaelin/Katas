using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Adapter;

namespace Patterns.Test.Adapter
{
    [TestFixture]
    public class ClientFixture
    {
        private Client _testee;
        private INewSortStrategy _fakeSortStrategy;

        [SetUp]
        public void SetUp()
        {
            _fakeSortStrategy = A.Fake<INewSortStrategy>();
            _testee = new Client(_fakeSortStrategy);
        }

        [Test]
        public void DoSomething_CallsSortOnNewSortStrategy()
        {
            // Act
            _testee.DoSomething();

            // Arrange
            A.CallTo(() => _fakeSortStrategy.Sort(A<List<string>>.Ignored)).MustHaveHappened();
        }
    }
}