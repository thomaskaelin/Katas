using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace Random.Test
{
    [TestFixture]
    public class RolledNumberGeneratorTest
    {
        private RolledNumberGenerator _target;
        private Dice _fakeDice;
        private readonly List <int> _values = new List<int> {19, 42, 5};
        private LongRunningOperation _fakeLongRunningOperation;
        private RandomIndexGenerator _fakeRandomIndexGenerator;

        [SetUp]
        public void SetUp()
        {
            _fakeDice = A.Fake<Dice>();
            _fakeLongRunningOperation = A.Fake<LongRunningOperation>();
            _fakeRandomIndexGenerator = A.Fake<RandomIndexGenerator>();

            _target = new RolledNumberGenerator(_fakeDice, _fakeLongRunningOperation, _fakeRandomIndexGenerator);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Roll_ReturnsExpectedResult(int returnedIndex)
        {
            // Arrange
            A.CallTo(() => _fakeDice.Values).Returns(_values);
            A.CallTo(() => _fakeRandomIndexGenerator.GetRandomIndex(A<int>.Ignored)).Returns(returnedIndex);
            A.CallTo(() => _fakeLongRunningOperation.DoSomething()).DoesNothing();
            
            // Act
            var result = _target.Roll();

            // Assert
            var expectedRollNumber = _values[returnedIndex];
            Assert.AreEqual(expectedRollNumber, result);
        }
    }
}