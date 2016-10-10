namespace Random.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mapping = CreateMapping();
            var dice = CreateDice(mapping);
            var roller = CreateRoller(dice);
            var converter = CreateConverter(mapping);
            var printer = CreatePrinter();
            var diceRollerAndPrinter = new DiceRollerAndPrinter(roller, converter, printer);

            diceRollerAndPrinter.RollAndPrint();

            System.Console.ReadKey();
        }

        private static DiceValueToResultStringMapping CreateMapping()
        {
            var mapping = new DiceValueToResultStringMapping();

            mapping.AddMapping(1, "Oh no! You got a 1. :-(");
            mapping.AddMapping(2, "Try harder! You only got a 2.");
            mapping.AddMapping(3, "You are below average! You got a 3.");
            mapping.AddMapping(4, "You are above average! You got a 4.");
            mapping.AddMapping(5, "Nice one! You got a 5.");
            mapping.AddMapping(6, "Awesome roll! You got a 6. :-)");

            return mapping;
        }

        private static Dice CreateDice(DiceValueToResultStringMapping mapping)
        {
            return new Dice(mapping.DiceValues);
        }

        private static DiceRoller CreateRoller(Dice dice)
        {
            var longRunningOperation = new LongRunningOperation();
            var randomNumberGenerator = new RandomNumberGenerator();

            return new DiceRoller(dice, longRunningOperation, randomNumberGenerator);
        }

        private static DiceValueToResultStringConverter CreateConverter(DiceValueToResultStringMapping mapping)
        {
            return new DiceValueToResultStringConverter(mapping);
        }

        private static ResultStringPrinter CreatePrinter()
        {
            return new ResultStringPrinter();
        }
    }
}
