using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using System;
using System.Xml.Serialization;

namespace CHIP8.OpCodes
{
    public class Arithmetic : CHIP8OpCode
    {
        private readonly CHIP8Register<Byte> _registers;

        public Arithmetic(CHIP8Configuration configuration)
        {
            _localCode = 0x8;
            _registers = configuration.Registers;
        }

        public override void Execute(OpCodeData opCodeData)
        {
            switch (opCodeData.Nibble)
            {
                case 0x0:
                    TransferRegisterValues(opCodeData);
                    break;
                case 0x1:
                    BitwiseOr(opCodeData);
                    break;
                case 0x2:
                    BitwiseAnd(opCodeData);
                    break;
                case 0x3:
                    ExclusiveOr(opCodeData);
                    break;
                case 0x4:
                    AddAndCarry(opCodeData);
                    break;
                case 0x5:
                    SubtractYFromX(opCodeData);
                    break;
                case 0x6:
                    ShiftRight(opCodeData);
                    break;
                case 0x7:
                    SubtractXFromY(opCodeData);
                    break;
                case 0x8:
                    ShiftLeft(opCodeData);
                    break;
            }
            
        }

        private void AddAndCarry(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);
            Byte vYValue = _registers.GetRegisterValue(opCodeData.Y);

            UInt16 result = (UInt16)(vXValue + vYValue);

            if (result > 0xFF)
            {
                _registers.SetRegisterValue(0xF, 0x1);
            }

            _registers.SetRegisterValue(opCodeData.X, (Byte)(vXValue + vYValue));
        }

        private void BitwiseAnd(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);
            Byte vYValue = _registers.GetRegisterValue(opCodeData.Y);

            _registers.SetRegisterValue(opCodeData.X, (Byte)(vXValue & vYValue));
        }

        private void BitwiseOr(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);
            Byte vYValue = _registers.GetRegisterValue(opCodeData.Y);

            _registers.SetRegisterValue(opCodeData.X, (Byte)(vXValue | vYValue));
        }

        private void ExclusiveOr(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);
            Byte vYValue = _registers.GetRegisterValue(opCodeData.Y);

            _registers.SetRegisterValue(opCodeData.X, (Byte)(vXValue ^ vYValue));
        }

        private void ShiftLeft(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);

            if ((Byte)(vXValue & 0xF) == 0x1)
            {
                _registers.SetRegisterValue(0xF, 1);
            }
            else
            {
                _registers.SetRegisterValue(0xF, 0);
            }

            _registers.SetRegisterValue(opCodeData.X, (Byte)(vXValue / 2));
        }

        private void ShiftRight(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);

            if ((Byte)(vXValue & 0x1) == 0x1)
            {
                _registers.SetRegisterValue(0xF, 1);
            }
            else 
            {
                _registers.SetRegisterValue(0xF, 0);
            }

            _registers.SetRegisterValue(opCodeData.X, (Byte)(vXValue / 2));
        }

        private void SubtractXFromY(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);
            Byte vYValue = _registers.GetRegisterValue(opCodeData.Y);

            if (vYValue > vXValue)
            {
                _registers.SetRegisterValue(0xF, 1);
            }
            else
            {
                _registers.SetRegisterValue(0xF, 0);
            }

            _registers.SetRegisterValue(opCodeData.X, (Byte)(vYValue - vXValue));
        }

        private void SubtractYFromX(OpCodeData opCodeData)
        {
            Byte vXValue = _registers.GetRegisterValue(opCodeData.X);
            Byte vYValue = _registers.GetRegisterValue(opCodeData.Y);

            if (vXValue > vYValue)
            {
                _registers.SetRegisterValue(0xF, 1);
            }
            else
            {
                _registers.SetRegisterValue(0xF, 0);
            }

            _registers.SetRegisterValue(opCodeData.X, (Byte)(vXValue - vYValue));
        }

        private void TransferRegisterValues(OpCodeData opCodeData)
        {
            Byte vYValue = _registers.GetRegisterValue(opCodeData.Y);

            _registers.SetRegisterValue(opCodeData.X, vYValue);
        }
    }
}
