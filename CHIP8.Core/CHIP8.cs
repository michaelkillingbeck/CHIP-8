using System;
using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Interfaces;

namespace CHIP8.Core
{
    public class CHIP8 : ICHIP8
    {
        private readonly ICHIP8Timer _delayTimer;
        private readonly CHIP8Register<Byte> _generalPurposeRegisters;
        private readonly CHIP8Register<UInt16> _instructionRegister;
        private readonly ICHIP8Memory _memory;
        private readonly ICHIP8OpCodesDirector _opCodesDirector;
        private readonly CHIP8Register<UInt16> _programCounter;
        private readonly ICHIP8ScreenBuffer _screen;
        private readonly ICHIP8Timer _soundTimer;
        private readonly ICHIP8StackPointer _stackPointer;

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

            opCodesDirector.Initialize(configuration);
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
        }
    }
}
