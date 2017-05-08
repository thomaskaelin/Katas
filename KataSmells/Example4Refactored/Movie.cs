namespace KataSmells.Example4Refactored
{
    public class Movie : IMovie
    {
        public const int CHILDREN = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public string Title { get; private set; }

        public int PriceCode { get; set; }

        public double GetCharge(int daysRented)
        {
            double amount = 0;
            switch (PriceCode)
            {
                case REGULAR:
                    amount += 2;
                    if (daysRented > 2)
                        amount += (daysRented - 2) * 1.5;
                    break;

                case NEW_RELEASE:
                    amount += daysRented * 3;
                    break;

                case CHILDREN:
                    amount += 1.5;
                    if (daysRented > 3)
                        amount += (daysRented - 3) * 1.5;
                    break;
            }
            return amount;
        }
    }
}
