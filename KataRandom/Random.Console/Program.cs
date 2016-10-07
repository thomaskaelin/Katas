using System.Collections.Generic;

namespace Random.Console
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var values = new List<int> {1, 2, 3, 4, 5, 6};
            var dice = new Dice(values);
            var indexGenerator = new RandomIndexGenerator();
            var longRunningOperation = new LongRunningOperation();
            var generator = new RolledNumberGenerator(dice, longRunningOperation, indexGenerator);
            var stringConverter = new RolledNumberToResultStringConverter();
            var stringPrint = new RolledResultStringPrinter();

            var diceRollerAndPrinter = new DiceRollerAndPrinter(generator, stringConverter, stringPrint);
            diceRollerAndPrinter.RollAndPrint();

            System.Console.ReadKey();
        }
    }
}
