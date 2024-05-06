using System;

namespace _07_exception
{
    class Program
    {
        static void Main()
        {
            int a = 1, n = 2;

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zero division.");
                Console.WriteLine("a / (2 - n) = {0}", a / (2 - n));
            }
            catch (DivideByZeroException e)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;                
                Console.WriteLine("Exception catch!");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Def Exception catch!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ResetColor();
                //Console.ForegroundColor = ConsoleColor.Gray;
                //Console.BackgroundColor = ConsoleColor.Black;

                // close connection
            }

            Console.WriteLine("Press any key...");

            // Delay.
            Console.ReadKey();
        }
    }
}
