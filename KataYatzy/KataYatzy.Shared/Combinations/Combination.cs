using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations.Helper;

namespace KataYatzy.Shared.Combinations
{
    public abstract class Combination : ICombination
    {
        protected Combination(CombinationType type)
        {
            Type = type;
        }

        #region ICombination

        public CombinationType Type { get; }

        public IPoints Calculate(IToss toss)
        {
            var tossAnalyzer = new TossAnalyzer(toss);
            var pointsAsInt = Calculate(tossAnalyzer);
            var pointsAsPoints = new Points(pointsAsInt);

            return pointsAsPoints;
        }

        #endregion

        #region Protected Methods

        protected abstract int Calculate(TossAnalyzer tossAnalyzer);

        #endregion
    }
}