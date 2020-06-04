using CHIP8.Infrastructure.Interfaces;

namespace CHIP8.WinForms
{
    public class WinFormsKeyManager : ICHIP8KeyManager
    {
        public bool IsKeyPressed(byte keyId)
        {
            return false;
        }
    }
}
