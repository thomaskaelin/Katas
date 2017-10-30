using System.Linq;
using KataYatzy.Contracts;

namespace KataYatzy.Shared.Combinations
{
    public class OnesCombination : Combination
    {
        public OnesCombination() : base(CombinationType.Ones)
        {
        }

        #region Overrides

        public override IPoints Calculate(IToss toss)
        {
            // TODO Diese Methode evtl. auf eine eigene Klasse verschieben (TossAnalyzer) wg. Testing?
            var numberOfOnesInToss = toss.Dices.Count(dice => dice.Value == 1);
            var points = new Points(numberOfOnesInToss);

            return points;
        }

        #endregion
    }
}