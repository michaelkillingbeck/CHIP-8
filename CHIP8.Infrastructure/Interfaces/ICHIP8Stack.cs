using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8Stack
    {
        UInt16 Pop();
        void Push(UInt16 value);
    }
}
