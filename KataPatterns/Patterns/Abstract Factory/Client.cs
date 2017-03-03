using System.Collections.Generic;

namespace Patterns.Abstract_Factory
{
    public class Client
    {
        public List<string> DoSomething(IFactory factory)
        {
            var sorter = factory.CreateSortStrategy();
            var modifier = factory.CreateModifierStrategy();

            var list = new List<string> {"Y", "Z", "X"};

            var sortedList = sorter.Sort(list);
            var modifiedList = modifier.Modify(sortedList);

            return modifiedList;

        }
    }
}