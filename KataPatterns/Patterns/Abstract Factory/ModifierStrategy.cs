using System.Collections.Generic;

namespace Patterns.Abstract_Factory
{
    public class ModifierStrategy : IModifierStrategy
    {
        public List<string> Modify(List<string> list)
        {
            var newList = new List<string>();
            foreach (var item in list)
            {
                newList.Add(item);
                newList.Add(item);
            }
            return newList;
        }
    }
}