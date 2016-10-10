using System.Linq;

namespace Random
{
    public class DiceRoller
    {
        private readonly Dice _dice;
        private readonly LongRunningOperation _longRunningOperation;
        private readonly RandomNumberGenerator _randomNumberGenerator;

        public DiceRoller(Dice dice, LongRunningOperation longRunningOperation, RandomNumberGenerator randomNumberGenerator)
        {
            _dice = dice;
            _longRunningOperation = longRunningOperation;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public virtual int Roll()
        {
            _longRunningOperation.DoSomething();

            var numberOfDiceValues = _dice.Values.Count();
            var randomIndex = _randomNumberGenerator.GetRandomNumber(numberOfDiceValues);
            var rolledDiceValue = _dice.Values.ToArray()[randomIndex];

            return rolledDiceValue;
        }
    }
}