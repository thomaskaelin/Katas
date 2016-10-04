using System;
using System.Threading;

namespace Random
{
    public class DiceSimulator
    {
        public void Do()
        {
            var r = new System.Random();
            var rv = r.Next(1, 7);
            Thread.Sleep(5000); // Just here to simulate a long running operation

            switch (rv)
            {
                case 1:
                    Console.WriteLine("Oh no! You got a 1. :-(");
                    break;

                case 2:
                    Console.WriteLine("Try harder! You only got a 2.");
                    break;

                case 3:
                    Console.WriteLine("You are below average! You got a 3.");
                    break;

                case 4:
                    Console.WriteLine("You are above average! You got a 4.");
                    break;

                case 5:
                    Console.WriteLine("Nice one! You got a 5.");
                    break;

                case 6:
                    Console.WriteLine("Awesome throw! You got a 6. :-)");
                    break;

                default:
                    throw new InvalidNumberException();
            }
        }
    }
}
