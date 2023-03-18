using System;
using System.Globalization;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // set the output encoding to UTF-8
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MatrixAnimation matrixAnimation = new MatrixAnimation(48, 12354);
            matrixAnimation.Run();
        }
    }

    class MatrixAnimation
    {
        private int asciiStart;
        private int asciiEnd;
        private int colorCounter;
        private int lineCounter;
        private int cursorX;
        private int cursorY;
        private Random random;
        private SoundPlayer soundPlayer;

        public MatrixAnimation(int asciiStart, int asciiEnd)
        {
            this.asciiStart = asciiStart;
            this.asciiEnd = asciiEnd;
            colorCounter = 0;
            lineCounter = 0;
            cursorX = 0;
            cursorY = 0;
            random = new Random();
        }

        public void Run()
        {
            while (true)
            {
                int randomSymbol = random.Next(asciiStart, asciiEnd);

                if (char.IsControl((char)randomSymbol) || CharUnicodeInfo.GetUnicodeCategory(Convert.ToChar(randomSymbol)) == UnicodeCategory.OtherSymbol)
                {
                    continue;
                }
                if (lineCounter == 0)
                {
                    cursorY = random.Next(0, Console.WindowHeight - 11);
                    cursorX = random.Next(0, Console.WindowWidth);
                    Console.SetCursorPosition(cursorX, cursorY);
                }
                else
                {
                    Console.SetCursorPosition(cursorX, cursorY++);
                }

                SetSymbolColor();
                Console.WriteLine(Convert.ToChar(randomSymbol));
                Console.ResetColor();
                System.Threading.Thread.Sleep(10);

                colorCounter++;
                lineCounter++;

                if (lineCounter == random.Next(5, 9) || lineCounter >= 10)
                {
                    lineCounter = 0;
                } 

                if (colorCounter > 5000)
                {
                    Console.Clear();
                    colorCounter = 0;
                }
            }
        }

        private void SetSymbolColor()
        {
            if (colorCounter % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (colorCounter % 7 == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
        }
    }
}
