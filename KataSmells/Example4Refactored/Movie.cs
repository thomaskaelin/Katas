﻿namespace KataSmells.Example4Refactored
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
    }
}
