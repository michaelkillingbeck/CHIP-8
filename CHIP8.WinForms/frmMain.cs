using CHIP8.Core;
using CHIP8.Infrastructure;
using CHIP8.Infrastructure.Interfaces;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHIP8.WinForms
{
    public partial class frmMain : Form
    {
        private static ICHIP8 _chip8;
        private static ICHIP8KeyManager _keyManager = new WinFormsKeyManager();
        private static CHIP8Configuration _config = new CHIP8Configuration
        {
            CPURefreshRate = 540,
            DelayTimer = new InMemoryImplementation.CHIP8DelayTimer(),
            InstructionRegister = new InMemoryImplementation.CHIP8InstructionRegister(),
            KeyManager = _keyManager,
            Memory = new InMemoryImplementation.CHIP8Memory(),
            ProgramCounter = new InMemoryImplementation.CHIP8ProgramCounterRegister(),
            Registers = new InMemoryImplementation.CHIP8GeneralPurposeRegisters(),
            Screen = new InMemoryImplementation.CHIP8ScreenBuffer(),
            ScreenRefreshRate = 60,
            SoundTimer = new InMemoryImplementation.CHIP8SoundTimer(),
            StackPointer = new InMemoryImplementation.CHIP8StackPointer()
        };
        private static Boolean _running = false;
        private static Bitmap _screen;
        private delegate void SafeCallDelegate(Bitmap bitmap);

        public frmMain()
        {
            InitializeComponent();
            _screen = new Bitmap(50, 50);
            picScreen.Image = _screen;

            btnReset.Enabled = false;

            KeyDown += KeyPressed;
            KeyUp += KeyReleased;
        }

        private void HandleScreenRefresh(Object sender, Boolean[,] screenArray)
        {
            if (screenArray != null)
            {
                _screen = new Bitmap(screenArray.GetLength(0), screenArray.GetLength(1));

                BitmapData bits =
                    _screen.LockBits(
                        new Rectangle(0, 0, _screen.Width, _screen.Height),
                        ImageLockMode.WriteOnly,
                        PixelFormat.Format32bppArgb);

                unsafe
                {
                    Byte* pointer = (Byte*)bits.Scan0;

                    for (Int32 y = 0; y < _screen.Height; y++)
                    {
                        for (Int32 x = 0; x < _screen.Width; x++)
                        {
                            pointer[0] = 0;
                            pointer[1] = screenArray[x, y] ? (Byte)0x64 : (Byte)0;
                            pointer[2] = 0;
                            pointer[3] = 255;

                            pointer += 4;
                        }
                    }
                }

                _screen.UnlockBits(bits);

                RefreshScreen(_screen);
            }
        }

        private void KeyReleased(object sender, KeyEventArgs e)
        {
            _keyManager.KeyReleased((Int32)e.KeyCode);
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            _keyManager.KeyPressed((Int32)e.KeyCode);
        }

        private void btnLoadRom_Click(object sender, EventArgs e)
        {
            btnLoadRom.Enabled = false;
            btnReset.Enabled = true;

            Task.Factory.StartNew(() => Run());
        }

        private void RefreshScreen(Bitmap source)
        {
            if (picScreen.InvokeRequired)
            {
                var localDelegate = new SafeCallDelegate(RefreshScreen);
                picScreen.Invoke(localDelegate, new object[] { source });
            }
            else
            {
                picScreen.Image = source;
                picScreen.Refresh();
            }
        }

        private void Run()
        {
            _chip8 = new Core.CHIP8(new CHIP8OpCodesDirector(), _config);
            Byte[] romBytes = File.ReadAllBytes(@"C:\Code\CHIP-8\CHIP8ROMs\BRIX");
            _chip8.LoadROM(romBytes);
            _chip8.ScreenRefresh += HandleScreenRefresh;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _running = false;
            Task.Factory.StartNew(() => Run());
        }
    }
}
