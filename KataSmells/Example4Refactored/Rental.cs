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
            var frequentRenterPoints = 1;
            
            if (Movie.PriceCode == Example4Refactored.Movie.NEW_RELEASE && DaysRented > 1)
                frequentRenterPoints++;

            return frequentRenterPoints;
        }
    }
}
