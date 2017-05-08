namespace KataSmells.Example4Refactored
{
    public class RegularMovieState : IMovieState
    {
        public double GetCharge(int daysRented)
        {
            double amount = 2;
            if (daysRented > 2)
                amount += (daysRented - 2) * 1.5;
            return amount;
        }

        public int GetExtraFrequentRenterPoints(int daysRented)
        {
            return 0;
        }
    }
}