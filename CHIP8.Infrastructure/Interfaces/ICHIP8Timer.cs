using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8Timer
    {
        void DecrementTimer();
        Byte GetValue();
        void SetTimer(Byte value);
    }
}