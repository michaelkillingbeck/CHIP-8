using CHIP8.Infrastructure.Exceptions;
using CHIP8.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace CHIP8.InMemoryImplementation
{
    public class CHIP8Timer : ICHIP8ClockFrequencyTimer
    {
        private Int16 _frequency = 0;
        private Timer _timer;

        public event EventHandler TimerExpired;

        public CHIP8Timer(Int16 frequencyHz)
        {
            if(frequencyHz < 1)
                throw new CHIP8InvalidFrequencyException(frequencyHz);

            _frequency = (Int16)(1000 / frequencyHz);
            _timer = new Timer();

            _timer.Elapsed += LocalTimerExpired;
        }

        public void SetFrequencyInHertz(Int16 frequencyHz)
        {
            _frequency = (Int16)(1000 / frequencyHz);
        }

        public async Task Start()
        {
            if(await IsTimerRunning())
            {
                _timer.Stop();                
            }

            _timer.Interval = _frequency;
            _timer.Start();
        }

        public async Task Stop()
        {
            if(await IsTimerRunning())
            {
                _timer.Stop();
            }
        }

        private Task<Boolean> IsTimerRunning()
        {
            return Task.FromResult<Boolean>(_timer.Enabled);
        }

        private void LocalTimerExpired(Object sender, EventArgs args)
        {
            if(TimerExpired == null)
                return;

            TimerExpired(sender, args);
        }
    }
}
