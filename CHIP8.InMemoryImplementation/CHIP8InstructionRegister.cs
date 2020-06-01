using CHIP8.Infrastructure.Abstracts;
using System;

namespace CHIP8.InMemoryImplementation
{
    public class CHIP8InstructionRegister : CHIP8Register<UInt16>
    {
        public CHIP8InstructionRegister() : base(0x1)
        {
        }
    }
}
