using KataYatzy.Contracts;

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

        public abstract IPoints Calculate(IToss toss);

        #endregion
    }
}