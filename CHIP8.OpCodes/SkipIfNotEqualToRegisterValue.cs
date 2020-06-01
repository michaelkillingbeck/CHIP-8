using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;

namespace CHIP8.OpCodes
{
    public class SkipIfNotEqualToRegisterValue : CHIP8OpCode
    {
        private readonly CHIP8Register<UInt16> _programCounter;
        private readonly CHIP8Register<Byte> _registers;

        public SkipIfNotEqualToRegisterValue(CHIP8Configuration configuration)
        {
            _localCode = 0x4;
            _programCounter = configuration.ProgramCounter;
            _registers = configuration.Registers;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            Byte registerValue = _registers.GetRegisterValue(opCodeData.X);

            if (registerValue != opCodeData.Value)
            {
                UInt16 programCounter = _programCounter.GetRegisterValue();
                programCounter += 2;
                _programCounter.SetRegisterValue(value: programCounter);
            }
        }
    }
}
