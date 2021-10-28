namespace Kernel
{
    // Console colours
    public enum ConsoleColour
    {
        Black,
        Blue,
        Green,
        Cyan,
        Red,
        Purple,
        Brown,
        Grey,
        DarkGrey,
        LightBlue,
        LightGreen,
        LightCyan,
        LightRed,
        LightPurple,
        Yellow,
        White,
    };
    public unsafe static class Console
    {
        // VGA text mode address
        public static ushort* vga = (ushort*)0xB8000;
        // Cursor positions
        public static int x = 0, y = 0, lastx = 0;
        // Text colours
        public static ConsoleColour ForegroundColour = ConsoleColour.White;
        public static ConsoleColour BackgroundColour = ConsoleColour.Black;

        public static void Write(string s)
        {
            foreach(char c in s)
            {
                PutChar(c, BackgroundColour, ForegroundColour);
            }
        }

        public static void WriteLine(string s)
        {
            foreach(char c in s)
            {
                PutChar(c, BackgroundColour, ForegroundColour);
            }
            PutChar('\n', BackgroundColour, ForegroundColour);
        }

        static void PutChar(char c, ConsoleColour bgcolour, ConsoleColour fgcolour)
        {
            switch (c)
            {
                // Newline
                case '\n':
                    lastx = x;
                    x = 0;
                    y++;
                    break;
                // Backspace
                case '\b':
                    if (x > 0)
                    {
                        x--;
                        vga[y * 80 + x] = (ushort)(((byte)bgcolour << 12) | ((byte)fgcolour << 8) | ' ');
                    }
                    else
                    {
                        x = lastx;
                        y--;
                    }
                    break;
                // Everything else
                default:
                    vga[y * 80 + x] = (ushort)(((byte)bgcolour << 12) | ((byte)fgcolour << 8) | c);
                    if (x < 80) x++;
                    else
                    {
                        lastx = x;
                        x = 0;
                        y++;
                    }
                    break;
            }
        }
    }
}
