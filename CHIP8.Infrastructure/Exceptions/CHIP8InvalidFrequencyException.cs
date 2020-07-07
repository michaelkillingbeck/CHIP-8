using System;

namespace CHIP8.Infrastructure.Exceptions
{
    public class CHIP8InvalidFrequencyException : ArgumentException
    {
        private readonly ArgumentException _localException;

        public CHIP8InvalidFrequencyException(Int16 requestedFrequency)
        {
            _localException = new ArgumentException(
                $"The requested frequency of {requestedFrequency} is not valid. Frequency must be greater than 1."
            );
        }
    }
}