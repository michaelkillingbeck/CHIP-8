using System;

namespace CHIP8.OpCodes
{
    public abstract class CHIP8OpCode
    {
        public abstract Byte GetCode();

        public abstract void Execute(OpCodeData opCodeData);
    }
}
