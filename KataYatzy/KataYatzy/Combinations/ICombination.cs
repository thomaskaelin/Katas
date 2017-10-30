namespace KataYatzy.Combinations
{
    public interface ICombination
    {
        CombinationType Type { get; }

        IPoints Calculate(IToss toss);
    }
}