using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;

namespace CHIP8.OpCodes
{
    public class SetRegisterValue : CHIP8OpCode
    {
        private readonly Byte _localCode = 0x6;
        private readonly CHIP8Register<Byte> _registers;

        public SetRegisterValue(CHIP8Configuration configuration)
        {
            _registers = configuration.Registers;
        }

        public override Byte GetCode()
        {
            return _localCode;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            _registers.SetRegisterValue(opCodeData.X, opCodeData.Value);
        }
    }
}
