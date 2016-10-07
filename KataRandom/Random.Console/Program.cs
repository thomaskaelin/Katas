namespace Random.Console
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var mapping = new DiceValueToStringResultMapping();
            mapping.AddMapping(1, "Oh no! You got a 1. :-(");
            mapping.AddMapping(2, "Try harder! You only got a 2.");
            mapping.AddMapping(3, "You are below average! You got a 3.");
            mapping.AddMapping(4, "You are above average! You got a 4.");
            mapping.AddMapping(5, "Nice one! You got a 5.");
            mapping.AddMapping(6, "Awesome roll! You got a 6. :-)");

            var dice = new Dice(mapping.Values);
            var indexGenerator = new RandomIndexGenerator();
            var longRunningOperation = new LongRunningOperation();
            var generator = new RolledNumberGenerator(dice, longRunningOperation, indexGenerator);
            var stringConverter = new RolledNumberToResultStringConverter(mapping);
            var stringPrint = new RolledResultStringPrinter();
            
            var diceRollerAndPrinter = new DiceRollerAndPrinter(generator, stringConverter, stringPrint);
            diceRollerAndPrinter.RollAndPrint();

            System.Console.ReadKey();
        }
    }
}
