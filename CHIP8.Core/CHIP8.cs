using System;
using System.Diagnostics;
using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Interfaces;
using CHIP8.InMemoryImplementation;

namespace CHIP8.Core
{
    public class CHIP8 : ICHIP8
    {
        private readonly ICHIP8ClockFrequencyTimer _cpuTimer;
        private readonly ICHIP8Timer _delayTimer;
        private readonly CHIP8Register<Byte> _generalPurposeRegisters;
        private readonly CHIP8Register<UInt16> _instructionRegister;
        private readonly ICHIP8Memory _memory;
        private readonly ICHIP8OpCodesDirector _opCodesDirector;
        private readonly CHIP8Register<UInt16> _programCounter;
        private readonly ICHIP8ScreenBuffer _screen;
        private readonly ICHIP8ClockFrequencyTimer _screenRefreshTimer;
        private readonly ICHIP8Timer _soundTimer;
        private readonly ICHIP8StackPointer _stackPointer;

        public event EventHandler<Boolean[,]> ScreenRefresh;

        public CHIP8(ICHIP8OpCodesDirector opCodesDirector, CHIP8Configuration configuration)
        {
            _delayTimer = configuration.DelayTimer;
            _generalPurposeRegisters = configuration.Registers;
            _instructionRegister = configuration.InstructionRegister;
            _memory = configuration.Memory;
            _opCodesDirector = opCodesDirector;
            _programCounter = configuration.ProgramCounter;
            _screen = configuration.Screen;
            _soundTimer = configuration.SoundTimer;
            _stackPointer = configuration.StackPointer;

            _cpuTimer = new CHIP8Timer(configuration.CPURefreshRate);
            _cpuTimer.TimerExpired += CPUTimerExpired;
            _screenRefreshTimer = new CHIP8Timer(configuration.ScreenRefreshRate);
            _screenRefreshTimer.TimerExpired += ScreenRefreshTimerExpired;


            opCodesDirector.Initialize(configuration);
            LoadFont();

            _cpuTimer.Start();
            _screenRefreshTimer.Start();
        }

        public void DisplayTick()
        {
            _delayTimer.DecrementTimer();
            _soundTimer.DecrementTimer();
        }

        public void LoadROM(Byte[] romBytes)
        {
            _memory.LoadROM(romBytes);
        }

        public void Tick()
        {
            UInt16 currentMemoryLocation = _programCounter.GetRegisterValue(0x0);

            Byte[] opCodeBytes = new Byte[2] {
                _memory.GetValueAtLocation(currentMemoryLocation++),
                _memory.GetValueAtLocation(currentMemoryLocation++)
            };
            _programCounter.SetRegisterValue(value: currentMemoryLocation);

            UInt16 currentInstruction = (UInt16)((opCodeBytes[0] << 8) + opCodeBytes[1]);
            Trace.WriteLine(currentInstruction);

            OpCodeData opCodeData = new OpCodeData
            {
                Address = (UInt16)(currentInstruction & 0x0FFF),
                Nibble = (Byte)(currentInstruction & 0x000F),
                OpCode = currentInstruction,
                Value = (Byte)(currentInstruction & 0x00FF),
                X = (Byte)((currentInstruction & 0x0F00) >> 8),
                Y = (Byte)((currentInstruction & 0x00F0) >> 4)
            };

            _opCodesDirector.HandleOpCode(opCodeData);
            Trace.WriteLine(_generalPurposeRegisters.DebugString());
            _cpuTimer.Start();
        }

        private void CPUTimerExpired(Object sender, EventArgs args)
        {
            Tick();  
        }

        private void ScreenRefreshTimerExpired(Object sender, EventArgs args)
        {
            DisplayTick();
            ScreenRefresh?.Invoke(this, _screen.GetScreenBuffer());
            _screenRefreshTimer.Start();
        }

        private void LoadFont()
        {
            Byte memoryAddress = 0x0;
            // 0
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            // 1
            _memory.SetValueAtLocation(memoryAddress++, 0x20);
            _memory.SetValueAtLocation(memoryAddress++, 0x60);
            _memory.SetValueAtLocation(memoryAddress++, 0x20);
            _memory.SetValueAtLocation(memoryAddress++, 0x20);
            _memory.SetValueAtLocation(memoryAddress++, 0x70);
            // 2
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x10);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            // 3
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x10);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x10);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            // 4
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x10);
            _memory.SetValueAtLocation(memoryAddress++, 0x10);
            // 5
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x10);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            // 6
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            // 7
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x10);
            _memory.SetValueAtLocation(memoryAddress++, 0x20);
            _memory.SetValueAtLocation(memoryAddress++, 0x40);
            _memory.SetValueAtLocation(memoryAddress++, 0x40);
            // 8
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            // 9
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x10);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            // A
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            // B
            _memory.SetValueAtLocation(memoryAddress++, 0xE0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xE0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xE0);
            // C
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            // D
            _memory.SetValueAtLocation(memoryAddress++, 0xE0);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0x90);
            _memory.SetValueAtLocation(memoryAddress++, 0xE0);
            // E
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            // F
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0xF0);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
            _memory.SetValueAtLocation(memoryAddress++, 0x80);
        }
    }
}
