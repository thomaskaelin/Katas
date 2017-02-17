using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Patterns.Proxy;

namespace Patterns.Test.Proxy
{
    [TestFixture]
    public class CachingProxyFixture
    {
        private CachingProxy _testee;

        [SetUp]
        public void SetUp()
        {
            var fakeCalculator = A.Fake<ICalculator>();
            A.CallTo(() => fakeCalculator.Calculate()).Returns(1);
            _testee = new CachingProxy(fakeCalculator);
        }

        [Test]
        public void Calculate_ReturnsExpectedResult()
        {
            // Act
            var result = _testee.Calculate();

            // Assert
            result.Should().Be(1);
        }
    }
}