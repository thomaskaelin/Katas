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
            double amount = 0;
            switch (Movie.PriceCode)
            {
                case Example4Refactored.Movie.REGULAR:
                    amount += 2;
                    if (DaysRented > 2)
                        amount += (DaysRented - 2) * 1.5;
                    break;

                case Example4Refactored.Movie.NEW_RELEASE:
                    amount += DaysRented * 3;
                    break;

                case Example4Refactored.Movie.CHILDREN:
                    amount += 1.5;
                    if (DaysRented > 3)
                        amount += (DaysRented - 3) * 1.5;
                    break;
            }
            return amount;
        }
    }
}
