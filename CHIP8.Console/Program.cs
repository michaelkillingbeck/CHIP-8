using CHIP8.Core;
using CHIP8.Infrastructure;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Timers;

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

            Int32 displayTickCounter = 0;
            UInt16 clockSpeed = 540;
            Byte refreshRate = 60;
            TimeSpan lastClockTick = TimeSpan.FromTicks(0);
            TimeSpan lastDisplayTick = TimeSpan.FromTicks(0);

            Stopwatch clockTimer = Stopwatch.StartNew();
            Stopwatch displayTimer = Stopwatch.StartNew();

            while (true)
            {
                TimeSpan currentClockTime = clockTimer.Elapsed;
                TimeSpan currentDisplayTime = displayTimer.Elapsed;
                TimeSpan elapseClockTime = currentClockTime - lastClockTick;
                TimeSpan elapsedDisplayTime = currentClockTime - lastDisplayTick;

                if (elapseClockTime.TotalMilliseconds > 1000 / clockSpeed)
                {
                    chip8.Tick();
                    lastClockTick = currentClockTime;
                }

                if (elapsedDisplayTime.TotalMilliseconds > (1000 / 60))
                {
                    chip8.DisplayTick();
                    displayTickCounter++;

                    //if(displayTickCounter % 100 == 0)
                    {
                        DrawScreen(chip8.GetScreenBuffer());
                    }

                    lastDisplayTick = currentDisplayTime;
                }
            }
        }

        private static void DrawScreen(Boolean[,] screenBuffer)
        {
            System.Console.SetCursorPosition(0, 0);

            for (Byte y = 0; y < screenBuffer.GetLength(1); y++)
            {
                StringBuilder builder = new StringBuilder();

                for (Byte x = 0; x < screenBuffer.GetLength(0); x++)
                {
                    builder.Append(screenBuffer[x, y] ? "#" : " ");
                }

                System.Console.WriteLine(builder.ToString());
            }
        }
    }
}
