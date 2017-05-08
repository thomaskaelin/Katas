namespace KataSmells.Example4Refactored
{
    public interface IMovieState
    {
        double GetCharge(int daysRented);

        int GetExtraFrequentRenterPoints(int daysRented);
    }
}