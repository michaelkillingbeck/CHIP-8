using System;

namespace CHIP8.Infrastructure.Exceptions
{
    public class CHIP8InvalidMemoryLocationException : ArgumentOutOfRangeException
    {
        private readonly ArgumentOutOfRangeException _localException;

        public CHIP8InvalidMemoryLocationException(String parameterName, UInt16 requestedLocation, UInt16 maximumMemorySize)
        {
            _localException = new ArgumentOutOfRangeException(parameterName,
                $"Attempted to access Memory at location {requestedLocation}, " +
                $"but the maximum addressable memory is {maximumMemorySize}.");
        }
    }
}
