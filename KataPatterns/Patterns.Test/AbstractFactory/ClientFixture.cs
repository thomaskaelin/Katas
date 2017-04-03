using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using Patterns.Abstract_Factory;

namespace Patterns.Test.AbstractFactory
{
    [TestFixture]
    public class ClientFixture
    {
        private Client _testee;
        private IFactory _fakeFactory;

        [SetUp]
        public void SetUp()
        {
            _testee = new Client();
            _fakeFactory = A.Fake<IFactory>();
        }

        [Test]
        public void DoSomething_CreateStrategies()
        {
            // Act
            _testee.DoSomething(_fakeFactory);

            // Assert
            A.CallTo(() => _fakeFactory.CreateSortStrategy()).MustHaveHappened();
            A.CallTo(() => _fakeFactory.CreateModifierStrategy()).MustHaveHappened();
        }

        [Test]
        public void DoSomething_CallsSortOnSortStrategy()
        {
            // Arrange
            var fakeSortStrategy = A.Fake<ISortStrategy>();
            A.CallTo(() => _fakeFactory.CreateSortStrategy()).Returns(fakeSortStrategy);

            // Act
            _testee.DoSomething(_fakeFactory);

            // Assert
            A.CallTo(() => fakeSortStrategy.Sort(A<List<string>>.Ignored)).MustHaveHappened();
        }
    }
}