using CHIP8.Infrastructure.Exceptions;
using System;

namespace CHIP8.Infrastructure.Abstracts
{
    public abstract class CHIP8Register<T>
    {
        protected readonly T[] _registers;
        protected readonly Byte _numberOfRegisters;

        public CHIP8Register(Byte numberOfRegisters)
        {
            _numberOfRegisters = numberOfRegisters;
            _registers = new T[_numberOfRegisters];
        }

        public T GetRegisterValue(Byte registerIndex)
        {
            if (registerIndex >= _numberOfRegisters)
                throw new CHIP8InvalidRegisterIndexException(registerIndex, _numberOfRegisters, nameof(registerIndex));

            return _registers[registerIndex];
        }

        public void SetRegisterValue(Byte registerIndex, T value)
        {
            if (registerIndex >= _numberOfRegisters)
                throw new CHIP8InvalidRegisterIndexException(registerIndex, _numberOfRegisters, nameof(registerIndex));

            _registers[registerIndex] = value;
        }
    }
}
