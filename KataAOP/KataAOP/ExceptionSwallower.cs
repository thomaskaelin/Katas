using System;
using SwallowExceptions.Fody;

namespace KataAOP
{
    public class ExceptionSwallower
    {
        public void ThrowException()
        {
            throw new ArgumentNullException();
        }

        [SwallowExceptions]
        public void ThrowExceptionWithAttribute()
        {
            ThrowException();
        }
    }
}
