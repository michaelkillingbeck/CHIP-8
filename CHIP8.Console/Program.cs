using CHIP8.Core;
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
                InstructionRegister = new InMemoryImplementation.CHIP8InstructionRegister(),
                KeyManager = new CHIP8ConsoleKeyManager(),
                Memory = new InMemoryImplementation.CHIP8Memory(),
                ProgramCounter = new InMemoryImplementation.CHIP8ProgramCounterRegister(),
                Registers = new InMemoryImplementation.CHIP8GeneralPurposeRegisters(),
                Screen = new InMemoryImplementation.CHIP8ScreenBuffer(),
                SoundTimer = new InMemoryImplementation.CHIP8SoundTimer(),
                StackPointer = new InMemoryImplementation.CHIP8StackPointer()
            };
            Core.CHIP8 chip8 = new Core.CHIP8(new CHIP8OpCodesDirector(), config);
            Byte[] romBytes = File.ReadAllBytes(@"C:\Code\CHIP-8\CHIP8ROMs\BRIX");
            chip8.LoadROM(romBytes);

            Int32 tickCounter = 0;

            while (true)
            {
                chip8.Tick();
                tickCounter++;

                if(tickCounter % 100 == 0)
                    System.Console.WriteLine($"{tickCounter} ticks.");
            }
        }
    }
}
