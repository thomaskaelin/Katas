using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations.Helper;

namespace KataYatzy.Shared.Combinations
{
    public class SmallStraightCombination : Combination
    {
        public SmallStraightCombination() : base(CombinationType.SmallStraight)
        {
        }

        protected override int Calculate(TossAnalyzer tossAnalyzer)
        {
            return tossAnalyzer.AreThereXDiceValuesInSequence(4) ? 30 : 0;
        }
    }
}