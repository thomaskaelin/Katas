using System.Collections.Generic;
using System.Linq;

namespace Patterns.Composite
{
    public class AddComposite : IMathOperation
    {
        private readonly List<IMathOperation> _mathOperations;

        public AddComposite(List<IMathOperation> mathOperations )
        {
            _mathOperations = mathOperations;
        }

        public int Calculate()
        {
            return _mathOperations.Select(op => op.Calculate()).Sum();
        }
    }
}