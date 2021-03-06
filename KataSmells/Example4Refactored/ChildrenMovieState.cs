﻿namespace KataSmells.Example4Refactored
{
    public class ChildrenMovieState : IMovieState
    {
        public double GetCharge(int daysRented)
        {
            double amount = 1.5;
            if (daysRented > 3)
                amount += (daysRented - 3) * 1.5;
            return amount;
        }

        public int GetExtraFrequentRenterPoints(int daysRented)
        {
            return 0;
        }
    }
}