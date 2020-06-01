using System;
using CHIP8.Infrastructure.Exceptions;
using CHIP8.Infrastructure.Interfaces;

namespace CHIP8.InMemoryImplementation
{
    public class CHIP8Memory : ICHIP8Memory
    {
        private const UInt16 MAX_ROM_SIZE = 0xE00;
        private const UInt16 MEMORY_SIZE = 0x1000;
        private const UInt16 ROM_MEMORY_START = 0x200;

        private readonly Byte[] _localMemory;

        public CHIP8Memory()
        {
            _localMemory = new Byte[MEMORY_SIZE];
        }

        public Byte GetValueAtLocation(UInt16 location)
        {
            if (location >= MEMORY_SIZE)
                throw new CHIP8InvalidMemoryLocationException(nameof(location), location, MEMORY_SIZE);

            return _localMemory[location];
        }

        public void LoadROM(Byte[] romBytes)
        {
            if (romBytes.Length > MAX_ROM_SIZE)
                throw new CHIP8ROMSizeException(romBytes, MAX_ROM_SIZE, nameof(romBytes));

            Array.Copy(romBytes, 0, _localMemory, ROM_MEMORY_START, romBytes.Length);
        }
    }
}
