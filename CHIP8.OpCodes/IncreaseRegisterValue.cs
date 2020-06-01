using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;

namespace CHIP8.OpCodes
{
    public class IncreaseRegisterValue : CHIP8OpCode
    {
        private readonly CHIP8Register<Byte> _registers;

        public IncreaseRegisterValue(CHIP8Configuration configuration)
        {
            _localCode = 0x7;
            _registers = configuration.Registers;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            Byte registerValue = _registers.GetRegisterValue(opCodeData.X);
            registerValue += opCodeData.Value;

            _registers.SetRegisterValue(opCodeData.X, registerValue);
        }
    }
}
