using System;

namespace Matrix
{
    public class Program
    {

        static void Main (string[] args)
        {
            // setting start and end point in ascii table to get printable symbols
            int AsciiStart = 62;
            int AsciiEnd = 400;
            //setting up counters to use for changes in colors and display positions
            int counter = 0;
            int counter2 = 0;
            //setting up variables to use for axis
            int x = 0;
            int y = 0;
            // creating a random generator
            Random rnd = new Random();
            // making the cursor invisable
            Console.CursorVisible = false;
            // starting infinite loop
            while (true)
            {   
                // getting a random number from the ascii table
                int num = rnd.Next(AsciiStart, AsciiEnd);
                // setting cursor position
                if (counter2 == 0)
                {
                    y = rnd.Next(0, Console.WindowHeight -11); ;
                    x = rnd.Next(0, Console.WindowWidth); ;
                    Console.SetCursorPosition(x, y);
                }
                else
                {
                    Console.SetCursorPosition(x, y++);
                }

                // randomizing colours of the symbols
                if (counter % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Convert.ToChar(num));
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(10);
                }
                else if (counter % 7 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Convert.ToChar(num));
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(10);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Convert.ToChar(num));
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(10);
                }
                // updating counters
                counter++;
                counter2++;
                // using counter2 to make lines between 5 and 9 symbols long and adding a saftey net 
                if (counter2 == rnd.Next(5,9) || counter2 >= 10)
                {
                    counter2 = 0;
                } 
                // When 5000 loops have been completed Clear console.
                if (counter > 5000)
                {
                    Console.Clear();
                }
            }
        }
    }
}
