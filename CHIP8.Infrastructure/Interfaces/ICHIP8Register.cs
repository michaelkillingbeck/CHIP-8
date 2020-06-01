using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8Register
    {
        Byte GetRegisterValue(Byte registerIndex);

        void SetRegisterValue(Byte registerIndex, Byte value);
    }
}
