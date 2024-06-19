using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

namespace Delegates
{

    public delegate int FirstTaskDelegate(int[] arr);
    public delegate void SecondTaskDelegate(ref int[] arr);


    class Arrayy
    {
        public void Print(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.WriteLine(i + " ");
            }
            Console.WriteLine();
        }
        public int GetNumNegative(int[] arr)
        {
            int num = 0;
            foreach(int i in arr)
            {
                num += i < 0 ? 1 : 0;
            }
            return num;
        }
        public int GetSum(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }
        public void ChangeToZero(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
            }
        }
        public void SortArray(ref int[] array)
        {
            Array.Sort(array);
        }

    }
    internal class Program
    {
     
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 9, 3, 5, 6, 44, 22, 11, -7, -7, -5, -45, -6 };
            Arrayy array = new Arrayy();
            int key;
            do
            {
                Console.WriteLine("1 - calculation of the value");
                Console.WriteLine("2 - array change");
                Console.WriteLine("0 - quit");
                Console.Write("Enter: ");
                key = Convert.ToInt32(Console.ReadLine());
                if (key == 1)
                {
                    FirstTaskDelegate firstTaskDelegate = null;
                    Console.WriteLine("1 - Calculate the number of negative elements");
                    Console.WriteLine("2 - Determine the sum of all elements");
                    Console.WriteLine("0 - quit");
                    Console.Write("\nEnter Option: ");
                    int op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {
                        case 0:
                            break;
                        case 1:
                            firstTaskDelegate = new FirstTaskDelegate(array.GetNumNegative);
                            break;
                        case 2:
                            firstTaskDelegate = new FirstTaskDelegate(array.GetSum);
                            break;
                        default:
                            Console.WriteLine("Error choice......");
                            break;


                    }
                    Console.WriteLine("Res: " + firstTaskDelegate?.Invoke(arr));
                }
                else if (key == 2)
                {
                    SecondTaskDelegate secondTaskDelegate = null;
                    Console.WriteLine("1 - Change all negative elements to 0");
                    Console.WriteLine("2 - Sort the array ");
                    Console.Write("\nEnter Option: ");
                    int op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {
                        case 0: break;
                        case 1:
                            secondTaskDelegate = new SecondTaskDelegate(array.ChangeToZero); break;
                        case 2:
                            secondTaskDelegate = new SecondTaskDelegate(array.SortArray); break;
                        default:
                            Console.WriteLine("Error choice......");
                            break;
                    }

                    secondTaskDelegate?.Invoke( ref arr);
                    array.Print(arr);

                }
            }while(key!=0);
            
            

        }
    }
}