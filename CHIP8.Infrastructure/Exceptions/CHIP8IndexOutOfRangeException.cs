using System;

namespace CHIP8.Infrastructure.Exceptions
{
    public class CHIP8IndexOutOfRangeException : Exception
    {
        private readonly IndexOutOfRangeException _localException;

        public CHIP8IndexOutOfRangeException(Byte currentIndex)
        {
            _localException = new IndexOutOfRangeException($"The Index of {currentIndex} is not valid.");
        }
    }
}
