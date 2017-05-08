namespace KataSmells.Example4Refactored
{
    public class Movie : IMovie
    {
        public const int CHILDREN = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private IMovieState _movieState;
        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
            switch (PriceCode)
            {
                case NEW_RELEASE:
                    _movieState = new NewReleaseState();
                    break;
                case CHILDREN:
                    _movieState = new ChildrenState();
                    break;
                default:
                    _movieState = new RegularState();
                    break;
            }
        }

        public string Title { get; private set; }

        public int PriceCode { get; set; }

        public double GetCharge(int daysRented)
        {
            return _movieState.GetCharge(daysRented);
        }

        public int GetExtraFrequentRenterPoints(int daysRented)
        {
            if (PriceCode == NEW_RELEASE && daysRented > 1)
                return 1;
            return 0;
        }
    }
}
