using System.Linq;

namespace Random
{
    public class RolledNumberGenerator
    {
        private readonly Dice _dice;
        private readonly LongRunningOperation _longRunningOperation;
        private readonly RandomIndexGenerator _randomIndexGenerator;


        public RolledNumberGenerator(Dice dice, LongRunningOperation longRunningOperation, RandomIndexGenerator randomIndexGenerator)
        {
            _dice = dice;
            _longRunningOperation = longRunningOperation;
            _randomIndexGenerator = randomIndexGenerator;
        }

        public virtual int Roll()
        {
            var maxValue = _dice.Values.Count();
            var randomIndex = _randomIndexGenerator.GetRandomIndex(maxValue);
            _longRunningOperation.DoSomething();
            var rolledNumber = _dice.Values.ToArray()[randomIndex];
            return rolledNumber;
        }
    }
}