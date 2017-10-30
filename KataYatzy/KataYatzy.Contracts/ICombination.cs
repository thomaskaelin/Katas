namespace KataYatzy.Contracts
{
    public interface ICombination
    {
        CombinationType Type { get; }

        IPoints Calculate(IToss toss);
    }
}