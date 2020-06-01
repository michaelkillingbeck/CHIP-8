using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHIP8.OpCodes
{
    public class SkipOnKeyState : CHIP8OpCode
    {
        private readonly ICHIP8KeyManager _keyManager;
        private CHIP8Register<UInt16> _programCounter;
        private readonly CHIP8Register<Byte> _registers;

        public SkipOnKeyState(CHIP8Configuration configuration)
        {
            _keyManager = configuration.KeyManager;
            _localCode = 0xE;
            _programCounter = configuration.ProgramCounter;
            _registers = configuration.Registers;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);
            UInt16 programCounterValue = _programCounter.GetRegisterValue();

            if (opCodeData.Value == 0x9E)
            {
                if (_keyManager.IsKeyPressed(vXValue) == true)
                    _programCounter.SetRegisterValue(value: (UInt16)(programCounterValue + 2));
            }
            else if (opCodeData.Value == 0xA1)
            {
                if (_keyManager.IsKeyPressed(vXValue) == false)
                    _programCounter.SetRegisterValue(value: (UInt16)(programCounterValue + 2));
            }
        }
    }
}
