using System;

namespace Random
{
    public sealed class InvalidDiceValueException : Exception
    {
        public InvalidDiceValueException() : base("An invalid dice value has been generated.")
        {            
        }
    }
}
