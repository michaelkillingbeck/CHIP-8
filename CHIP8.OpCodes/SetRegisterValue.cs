﻿using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;

namespace CHIP8.OpCodes
{
    public class SetRegisterValue : CHIP8OpCode
    {
        private readonly CHIP8Register<Byte> _registers;

        public SetRegisterValue(CHIP8Configuration configuration)
        {
            _localCode = 0x6;
            _registers = configuration.Registers;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            _registers.SetRegisterValue(opCodeData.X, opCodeData.Value);
        }
    }
}
