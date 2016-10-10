namespace Random
{
    public class DiceRollerAndPrinter
    {
        private readonly DiceRoller _roller;
        private readonly DiceValueToResultStringConverter _converter;
        private readonly ResultStringPrinter _printer;

        public DiceRollerAndPrinter(DiceRoller roller, DiceValueToResultStringConverter converter, ResultStringPrinter printer)
        {
            _roller = roller;
            _converter = converter;
            _printer = printer;
        }

        public void RollAndPrint()
        {
            var rolledValue = _roller.Roll();
            var resultString = _converter.Convert(rolledValue);
            _printer.Print(resultString);
        }
    }
}