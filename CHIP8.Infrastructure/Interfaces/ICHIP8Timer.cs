using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8Timer
    {
        void DecrementTimer();
        void SetTimer(Byte value);
    }
}
