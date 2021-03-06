﻿using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHIP8.OpCodes
{
    public class SkipIfRegistersNotEqual : CHIP8OpCode
    {
        private readonly CHIP8Register<UInt16> _programCounter;
        private readonly CHIP8Register<Byte> _registers;

        public SkipIfRegistersNotEqual(CHIP8Configuration configuration)
        {
            _localCode = 0x9;
            _programCounter = configuration.ProgramCounter;
            _registers = configuration.Registers;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            Byte vX = _registers.GetRegisterValue(opCodeData.X);
            Byte vY = _registers.GetRegisterValue(opCodeData.Y);

            if (vX != vY)
            {
                UInt16 programCounter = _programCounter.GetRegisterValue();
                programCounter += 2;
                _programCounter.SetRegisterValue(value: programCounter);
            }
        }
    }
}
