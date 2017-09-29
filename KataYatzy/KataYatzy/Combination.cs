namespace KataYatzy
{
    public abstract class Combination : ICombination
    {
        protected Combination(CombinationType type)
        {
            Type = type;
        }
        public CombinationType Type { get; }
        public abstract IPoints Calculate(IToss toss);
    }
}