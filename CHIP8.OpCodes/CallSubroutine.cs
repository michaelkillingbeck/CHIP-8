using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Interfaces;
using System;

namespace CHIP8.OpCodes
{
    public class CallSubroutine : CHIP8OpCode
    {
        private readonly CHIP8Register<UInt16> _programCounter;
        private readonly ICHIP8StackPointer _stackPointer;

        public CallSubroutine(CHIP8Configuration configuration)
        {
            _localCode = 0x2;
            _programCounter = configuration.ProgramCounter;
            _stackPointer = configuration.StackPointer;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            UInt16 currentAddress = _programCounter.GetRegisterValue();
            _stackPointer.Push(currentAddress);
            _programCounter.SetRegisterValue(value: opCodeData.Address);
        }
    }
}
