using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Abstracts;
using CHIP8.Infrastructure.Interfaces;
using CHIP8.OpCodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHIP8.Core
{
    public class CHIP8OpCodesDirector : ICHIP8OpCodesDirector
    {
        private Dictionary<Byte, CHIP8OpCode> opCodes;

        public void HandleOpCode(OpCodeData opCodeData)
        {
            Byte opCodeNibble = (Byte)(opCodeData.OpCode >> 12);

            if (opCodes.ContainsKey(opCodeNibble))
            {
                opCodes[opCodeNibble].Execute(opCodeData);
            }
        }

        public void Initialize(CHIP8Configuration configuration)
        {
            RegisterOpCodes(configuration);
        }

        private void RegisterOpCodes(CHIP8Configuration configuration)
        {
            opCodes = new Dictionary<Byte, CHIP8OpCode>();


            AddOpCodeToDictionary<Arithmetic>(configuration);
            AddOpCodeToDictionary<CallSubroutine>(configuration);
            AddOpCodeToDictionary<ClearScreenOrReturnFromSubroutine>(configuration);
            AddOpCodeToDictionary<DrawSprite>(configuration);
            AddOpCodeToDictionary<IncreaseRegisterValue>(configuration);
            AddOpCodeToDictionary<JumpAheadByRegisterValue>(configuration);
            AddOpCodeToDictionary<JumpToLocation>(configuration);
            AddOpCodeToDictionary<LoadValueIntoRegister>(configuration);
            AddOpCodeToDictionary<MiscFCodes>(configuration);
            AddOpCodeToDictionary<RandomValue>(configuration);
            AddOpCodeToDictionary<SetInstructionRegister>(configuration);
            AddOpCodeToDictionary<SkipIfEqualsRegisterValue>(configuration);
            AddOpCodeToDictionary<SkipIfNotEqualToRegisterValue>(configuration);
            AddOpCodeToDictionary<SkipIfRegistersEqual>(configuration);
            AddOpCodeToDictionary<SkipIfRegistersNotEqual>(configuration);
            AddOpCodeToDictionary<SkipOnKeyState>(configuration);
        }

        private void AddOpCodeToDictionary<T>(CHIP8Configuration configuration) where T : CHIP8OpCode
        {
            T activatedOpCode = (T)Activator.CreateInstance(typeof(T), configuration);
            opCodes.Add(activatedOpCode.GetCode(), activatedOpCode);
        }
    }
}
