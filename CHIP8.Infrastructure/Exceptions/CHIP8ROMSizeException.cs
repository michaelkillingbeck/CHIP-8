using System;

namespace CHIP8.Infrastructure.Exceptions
{
    public class CHIP8ROMSizeException : ArgumentException
    {
        private readonly ArgumentException _localException;

        public CHIP8ROMSizeException(Byte[] romBytes, UInt16 maximumAllowedSize, String parameterName)
        {
            _localException = new ArgumentException(
                    $"The supplied ROM is {romBytes.Length} bytes, " +
                        $"which is larger than the maximum allowed size of {maximumAllowedSize}.",
                    parameterName);
        }
    }
}
