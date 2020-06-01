using CHIP8.Infrastructure.Abstracts;
using System;

namespace CHIP8.InMemoryImplementation
{
    public class CHIP8GeneralPurposeRegisters : CHIP8Register<Byte>
    {
        public CHIP8GeneralPurposeRegisters() : base(0xF)
        {
        }
    }
}
