namespace KataSmells.Example4Refactored
{
    public class ChildrenState : IMovieState
    {
        public double GetCharge(int daysRented)
        {
            double amount = 1.5;
            if (daysRented > 3)
                amount += (daysRented - 3) * 1.5;
            return amount;
        }
    }
}