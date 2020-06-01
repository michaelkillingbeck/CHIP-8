using System;

namespace CHIP8.Infrastructure.Abstracts
{
    public abstract class CHIP8OpCode
    {
        protected Byte _localCode;

        public Byte GetCode()
        {
            return _localCode;
        }

        public abstract void Execute(OpCodeData opCodeData);
    }
}
