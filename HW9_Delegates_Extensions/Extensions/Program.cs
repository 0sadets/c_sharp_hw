using System.Runtime.CompilerServices;

namespace Extensions
{
    public static class Extensions
    {

        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            str = str.ToLower().Replace(" ", "");
            for (int i = 0; i < str.Length / 2; ++i)
                if (str[i] != str[str.Length - 1 - i]) return false;
            return true;


        }
        public static string Shifr(this string s, int key)
        {
            char[] arr = s.ToCharArray();
            char[] shifrarray = new char[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    arr[i]++;
                }
            }

            return new string(arr);
        }
    }
    public static class ArrayExtensions
    {
        public static int IdenticSymbols(this int[] arr, int num)
        {
            int res = 0;
            foreach(int i in arr)
            {
                if (i == num) res++;
            }
            return res;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string example1 = "He lived as a devil eh";
            string example2 = "Hello World";

            bool isPalindrome1 = example1.IsPalindrome();
            bool isPalindrome2 = example2.IsPalindrome();

            Console.WriteLine($"{example1} is palindrome: {isPalindrome1}");
            Console.WriteLine($"{example2} is palindrome: {isPalindrome2}");

            //-------------------------------------------------------------------
            string word = "Life";
            Console.WriteLine($"{word} is {word.Shifr(3)}");
            //-------------------------------------------------------------------
            int[] arr = { 1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 2, 2, 2 };
            int num = 2;
            Console.WriteLine($"Array has {arr.IdenticSymbols(num)} symbols of number {num} ");
        }
    }

}