using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHIP8.OpCodes
{
    public class RandomValue : CHIP8OpCode
    {
        private readonly CHIP8Register<Byte> _registers;

        public RandomValue(CHIP8Configuration configuration)
        {
            _localCode = 0xC;
            _registers = configuration.Registers;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            Byte randomValue = (Byte)new Random().Next(255);
            Byte newValue = (Byte)(randomValue & opCodeData.Value);

            _registers.SetRegisterValue(opCodeData.X, newValue);
        }
    }
}
