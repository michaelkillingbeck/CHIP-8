using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8Memory
    {
        Byte GetValueAtLocation(UInt16 location);
        void LoadROM(Byte[] romBytes);
        void SetValueAtLocation(UInt16 location, Byte value);
    }
}
