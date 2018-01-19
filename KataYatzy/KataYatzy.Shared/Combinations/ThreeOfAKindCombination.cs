using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations.Helper;

namespace KataYatzy.Shared.Combinations
{
    public class ThreeOfAKindCombination : Combination
    {
        public ThreeOfAKindCombination() : base(CombinationType.ThreeOfAKind)
        {
        }

        #region Overrides

        protected override int Calculate(TossAnalyzer tossAnalyzer)
        {
            return tossAnalyzer.AnyDiceValueOccursAtLeastXTimes(3) ? tossAnalyzer.SumOfAllDiceValues() : 0;
        }

        #endregion
    }
}