using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8
    {
        void LoadROM(Byte[] romBytes);

        void Tick();
    }
}
