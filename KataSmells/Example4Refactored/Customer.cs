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
                var amount = rental.GetAmountForRental();
                var points = rental.GetFrequentRenterPoints();
                
                frequentRenterPoints+= points;
                
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