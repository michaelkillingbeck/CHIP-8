using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8Stack
    {
        Byte Pop();
        void Push(Byte value);
    }
}
