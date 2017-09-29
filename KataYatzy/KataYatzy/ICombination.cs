namespace KataYatzy
{
    public interface ICombination
    {
        CombinationType Type { get; }
        IPoints Calculate(IToss toss);
    }
}