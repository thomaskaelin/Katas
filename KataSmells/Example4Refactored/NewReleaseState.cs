namespace KataSmells.Example4Refactored
{
    public class NewReleaseState : IMovieState
    {
        public double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }
    }
}