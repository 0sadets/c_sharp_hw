using System;
using static System.Console;

namespace _09_exceptions
{
    class Program
    {
        // nameof() - get name (string) of member
        static int DivisionNumbers(int n1, int n2)
        {
            int result = 0;
            try
            {
                result = n1 / n2;
            }
            catch (DivideByZeroException de)
            {
                //throw new Exception("Additional information", de);
                throw new Exception($"In class: {nameof(Program)}, Method: {nameof(DivisionNumbers)}, Parameter: {nameof(n2)} is equals zero", de);
            }
            return result;
        }
        static void Main(string[] args)
        {
            WriteLine("Input two numbers: ");
            int number1, number2, result = 0;
            try
            {
                number1 = int.Parse(ReadLine());
                number2 = int.Parse(ReadLine());
                result = DivisionNumbers(number1, number2);
                WriteLine($"Result of divide by zero: {result}");
            }
            catch (Exception e)
            {
                //additional information
                Console.WriteLine(e.Message);
                //previous exception
                WriteLine(e.InnerException.Message);
            }
        }        
    }
}
