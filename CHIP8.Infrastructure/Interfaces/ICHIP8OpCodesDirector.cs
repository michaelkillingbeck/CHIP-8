using System;
using System.Collections.Generic;
using System.Text;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8OpCodesDirector
    {
        void HandleOpCode(OpCodeData opCodeData);
        void Initialize(CHIP8Configuration configuration);
    }
}
