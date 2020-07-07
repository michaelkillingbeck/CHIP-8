using CHIP8.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CHIP8.WinForms
{
    public class WinFormsKeyManager : ICHIP8KeyManager
    {
        private static readonly Dictionary<Int32, Byte> _keyMap = new Dictionary<Int32, Byte>
        {
            {(Int32)Keys.D1,   0x0},
            {(Int32)Keys.D2,   0x1},
            {(Int32)Keys.D3,   0x2},
            {(Int32)Keys.D4,   0x3},
            {(Int32)Keys.Q,    0x4},
            {(Int32)Keys.W,    0x5},
            {(Int32)Keys.E,    0x6},
            {(Int32)Keys.R,    0x7},
            {(Int32)Keys.A,    0x8},
            {(Int32)Keys.S,    0x9},
            {(Int32)Keys.D,    0xA},
            {(Int32)Keys.F,    0xB},
            {(Int32)Keys.Z,    0xC},
            {(Int32)Keys.X,    0xD},
            {(Int32)Keys.C,    0xE},
            {(Int32)Keys.V,    0xF}
        };

        private readonly HashSet<Byte> _pressedKeys;

        public WinFormsKeyManager()
        {
            _pressedKeys = new HashSet<Byte>();
        }

        public Boolean IsKeyPressed(Byte keyId)
        {
            return _pressedKeys.Contains(keyId);
        }

        public void KeyPressed(Int32 pressedKeyId)
        {
            if (_keyMap.ContainsKey(pressedKeyId))
            {
                _pressedKeys.Add(_keyMap[pressedKeyId]);
            }
        }

        public void KeyReleased(Int32 releasedKeyId)
        {
            if (_keyMap.ContainsKey(releasedKeyId))
            {
                _pressedKeys.Remove(_keyMap[releasedKeyId]);
            }
        }
    }
}
