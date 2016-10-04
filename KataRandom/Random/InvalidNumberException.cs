using System;

namespace Random
{
    public sealed class InvalidNumberException : Exception
    {
        public InvalidNumberException() : base("An invalid number has been generated.")
        {            
        }
    }
}
