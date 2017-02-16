using FluentAssertions;
using NUnit.Framework;
using Patterns.Proxy;

namespace Patterns.Test.Proxy
{
    [TestFixture]
    public class ProxyAcceptanceFixture
    {
        [Test]
        public void CachingAcceptanceTest()
        {
            // Arrange
            var longRunningCalculator = new LongRunningCalculator();
            var cachingProxy = new CachingProxy(longRunningCalculator);

            // Act
            var result1 = cachingProxy.Calculate();
            var result2 = cachingProxy.Calculate();
            var result3 = cachingProxy.Calculate();

            // Assert
            result1.Should().Be(result2);
            result2.Should().Be(result3);

        }

    }
}