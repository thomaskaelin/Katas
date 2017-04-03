using FakeItEasy;
using NUnit.Framework;
using Patterns.Observer;

namespace Patterns.Test.Observer
{
    public abstract class SubjectFixtureBase<TTestee>
        where TTestee : Subject
    {
        protected TTestee Testee { get; private set; }

        [SetUp]
        public void SetUp()
        {
            Testee = CreateTestee();
        }
        
        public abstract TTestee CreateTestee();
        
    }
}