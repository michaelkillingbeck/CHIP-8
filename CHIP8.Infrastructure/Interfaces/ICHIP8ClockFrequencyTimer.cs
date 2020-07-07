using System;
using System.Threading.Tasks;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8ClockFrequencyTimer
    {
        event EventHandler TimerExpired;

        void SetFrequencyInHertz(Int16 frequencyHz);
        Task Start();
        Task Stop();
    }
}
