using System;
using static System.Console;

namespace _11_exceptions
{
    /*
        try
        {
            //code with generate exception
        }
        catch(exception_type) when(condition)
        {
            //exception handling
        }
    */
    class Program
    {
        static int DivisionNumbers(int n1, int n2)
        {
            int result = 0;
            try
            {
                result = n1 / n2;
            }
            catch (DivideByZeroException de)
            {
                throw new Exception("Exception fillters", de);
            }
            return result;
        }
        static void Main(string[] args)
        {
            WriteLine("Input two number: ");
            int number1, number2, result = 0;
            try
            {
                number1 = int.Parse(ReadLine());
                number2 = int.Parse(ReadLine());
                result = DivisionNumbers(number1, number2);
                WriteLine($"Result of divide by zero:{ result }");
            }
            catch (Exception e) when (e.InnerException != null)
            {
                WriteLine("catch with condition!");
                //additional info
                WriteLine(e.Message);
                //previous exception
                WriteLine(e.InnerException.Message);
            }
            catch (Exception e)
            {
                WriteLine("catch without condition!");
                WriteLine(e.Message);
            }
        }
    }
}
