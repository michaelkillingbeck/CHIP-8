using CHIP8.Infrastructure.Abstracts;
using System;

namespace CHIP8.InMemoryImplementation
{
    public class CHIP8ProgramCounterRegister : CHIP8Register<UInt16>
    {
        public CHIP8ProgramCounterRegister() : base(0x1)
        {
            SetRegisterValue(0x0, 0x200);
        }
    }
}
