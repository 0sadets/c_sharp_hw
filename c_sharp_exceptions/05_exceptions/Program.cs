using System;

namespace _05_exceptions
{
    [Serializable]
    public class ConvertToIntegerException : ApplicationException
    {
        public DateTime Time { get; set; }
        public ConvertToIntegerException()
        {
            Time = DateTime.Now;
        }
        public ConvertToIntegerException(string message) : base(message)
        {
            Time = DateTime.Now;
        }
        public ConvertToIntegerException(string message, Exception inner) : base(message, inner)
        {
            Time = DateTime.Now;
        }
        protected ConvertToIntegerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    class ConsoleReader
    {
        public static int GetInt32FromConsole()
        {            
            try
            {
                return int.Parse(Console.ReadLine());                
            }
            catch (FormatException e)
            {
                throw new ConvertToIntegerException("Argument has incorrect format");
            }
            catch (Exception e)
            {
                throw e; // повторна генерація винятку
            }           
        }
    }

    class Program
    {
        static void Main()
        {            
            int number = 0;
            try
            {
                number = ConsoleReader.GetInt32FromConsole();

                Console.WriteLine(new string('*', number));                
            }
            catch (ConvertToIntegerException e)
            {
                Console.WriteLine("My Exception catch!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Time);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched!");
                Console.WriteLine(e.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
