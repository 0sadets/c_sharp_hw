using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2_Array_String
{
   // Завдання 1
   //Створіть додаток, який відображає кількість парних,
   //непарних, унікальних елементів масиву.

//   Завдання 2
//  Створіть додаток, який відображає кількість значень у
//  масиві менше заданого параметра користувачем.Наприклад,
//  кількість значень менших, ніж 7 (7 введено користувачем
//  з клавіатури).

//Завдання 3
//Оголосити одновимірний(5 елементів) масив з назвою
//A i двовимірний масив(3 рядки, 4 стовпці) дробових чисел
//з назвою B.Заповнити одновимірний масив А числами,
//введеними з клавіатури користувачем, а двовимірний
//масив В — випадковими числами за допомогою циклів.
//Вивести на екран значення масивів: масиву А — в один
//рядок, масиву В — у вигляді матриці.
//Знайти у даних масивах загальний максимальний елемент, мінімальний
//елемент, загальну суму усіх елементів, загальний добуток
//усіх елементів, суму парних елементів масиву А, суму
//непарних стовпців масиву В.

//Завдання 4
//Дано двовимірний масив розміром 5×5, заповне-
//ний випадковими числами з діапазону від –100 до 100.
//Визначити суму елементів масиву, розташованих між
//мінімальним і максимальним елементами.
    internal class Program
    {
        static void Task1(int[] arr)
        {
            int even=0, odd = 0, unic=0;
            bool isUnic = true;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]%2==0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
                for(int j = 0; j<arr.Length;j++)
                {
                    if (arr[i] == arr[j])
                    {
                        isUnic = false;
                    }

                }
                if (isUnic) unic++;
            }
            Console.WriteLine($"Num of Even nums: {even}");
            Console.WriteLine($"Num of Odd nums: {odd}");
            Console.WriteLine($"Num of Unic nums: {unic}");

        }
        static void Task2(int[] arr)
        {
            Console.Write("Enter num: ");
            int user_num = Convert.ToInt32(Console.ReadLine());
            int a = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i]<user_num)
                {
                    a++;
                }
            }
            Console.WriteLine($"Array has {a} nums less than {user_num}");

        }
        static void Task3()
        {
            int[] A = new int[5];
            double[,] B = new double[3, 4];

            for(int i = 0; i< A.Length; i++)
            {
                Console.Write($"Enter {i+1} element: ");
                A[i] = Convert.ToInt16(Console.ReadLine());
            }
            Console.WriteLine("A array: ");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine("\n\nB matrix: ");
            Random rnd = new Random();
            for (int i=0; i< B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = Math.Round((rnd.Next(100) + rnd.NextDouble()), 2);
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write($"{B[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            double min, max, sum = 0, dob = 1, even_sum_A = 0, odd_sum_B=0;

            double B_max = 0.0, B_min = B[0,0], A_max = 0.0, A_min =A[0];
            for(int i = 0; i<A.Length; i++)
            {
                if (A[i] > A_max)
                {
                    A_max = A[i];
                }
                if (A[i] < A_min)
                {
                    A_min = A[i];
                }
                sum += A[i];
                dob *= A[i];
                if (A[i]%2 ==0)
                {
                    even_sum_A += A[i];
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i,j] > B_max)
                    {
                        B_max = B[i,j];
                    }
                    if (B[i,j] < B_min)
                    {
                        B_min = B[i,j];
                    }
                    sum += B[i, j];
                    dob *= B[i,j];
                    if( j+1 % 2 != 0)
                    {
                        odd_sum_B += B[i, j];
                    }
                }
            }
            if (A_max > B_max) max = A_max;
            else max = B_max;
            if (A_min < B_min) min = A_min;
            else min = B_min;

            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Dob: {dob}");
            Console.WriteLine($"The sum of even elements of array A: {even_sum_A}");
            Console.WriteLine($"The sum of odd columns of array B: {odd_sum_B}");




        }
        static void Task4()
        {
            Random random = new Random();
            int[,] arr = new int[5, 5];
            for (int i = 0; i<arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i,j] = random.Next(-100, 100) + 1;
                }
            }
            Console.WriteLine("Array:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.WriteLine();
            }
            int[] new_arr = new int[25];
            int a = 0; 
            int min =0, max =0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    new_arr[a++] = arr[i,j];
                }
            }
            for(int i = 0; i<new_arr.Length; i++)
            {
                if (new_arr[i] >new_arr[max])
                {
                    max = i;
                }
                if (new_arr[i]< new_arr[min])
                {
                    min = i;
                }
            }
            Console.WriteLine($"Min number: arr[{min}] = {new_arr[min]};");
            Console.WriteLine($"Max number: arr[{max}] = {new_arr[max]};");
            if (min > max)
            {
                int tmp;
                tmp = max;
                max = min;
                min = tmp;
            }
            Console.WriteLine("\nTask4: ");
            for (int i = min; i <= max; i++)
            {
                Console.Write($"{new_arr[i]} ");
            }
           
        }
        static void Task5(int []arr)
        {
            int min = arr[0];
            for(int i = 0;i< arr.Length;i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            int num = min + 5;
            int count=0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        static void Main(string[] args)
        {
            int[] arr = new int[15];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = i + 1;
            //}
            arr[0] = 5;
            arr[1] = 5;
            arr[2] = -1;
            arr[3] = 0;
            arr[4] = 45;
            arr[5] = 1;
            arr[6] = 9;
            arr[7] = 8;
            arr[8] = 6;
            arr[9] = -8;
            arr[10] = 7;
            arr[11] = 4;
            arr[12] = -3;
            arr[13] = -3;
            arr[14] = 0;

            //Task1(arr);
            //Task2(arr);
            //Task3();
            //Task4();
            Task5(arr);
        }
    }
}
