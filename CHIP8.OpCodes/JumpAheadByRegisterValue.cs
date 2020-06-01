using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHIP8.OpCodes
{
    public class JumpAheadByRegisterValue : CHIP8OpCode
    {
        private readonly CHIP8Register<UInt16> _programCounter;
        private readonly CHIP8Register<Byte> _registers;

        public JumpAheadByRegisterValue(CHIP8Configuration configuration)
        {
            _localCode = 0xB;
            _programCounter = configuration.ProgramCounter;
            _registers = configuration.Registers;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            Byte v0Value = _registers.GetRegisterValue(0x0);

            _programCounter.SetRegisterValue(value: (UInt16)(v0Value + opCodeData.Address));
        }
    }
}
