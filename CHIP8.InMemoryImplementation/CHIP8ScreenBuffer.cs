using CHIP8.Infrastructure.Interfaces;
using System;

namespace CHIP8.InMemoryImplementation
{
    public class CHIP8ScreenBuffer : ICHIP8ScreenBuffer
    {
        private const Byte SCREEN_HEIGHT = 32;
        private const Byte SCREEN_WIDTH = 64;

        private readonly Boolean[,] _screen;

        public CHIP8ScreenBuffer()
        {
            _screen = new Boolean[SCREEN_WIDTH, SCREEN_HEIGHT];
        }

        public void ClearScreen()
        {
            for (Byte x = 0; x < SCREEN_WIDTH; x++)
            {
                for (Byte y = 0; y < SCREEN_HEIGHT; y++)
                {
                    _screen[x, y] = false;
                }
            }
        }

        public Boolean GetStateAtLocation(Byte x, Byte y)
        {
            return _screen[x, y];
        }

        public void SetStateAtLocation(Byte x, Byte y, Boolean state)
        {
            _screen[x, y] = state;
        }

        public Byte ScreenHeight()
        {
            return SCREEN_HEIGHT;
        }

        public Byte ScreenWidth()
        {
            return SCREEN_WIDTH;
        }
    }
}
