namespace KataSmells.Example4Refactored
{
    public interface IRental
    {
        int DaysRented { get; }
        IMovie Movie { get; }
    }
}