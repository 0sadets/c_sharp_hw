using System;
using System.Collections;

namespace _04_exceptions
{
    class MyClass
    {
        public void BadMethod()
        {
            Exception exception = new Exception("MyException message");

            exception.HelpLink = "https://google.com";
            exception.Data.Add("Exception  reason: ", "Test exception");
            exception.Data.Add("Time invokation: ", DateTime.Now);
            exception.Data.Add("User Name: ", "Vlad");

            throw exception;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                MyClass instance = new MyClass();
                instance.BadMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine("Member name:             {0}", e.TargetSite);
                Console.WriteLine("Member class:            {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("Member type:             {0}", e.TargetSite.MemberType);
                Console.WriteLine("Method name:             {0}", e.TargetSite.Name);
                Console.WriteLine("Message:                 {0}", e.Message);
                Console.WriteLine("Source:                  {0}", e.Source);
                Console.WriteLine("Help Link:               {0}", e.HelpLink);
                Console.WriteLine("Stack:                   {0}", e.StackTrace);

                foreach (DictionaryEntry de in e.Data)
                    Console.WriteLine("{0} : {1}", de.Key, de.Value);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
