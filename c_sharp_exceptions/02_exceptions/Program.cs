using System;

namespace _02_exceptions
{
    class Program
    {
        static void Main()
        {
            Exception ex = new Exception("My Exception info...");

            try
            {
                throw ex;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catch!");
                Console.WriteLine(e.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
