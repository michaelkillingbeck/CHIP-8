using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Interfaces;
using System;

namespace CHIP8.Infrastructure
{
    public class CHIP8Configuration
    {
        public ICHIP8Timer DelayTimer { get; set; }
        public CHIP8Register<UInt16> InstructionRegister { get; set; }
        public ICHIP8KeyManager KeyManager { get; set; }
        public ICHIP8Memory Memory { get; set; }
        public CHIP8Register<UInt16> ProgramCounter { get; set; }
        public CHIP8Register<Byte> Registers { get; set; }
        public ICHIP8ScreenBuffer Screen { get; set; }
        public ICHIP8Timer SoundTimer { get; set; }
        public ICHIP8StackPointer StackPointer { get; set; }
    }
}