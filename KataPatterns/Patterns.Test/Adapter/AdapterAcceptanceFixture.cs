using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Patterns.Adapter;

namespace Patterns.Test.Adapter
{
    [TestFixture]
    public class AdapterAcceptanceFixture
    {
        [Test]
        public void DoSomething_AcceptanceTest()
        {
            // Arrange
            var sortStrategy = new NewSortStrategy();
            var client = new Client(sortStrategy);

            // Act
            var result = client.DoSomething();

            // Assert
            var expectedList = new List<string> { "A", "B", "C" };
            result.Should().BeEquivalentTo(expectedList);
        }
        
    }
}