using System;

namespace CHIP8.Infrastructure.Exceptions
{
    public class CHIP8StackOverflowException : Exception
    {
        private readonly StackOverflowException _localException;

        public CHIP8StackOverflowException(Byte maxStackSize)
        {
            _localException = new StackOverflowException(
                $"Maximum Stack level reached. The maximum level is currently {maxStackSize}.");
        }
    }
}
