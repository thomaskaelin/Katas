namespace Random
{
    public class DiceValueToResultStringConverter
    {
        private readonly DiceValueToResultStringMapping _mapping;

        public DiceValueToResultStringConverter(DiceValueToResultStringMapping mapping)
        {
            _mapping = mapping;
        }

        public virtual string Convert(int diceValue)
        {
            if (_mapping.HasMapping(diceValue))
            {
                return _mapping.GetResultString(diceValue);
            }

            throw new InvalidDiceValueException();            
        }
    }
}