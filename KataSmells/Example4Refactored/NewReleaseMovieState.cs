namespace KataSmells.Example4Refactored
{
    public class NewReleaseMovieState : IMovieState
    {
        public double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public int GetExtraFrequentRenterPoints(int daysRented)
        {
            if (daysRented > 1)
                return 1;
            return 0;
        }
    }
}