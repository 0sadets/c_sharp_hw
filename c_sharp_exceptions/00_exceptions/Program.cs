using System;

namespace _00_exceptions
{
    class Program
    {
        static void Main()
        {
            int a = 1, n = 2;

            try
            {
                // Попытка деления на ноль.
                Console.WriteLine("Enter a: ");
                a = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter b: ");
                n = int.Parse(Console.ReadLine());

                a = a / n;

                Console.WriteLine("a = {0}", a);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Divede by Zero");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("OverflowException");
            }
            catch (FormatException e)
            {
                Console.WriteLine("FormatException");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catch!" + new string('-', 20));
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Continue...");
            // Delay.
            Console.ReadKey();
        }
    }
}
