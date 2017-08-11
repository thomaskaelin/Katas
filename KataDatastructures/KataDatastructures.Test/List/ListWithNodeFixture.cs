using KataDatastructures.List;

namespace KataDatastructures.Test.List
{
    public class ListWithNodeFixture : ListBaseFixture
    {
        protected override IList<string> CreateTestee()
        {
            return new ListWithNode<string>();
        }
    }
}