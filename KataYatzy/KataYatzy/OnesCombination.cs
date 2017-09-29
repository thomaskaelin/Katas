using System.Linq;

namespace KataYatzy
{
    public class OnesCombination : Combination
    {
        public OnesCombination() : base(CombinationType.Ones)
        {
        }

        public override IPoints Calculate(IToss toss)
        {
            var value = toss.Dices.Count((dice) => dice.Value == 1);
            return new Points(value);
        }
    }
}