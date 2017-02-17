using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Composite;

namespace Patterns.Test.Composite
{
   [TestFixture] 
    public class AddCompositeFixture
    {
        private AddComposite _testee;
        private List<IMathOperation> _mathOperationList;

        [SetUp]
        public void SetUp()
        {
            _mathOperationList = new List<IMathOperation>();
            _testee = new AddComposite(_mathOperationList);
        }

        [Test]
        public void Calculate_ReturnsExpectedResult()
        {
            // Arrange
            var fakeNumber10 = A.Fake<IMathOperation>();
            A.CallTo(() =>fakeNumber10.Calculate()).Returns(10);

            var fakeNumber20 = A.Fake<IMathOperation>();
            A.CallTo(() => fakeNumber20.Calculate()).Returns(20);
            
            _mathOperationList.Add(fakeNumber10);
            _mathOperationList.Add(fakeNumber20);

            // Act
            var result = _testee.Calculate();

            // Assert
            result.Should().Be(30);
        }
    }
}
