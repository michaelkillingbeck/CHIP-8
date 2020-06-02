using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8
    {
        void DisplayTick();

        void LoadROM(Byte[] romBytes);

        void Tick();
    }
}
