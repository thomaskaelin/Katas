using System.Linq;

namespace KataYatzy.Combinations
{
    public class OnesCombination : Combination
    {
        public OnesCombination() : base(CombinationType.Ones)
        {
        }

        #region Overrides

        public override IPoints Calculate(IToss toss)
        {
            var value = toss.Dices.Count((dice) => dice.Value == 1);
            return new Points(value);
        }

        #endregion
    }
}