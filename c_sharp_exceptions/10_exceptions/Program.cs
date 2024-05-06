using System;
using static System.Console;

namespace _10_exception
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    byte b = 100;
        //    b = (byte)(b + 200);
        //    //discharges that do not fall into the Byte range discarded
        //    WriteLine($"(byte)300 = {b}"); // 44
        //    int n = 65537;
        //    short s = (short)n;
        //    //discharges that do not fall into the Short range discarded
        //    WriteLine($"(short)65536 = {s}"); // 0
        //}
        //static void Main(string[] args)
        //{
        //    // byte  : 0...255
        //    // sbyte : -128...127
        //    byte b = 255;
        //    try
        //    {
        //        checked
        //        {
        //            b++; // generate OverflowException
        //        }
        //        WriteLine(b);
        //    }
        //    catch (OverflowException e)
        //    {
        //        WriteLine(e.Message);
        //    }
        //    try
        //    {
        //        unchecked
        //        {
        //            b++; // ignore overflow
        //        }
        //        WriteLine(b); //0
        //    }
        //    catch (OverflowException e)
        //    {
        //        WriteLine(e.Message);
        //    }
        //}
        static void Main()
        {
            byte b = 100;
            WriteLine(unchecked((byte)(b + 200))); // b = 44
            try
            {
                //generate exception
                WriteLine(checked((byte)(b + 200)));
            }
            catch (OverflowException oe)
            {
                WriteLine(oe.Message);
            }
        }
    }
}