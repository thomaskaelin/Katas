using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Abstract_Factory;

namespace Patterns.Test.AbstractFactory
{
    [TestFixture]
    public class AbstractFactoryAcceptanceFixture
    {
        [Test]
        public void DoSomething_AcceptanceFixture()
        {
            // Arrange
            var client = new Client();
            var factory = new Factory();

            // Act
            var result = client.DoSomething(factory);

            // Assert
            var expectedList = new List<string> {"X","X", "Y", "Y", "Z", "Z"};
            result.Should().BeEquivalentTo(expectedList);
        }
    }
}
