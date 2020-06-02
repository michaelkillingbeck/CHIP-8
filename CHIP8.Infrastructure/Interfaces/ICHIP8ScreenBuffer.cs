using System;

namespace CHIP8.Infrastructure.Interfaces
{
    public interface ICHIP8ScreenBuffer
    {
        void ClearScreen();
        Boolean[,] GetScreenBufferClone();
        Boolean GetStateAtLocation(Byte x, Byte y);
        void SetStateAtLocation(Byte x, Byte y, Boolean state);
        Byte ScreenHeight();
        Byte ScreenWidth();
    }
}
