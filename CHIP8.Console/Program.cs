using CHIP8.Infrastructure;
using System;
using System.IO;

namespace CHIP8.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CHIP8Configuration config = new CHIP8Configuration
            {
                DelayTimer = new InMemoryImplementation.CHIP8DelayTimer(),
                Memory = new InMemoryImplementation.CHIP8Memory(),
                ProgramCounter = new InMemoryImplementation.CHIP8ProgramCounterRegister(),
                Registers = new InMemoryImplementation.CHIP8GeneralPurposeRegisters(),
                SoundTimer = new InMemoryImplementation.CHIP8SoundTimer(),
                StackPointer = new InMemoryImplementation.CHIP8StackPointer()
            };
            Core.CHIP8 chip8 = new Core.CHIP8(config);
            Byte[] romBytes = File.ReadAllBytes(@"C:\Code\CHIP-8\CHIP8ROMs\BRIX");
            chip8.LoadROM(romBytes);
            chip8.Tick();
        }
    }
}
