namespace Random
{
    public class DiceRollerAndPrinter
    {
        private readonly RolledNumberGenerator _rolledNumberGenerator;
        private readonly RolledNumberToResultStringConverter _rolledNumberToResultStringConverter;
        private readonly RolledResultStringPrinter _rolledResultStringPrinter;


        public DiceRollerAndPrinter(
            RolledNumberGenerator rolledNumberGenerator, 
            RolledNumberToResultStringConverter rolledNumberToResultStringConverter,
            RolledResultStringPrinter rolledResultStringPrinter)
        {
            _rolledNumberGenerator = rolledNumberGenerator;
            _rolledNumberToResultStringConverter = rolledNumberToResultStringConverter;
            _rolledResultStringPrinter = rolledResultStringPrinter;
        }


        public void RollAndPrint()
        {
            var rolledNumber = _rolledNumberGenerator.Roll();
            var resultString = _rolledNumberToResultStringConverter.Convert(rolledNumber);
            _rolledResultStringPrinter.Print(resultString);
        }
    }
}
