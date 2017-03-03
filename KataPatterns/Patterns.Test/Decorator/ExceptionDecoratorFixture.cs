using System;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Decorator;

namespace Patterns.Test.Decorator
{
    [TestFixture]
    public class ExceptionDecoratorFixture
    {
        private ExceptionDecorator _testee;
        private ICalculator _fakeCalculator;

        [SetUp]
        public void SetUp()
        {
            _fakeCalculator = A.Fake<ICalculator>();
            
            _testee = new ExceptionDecorator(_fakeCalculator);
        }

        [Test]
        public void Divide_DelegatesToCalculator()
        {
            // Arrange
            const int value1 = 10;
            const int value2 = 2;
            const float expectedResult = 5;

            A.CallTo(() => _fakeCalculator.Divide(value1, value2)).Returns(expectedResult);

            // Act
            var result = _testee.Divide(value1, value2);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void Divide_WithException_ReturnsExpectedResult()
        {
            // Arrange
            var value1 = 10;
            var value2 = 0;
            A.CallTo(() => _fakeCalculator.Divide(value1, value2)).Throws<DivideByZeroException>();

            // Act
            var result = _testee.Divide(value1, value2);

            // Assert
            result.Should().Be(ExceptionDecorator.DivideByZeroResult);

        }
    }
}