using System;

namespace _08_exception
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Exception No 1:");
                userException.Method();

                try
                {
                    throw userException;
                }
                catch (UserException exception)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Exception No 2:");
                    exception.Method();
                }
                finally
                {
                    Console.WriteLine("Inner finally working...");
                }
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Outer finally working...");
            }

            Console.WriteLine("Press any key...");

            // Delay.
            Console.ReadKey();
        }
    }
}
