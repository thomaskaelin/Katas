using System;
using System.Collections.Generic;

namespace KataSmells.Example4Refactored
{
    public class Customer
    {
        private readonly List<IRental> _rentals = new List<IRental>();

        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void AddRental(IRental rental)
        {
            _rentals.Add(rental);
        }

        public string Statement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;

            var result = "Rental record for " + Name + Environment.NewLine;

            foreach (var rental in _rentals)
            {
                double amount = 0;
                switch (rental.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        amount += 2;
                        if (rental.DaysRented > 2)
                            amount += (rental.DaysRented - 2) * 1.5;
                        break;

                    case Movie.NEW_RELEASE:
                        amount += rental.DaysRented * 3;
                        break;

                    case Movie.CHILDREN:
                        amount += 1.5;
                        if (rental.DaysRented > 3)
                            amount += (rental.DaysRented - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;

                // add bonus for a two day new release rental
                if (rental.Movie.PriceCode == Movie.NEW_RELEASE && rental.DaysRented > 1)
                    frequentRenterPoints++;

                // show figures for this rental
                result += "\t" + rental.Movie.Title + "\t" + amount + Environment.NewLine;

                totalAmount += amount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount + Environment.NewLine;
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}