using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Patterns.Observer;

namespace Patterns.Test.Observer
{
    [TestFixture]
    public class ObserverFixture
    {
        private Patterns.Observer.Observer _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Patterns.Observer.Observer();
        }

        [Test]
        public void Update_UpdatesValue()
        {
            // Act
            _testee.Update();
        }
    }
}