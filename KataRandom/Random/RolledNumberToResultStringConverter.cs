namespace Random
{
    public class RolledNumberToResultStringConverter
    {
        private readonly DiceValueToStringResultMapping _mapping;

        public RolledNumberToResultStringConverter(DiceValueToStringResultMapping mapping)
        {
            _mapping = mapping;
        }

        public virtual string Convert(int rolledNumber)
        {
            if (_mapping.HasMapping(rolledNumber))
            {
                return _mapping.GetStringResult(rolledNumber);
            }

            throw new InvalidNumberException();
            
        }
    }
}