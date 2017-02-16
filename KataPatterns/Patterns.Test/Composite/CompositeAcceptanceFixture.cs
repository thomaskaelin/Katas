using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Composite;

namespace Patterns.Test.Composite
{
    [TestFixture]
    public class CompositeAcceptanceFixture
    {
        [Test]
        public void MathOperations_AcceptanceTest()
        {
            // Arrange
            var number10 = new Number(10);
            var number20 = new Number(20);
            var number30 = new Number(30);
            var number40 = new Number(40);
            var number50 = new Number(50);
            var number60 = new Number(60);

            var add20_30 = new AddComposite(new List<IMathOperation> {number20, number30});
            var mult50_60 = new MultComposite(new List<IMathOperation> { number50, number60});

            var add_All = new AddComposite(new List<IMathOperation> {number10, add20_30, number40, mult50_60});

            // Act
            var result = add_All.Calculate();

            // Assert
            result.Should().Be(3100);

        }
    }
}