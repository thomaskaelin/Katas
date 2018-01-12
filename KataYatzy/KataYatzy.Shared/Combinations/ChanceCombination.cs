using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations.Helper;

namespace KataYatzy.Shared.Combinations
{
    public class ChanceCombination : Combination
    {
        public ChanceCombination() : base(CombinationType.Chance)
        {
        }

        protected override int Calculate(TossAnalyzer tossAnalyzer)
        {
            return tossAnalyzer.SumOfAllDiceValues();
        }
    }
}