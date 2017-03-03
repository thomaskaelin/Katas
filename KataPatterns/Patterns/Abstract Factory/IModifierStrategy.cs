using System.Collections.Generic;

namespace Patterns.Abstract_Factory
{
    public interface IModifierStrategy
    {
        List<string> Modify(List<string> list);
    }
}