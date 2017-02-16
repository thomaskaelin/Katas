using System.Collections.Generic;
using System.Linq;

namespace Patterns.Composite
{
    public class MultComposite : IMathOperation
    {
        private readonly List<IMathOperation> _mathOperations;

        public MultComposite(List<IMathOperation> mathOperations)
        {
            _mathOperations = mathOperations;
        }

        public int Calculate()
        {
            return _mathOperations.Select(op => op.Calculate()).Aggregate(1, (a, b) => a*b);
        }
    }
}