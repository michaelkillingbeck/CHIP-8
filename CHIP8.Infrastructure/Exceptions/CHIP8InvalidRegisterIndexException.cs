using System;

namespace CHIP8.Infrastructure.Exceptions
{
    public class CHIP8InvalidRegisterIndexException : ArgumentException
    {
        private readonly ArgumentException _localException;

        public CHIP8InvalidRegisterIndexException(Byte registerIndex, Byte maxNumberOfRegisters, String parameterName)
        {
            _localException = new ArgumentException(
                    $"Attempted to access Register {registerIndex}, " +
                        $"but only {maxNumberOfRegisters} exist.",
                    parameterName);
        }
    }
}
