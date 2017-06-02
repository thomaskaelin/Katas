namespace KataSmells.Example4Refactored
{
    public class Movie : IMovie
    {
        private readonly IMovieState _movieState;

        public Movie(string title, IMovieState movieState)
        {
            Title = title;
            _movieState = movieState;
        }

        public string Title { get; }
        
        public double GetCharge(int daysRented)
        {
            return _movieState.GetCharge(daysRented);
        }

        public int GetExtraFrequentRenterPoints(int daysRented)
        {
            return _movieState.GetExtraFrequentRenterPoints(daysRented);
        }
    }
}
