using System;
using System.IO;

namespace _06_exception
{
    class UserException : Exception
    {
        public void Method()
        {
            Console.WriteLine("My Exception!");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                throw new UserException();
            }
            catch (UserException userException)
            {
                Console.WriteLine("Exception catch!.");
                userException.Method();

                try
                {
                    FileStream fs = File.Open(@"C:\NonExistentFile.log", FileMode.Open);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
