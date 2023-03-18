using System;

namespace Matrix
{
    public class Program
    {
        static void Main (string[] args)
        {
            // Setting up variables to control the range of printable symbols from the ASCII table
            int asciiStart = 62;
            int asciiEnd = 400;

            // Setting up counters for color and display position changes
            int colorCounter = 0;
            int lineCounter = 0;

            // Initializing variables for cursor position
            int cursorX = 0;
            int cursorY = 0;

            // Creating a new instance of the Random class
            Random rnd = new Random();

            // Hiding the cursor
            Console.CursorVisible = false;

            // Starting an infinite loop
            while (true)
            {   
                // Generating a random number within the specified range of ASCII symbols
                int randomSymbol = rnd.Next(asciiStart, asciiEnd);

                // Setting the cursor position
                if (lineCounter == 0)
                {
                    // If this is the start of a new line, randomly choose a Y coordinate within the window
                    cursorY = rnd.Next(0, Console.WindowHeight - 11);
                    cursorX = rnd.Next(0, Console.WindowWidth);
                    Console.SetCursorPosition(cursorX, cursorY);
                }
                else
                {
                    // Otherwise, increment the Y coordinate to move down one line
                    Console.SetCursorPosition(cursorX, cursorY++);
                }

                // Randomizing the color of the symbol
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

                // Writing the symbol to the console and resetting the color
                Console.WriteLine(Convert.ToChar(randomSymbol));
                Console.ResetColor();
                System.Threading.Thread.Sleep(10);

                // Updating counters
                colorCounter++;
                lineCounter++;

                // Using lineCounter to make lines between 5 and 9 symbols long, and adding a safety net
                if (lineCounter == rnd.Next(5, 9) || lineCounter >= 10)
                {
                    lineCounter = 0;
                } 

                // Clearing the console after 5000 loops
                if (colorCounter > 5000)
                {
                    Console.Clear();
                    colorCounter = 0;
                }
            }
        }
    }
}
