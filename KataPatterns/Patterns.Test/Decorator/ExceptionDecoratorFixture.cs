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
            var value1 = 10;
            var value2 = 2;
         
            // Act
            _testee.Divide(value1, value2);

            // Assert
            A.CallTo(() => _fakeCalculator.Divide(value1, value2)).MustHaveHappened();
        }
    }
}