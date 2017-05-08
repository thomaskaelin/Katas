namespace KataSmells.Example4Refactored
{
    public class Rental : IRental
    {
        public Rental(IMovie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public IMovie Movie { get; private set; }

        public int DaysRented { get; private set; }

        public double GetAmountForRental()
        {
            return Movie.GetCharge(DaysRented);
        }

        public int GetFrequentRenterPoints()
        {
            const int basePoints = 1;
            var frequentRenterPoints = basePoints + Movie.GetExtraFrequentRenterPoints(DaysRented);
            
            return frequentRenterPoints;
        }
    }
}
