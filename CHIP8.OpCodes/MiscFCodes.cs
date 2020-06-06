using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CHIP8.OpCodes
{
    public class MiscFCodes : CHIP8OpCode
    {
        private readonly ICHIP8Timer _delayTimer;
        private readonly CHIP8Register<UInt16> _instructionRegister;
        private readonly ICHIP8KeyManager _keyManager;
        private readonly ICHIP8Memory _memory;
        private readonly CHIP8Register<Byte> _registers;
        private readonly ICHIP8Timer _soundTimer;

        public MiscFCodes(CHIP8Configuration configuration)
        {
            _delayTimer = configuration.DelayTimer;
            _instructionRegister = configuration.InstructionRegister;
            _keyManager = configuration.KeyManager;
            _localCode = 0xF;
            _memory = configuration.Memory;
            _registers = configuration.Registers;
            _soundTimer = configuration.SoundTimer;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            switch (opCodeData.Value)
            {
                case 0x07:
                    CopyDelayTimerToRegister(opCodeData);
                    break;
                case 0x0A:
                    WaitForKeyPress(opCodeData);
                    break;
                case 0x15:
                    SetDelayTimerToRegisterValue(opCodeData);
                    break;
                case 0x18:
                    SetSoundTimerToRegisterValue(opCodeData);
                    break;
                case 0x1E:
                    IncrementInstructionRegister(opCodeData);
                    break;
                case 0x29:
                    SetInstructionRegisterToCharacterSpriteLocation(opCodeData);
                    break;
                case 0x33:
                    SetBinaryCodedDecimal(opCodeData);
                    break;
                case 0x55:
                    SaveRegisterValuesIntoMemory(opCodeData);
                    break;
                case 0x65:
                    LoadRegisterValuesFromMemory(opCodeData);
                    break;
            }
        }

        private void CopyDelayTimerToRegister(OpCodeData opCodeData)
        {
            Byte delayTimerValue = _delayTimer.GetValue();
            _registers.SetRegisterValue(opCodeData.X, delayTimerValue);
        }

        private void IncrementInstructionRegister(OpCodeData opCodeData)
        {
            UInt16 instructionRegisterValue = _instructionRegister.GetRegisterValue();
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);

            _instructionRegister.SetRegisterValue(value: (UInt16)(instructionRegisterValue + vXValue));
        }

        private void LoadRegisterValuesFromMemory(OpCodeData opCodeData)
        {
            Byte numberOfRegisters = opCodeData.X;
            UInt16 instructionRegisterValue = _instructionRegister.GetRegisterValue();

            for (Byte index = 0; index < numberOfRegisters; index++)
            {
                Byte memoryValue = _memory.GetValueAtLocation((UInt16)(instructionRegisterValue + index));
                _registers.SetRegisterValue(index, memoryValue);
            }
        }

        private void SaveRegisterValuesIntoMemory(OpCodeData opCodeData)
        {
            Byte numberOfRegisters = _registers.NumberOfRegisters();
            UInt16 instructionRegisterValue = _instructionRegister.GetRegisterValue();

            for (Byte index = 0; index < numberOfRegisters; index++)
            {
                _memory.SetValueAtLocation((UInt16)(instructionRegisterValue + index), _registers.GetRegisterValue(index));
            }
        }

        private void SetBinaryCodedDecimal(OpCodeData opCodeData)
        {
            UInt16 instructionRegisterValue = _instructionRegister.GetRegisterValue();
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);

            _memory.SetValueAtLocation(instructionRegisterValue, (Byte)((vXValue / 100) % 10));
        }

        private void SetDelayTimerToRegisterValue(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);

            _delayTimer.SetTimer(vXValue);
        }

        private void SetInstructionRegisterToCharacterSpriteLocation(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);

            _instructionRegister.SetRegisterValue(value: (UInt16)(vXValue * 5));
        }

        private void SetSoundTimerToRegisterValue(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);

            _soundTimer.SetTimer(vXValue);
        }

        private void WaitForKeyPress(OpCodeData opCodeData)
        {
            Byte keyId = opCodeData.X;

            while (_keyManager.IsKeyPressed(keyId) == false)
            {
                Thread.Sleep(100);
            }
        }
    }
}
