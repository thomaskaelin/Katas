using System.Threading;

namespace Random
{
    public class LongRunningOperation
    {
        public virtual void DoSomething()
        {
            Thread.Sleep(5000);
        }
    }
}