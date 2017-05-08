namespace KataSmells.Example4Refactored
{
    public interface IMovie
    {
        string Title { get; }
        double GetCharge(int daysRented);
        int GetExtraFrequentRenterPoints(int daysRented);
    }
}