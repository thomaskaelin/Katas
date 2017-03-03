using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Proxy;

namespace Patterns.Test.Proxy
{
    [TestFixture]
    public class CachingProxyFixture
    {
        private CachingProxy _testee;
        private ICalculator _fakeCalculator;

        [SetUp]
        public void SetUp()
        {
            _fakeCalculator = A.Fake<ICalculator>();
            A.CallTo(() => _fakeCalculator.Calculate()).Returns(1);
            _testee = new CachingProxy(_fakeCalculator);
        }

        [Test]
        public void Calculate_ReturnsExpectedResult()
        {
            // Act
            var result = _testee.Calculate();

            // Assert
            result.Should().Be(1);
        }

        [Test]
        public void CalculateTwice_ReturnsCachedValue()
        {
            // Act
            _testee.Calculate();
            _testee.Calculate();

            // Assert
            A.CallTo(() => _fakeCalculator.Calculate()).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}