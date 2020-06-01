using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Interfaces;
using System;

namespace CHIP8.OpCodes
{
    public class ClearScreenOrReturnFromSubroutine : CHIP8OpCode
    {
        private readonly CHIP8Register<UInt16> _programCounter;
        private readonly ICHIP8ScreenBuffer _screen;
        private readonly ICHIP8StackPointer _stackPointer;

        public ClearScreenOrReturnFromSubroutine(CHIP8Configuration configuration)
        {
            _localCode = 0x0;
            _programCounter = configuration.ProgramCounter;
            _screen = configuration.Screen;
            _stackPointer = configuration.StackPointer;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            if (opCodeData.Nibble == 0x0)
            {
                UInt16 memoryAddress = _stackPointer.Pop();
                _programCounter.SetRegisterValue(value: memoryAddress);
            }
            else if (opCodeData.Nibble == 0xE)
            {
                _screen.ClearScreen();
            }
        }
    }
}
