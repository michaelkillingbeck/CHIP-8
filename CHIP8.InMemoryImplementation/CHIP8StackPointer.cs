using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Exceptions;
using CHIP8.Infrastructure.Interfaces;
using System;

namespace CHIP8.InMemoryImplementation
{
    public class CHIP8StackPointer : CHIP8Register<Byte>, ICHIP8StackPointer
    {
        private const Byte MAX_STACK_SIZE = 0xF;
        private const Byte STACK_REGISTER_INDEX = 0x0;
        private readonly UInt16[] _localStack;

        public CHIP8StackPointer() : base(0x1)
        {
            _localStack = new UInt16[MAX_STACK_SIZE];
        }

        public UInt16 Pop()
        {
            Byte stackPointer = GetRegisterValue(STACK_REGISTER_INDEX);

            if (stackPointer < 1)
                throw new CHIP8IndexOutOfRangeException(stackPointer);
            SetRegisterValue(value: --stackPointer);
            return _localStack[stackPointer];

        }

        public void Push(UInt16 value)
        {
            Byte stackPointer = GetRegisterValue(STACK_REGISTER_INDEX);

            if (stackPointer >= MAX_STACK_SIZE)
                throw new CHIP8StackOverflowException(MAX_STACK_SIZE);

            _localStack[stackPointer++] = value;
            SetRegisterValue(value: stackPointer);
        }
    }
}
