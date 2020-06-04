using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CHIP8.OpCodes
{
    public class DrawSprite : CHIP8OpCode
    {
        private readonly CHIP8Register<UInt16> _instructionRegister;
        private readonly ICHIP8Memory _memory;
        private readonly CHIP8Register<Byte> _registers;
        private readonly ICHIP8ScreenBuffer _screen;
        private readonly Byte _screenHeight;
        private readonly Byte _screenWidth;

        public DrawSprite(CHIP8Configuration configuration)
        {
            _instructionRegister = configuration.InstructionRegister;
            _localCode = 0xD;
            _memory = configuration.Memory;
            _registers = configuration.Registers;
            _screen = configuration.Screen;
            _screenHeight = configuration.Screen.ScreenHeight();
            _screenWidth = configuration.Screen.ScreenWidth();
        }

        public override void Execute(OpCodeData opCodeData)
        {
            Byte sizeOfSprite = opCodeData.Nibble;
            Byte startingX = _registers.GetRegisterValue(opCodeData.X);
            Byte startingY = _registers.GetRegisterValue(opCodeData.Y);
            UInt16 instructionRegisterLocation = _instructionRegister.GetRegisterValue();

            for (Byte spritePosition = 0; spritePosition < sizeOfSprite; spritePosition++)
            {
                Byte spriteByte = _memory.GetValueAtLocation((UInt16)(instructionRegisterLocation + spritePosition));
                BitArray bitArray = new BitArray(new Byte[] { spriteByte });

                for (Byte bitArrayIndex = 7; bitArrayIndex > 0; bitArrayIndex--)
                {
                    Byte xPosition = (Byte)((startingX + (7 - bitArrayIndex)) % _screenWidth);
                    Byte yPosition = (Byte)((startingY + spritePosition) % _screenHeight);


                    Boolean oldState = _screen.GetStateAtLocation(xPosition, yPosition);
                    Boolean spriteState = bitArray[bitArrayIndex];
                    Boolean newState = oldState ^ spriteState;

                    Trace.WriteLine($"{xPosition}:{yPosition} {oldState}^{spriteState}={newState}");

                    _screen.SetStateAtLocation(xPosition, yPosition, newState);

                    if (oldState == true && newState == false)
                        _registers.SetRegisterValue(0xF, 0x1);
                }
            }
        }
    }
}
