using CHIP8.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHIP8.Console
{
    public class CHIP8ConsoleKeyManager : ICHIP8KeyManager
    {
        Dictionary<Byte, ConsoleKey> keyMapping = new Dictionary<Byte, ConsoleKey>
        {
            { 0x1, ConsoleKey.D1 },
            { 0x2, ConsoleKey.D2 },
            { 0x3, ConsoleKey.D3 },
            { 0xC, ConsoleKey.D4 },
            { 0x4, ConsoleKey.Q },
            { 0x5, ConsoleKey.W },
            { 0x6, ConsoleKey.E },
            { 0xD, ConsoleKey.R },
            { 0x7, ConsoleKey.A },
            { 0x8, ConsoleKey.S },
            { 0x9, ConsoleKey.D },
            { 0xE, ConsoleKey.F },
            { 0xA, ConsoleKey.Z },
            { 0x0, ConsoleKey.X },
            { 0xB, ConsoleKey.C },
            { 0xF, ConsoleKey.V },
        };

        private ConsoleKey _pressedKey;

        public Boolean IsKeyPressed(Byte keyId)
        {
            return _pressedKey == keyMapping[keyId];
        }

        public void KeyDown(ConsoleKey pressedKey)
        {
            _pressedKey = pressedKey;
        }
    }
}
