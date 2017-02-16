using System.Threading;

namespace Patterns.Proxy
{
    public class LongRunningCalculator : ICalculator
    {
        public int Calculate()
        {
            Thread.Sleep(1000);
            return 1;
        }
    }
}