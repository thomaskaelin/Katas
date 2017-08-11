using KataDatastructures.List;
using NUnit.Framework;

namespace KataDatastructures.Test.List
{
    [TestFixture]
    public class ListWithArrayFixture : ListBaseFixture
    {
        protected override IList<string> CreateTestee()
        {
            return new ListWithArray<string>();
        }
    }
}