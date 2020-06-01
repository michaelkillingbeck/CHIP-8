using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;

namespace CHIP8.OpCodes
{
    public class JumpToLocation : CHIP8OpCode
    {
        private readonly CHIP8Register<UInt16> _programCounter;

        public JumpToLocation(CHIP8Configuration configuration)
        {
            _localCode = 0x1;
            _programCounter = configuration.ProgramCounter;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            _programCounter.SetRegisterValue(value: opCodeData.Address);
        }
    }
}
