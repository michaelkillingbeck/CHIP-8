using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHIP8.OpCodes
{
    public class SetInstructionRegister : CHIP8OpCode
    {
        CHIP8Register<UInt16> _instructionRegister;

        public SetInstructionRegister(CHIP8Configuration configuration)
        {
            _instructionRegister = configuration.InstructionRegister;
            _localCode = 0xA;

        }

        public override void Execute(OpCodeData opCodeData)
        {
            _instructionRegister.SetRegisterValue(value: opCodeData.Address);
        }
    }
}
