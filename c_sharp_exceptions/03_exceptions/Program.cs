using System;

namespace _03_exceptions
{
    class Program
    {
        static void Main()
        {
            try
            {
                throw new Exception("My Exception");
            }
            catch (Exception e)
            {
                Console.WriteLine("Catch exception");
                Console.WriteLine(e.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
