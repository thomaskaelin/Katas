namespace Random
{
    public class DiceRollerAndPrinter
    {
        private readonly RolledNumberGenerator _generator;
        private readonly RolledNumberToResultStringConverter _converter;
        private readonly RolledResultStringPrinter _printer;

        public DiceRollerAndPrinter(
            RolledNumberGenerator generator, 
            RolledNumberToResultStringConverter converter,
            RolledResultStringPrinter printer)
        {
            _generator = generator;
            _converter = converter;
            _printer = printer;
        }

        public void RollAndPrint()
        {
            var rolledNumber = _generator.Roll();
            var resultString = _converter.Convert(rolledNumber);
            _printer.Print(resultString);
        }
    }
}
