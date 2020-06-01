using CHIP8.Infrastructure.Interfaces;
using System;

namespace CHIP8.InMemoryImplementation
{
    public class CHIP8DelayTimer : ICHIP8Timer
    {
        private Byte _localValue;

        public CHIP8DelayTimer()
        {
        }

        public void DecrementTimer()
        {
            throw new NotImplementedException();
        }

        public void SetTimer(Byte value)
        {
            _localValue = value;
        }
    }
}
