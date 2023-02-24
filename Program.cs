using System;

namespace Matrix
{
    public class Program
    {

        static void Main (string[] args)
        {
            int AsciiStart = 62;
            int AsciiEnd = 400;
            int counter = 0;
            int counter2 = 0;
            int x = 0;
            int y = 0;
            Random rnd = new Random();
            Console.CursorVisible = false;

            while (true)
            {         
                int num = rnd.Next(AsciiStart, AsciiEnd);
                if (counter2 == 0)
                {
                    y = rnd.Next(0, Console.WindowHeight -10); ;
                    x = rnd.Next(0, Console.WindowWidth); ;
                    Console.SetCursorPosition(x, y);
                }
                else
                {
                    Console.SetCursorPosition(x, y++);
                }


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
                
                counter++;
                counter2++;
                if (counter2 == rnd.Next(5,9) || counter2 == 10)
                {
                    counter2 = 0;
                } 
                if (counter == 5000)
                {
                    Console.Clear();
                }
            }
        }
    }
}
