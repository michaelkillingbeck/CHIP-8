using System;
using System.Collections.Generic;
using System.Text;

namespace CHIP8.OpCodes
{
    public class OpCodeData
    {
        public UInt16 Address { get; set; }
        public Byte Nibble { get; set; }
        public Byte X { get; set; }
        public Byte Y { get; set; }
        public Byte Value { get; set; }
    }
}
