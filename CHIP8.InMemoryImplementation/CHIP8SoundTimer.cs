using CHIP8.Infrastructure.Interfaces;
using System;

namespace CHIP8.InMemoryImplementation
{
    public class CHIP8SoundTimer : ICHIP8Timer
    {
        private Byte _localValue;

        public void DecrementTimer()
        {
            if (_localValue > 0)
                    _localValue--;
        }

        public Byte GetValue()
        {
            return _localValue;
        }

        public void SetTimer(Byte value)
        {
            _localValue = value;
        }
    }
}
