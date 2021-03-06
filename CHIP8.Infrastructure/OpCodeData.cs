﻿using System;

namespace CHIP8.Infrastructure
{
    public class OpCodeData
    {
        public UInt16 Address { get; set; }
        public Byte Nibble { get; set; }
        public UInt16 OpCode { get; set; }
        public Byte Value { get; set; }
        public Byte X { get; set; }
        public Byte Y { get; set; }
    }
}
