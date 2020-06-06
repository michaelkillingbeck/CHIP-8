using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8KeyManager
    {
        Boolean IsKeyPressed(Byte keyId);
        void KeyPressed(Int32 keyId);
        void KeyReleased(Int32 keyId);
    }
}
