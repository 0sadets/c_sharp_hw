using Microsoft.VisualBasic.FileIO;
using System.Net.NetworkInformation;
using System.Text;

namespace hw1_intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // task1:
            void Task1()
            {
                Console.WriteLine("It's easy to win forgiveness for being wrong;\nbeing right is what gets you into real trouble.\nBjarne Stroustrup");
            }
            
            // task2:
            void Task2()
            {
                Console.WriteLine("Enter nums:");
                int[] nums = new int[5];

                int sum = 0, dob = 1;
                for (int i = 0; i < 5; i++)
                {
                    nums[i] = Convert.ToInt32(Console.ReadLine());
                    sum += nums[i];
                    dob *= nums[i];
                }
                int max = nums[0];
                int min = nums[0];
                for (int i = 0; i < 5; i++)
                {
                    if (max < nums[i])
                    {
                        max = nums[i];
                    }
                    if (min > nums[i])
                    {
                        min = nums[i];
                    }
                }
                Console.WriteLine($"Sum: {sum}");
                Console.WriteLine($"Dob: {dob} ");
                Console.WriteLine($"Min: {min} ");
                Console.WriteLine($"Max: {max} ");
                nums = null;
            }
            
            // task3:
            void Task3()
            {
                // 1 variant
                //Console.WriteLine("Enter nums: ");
                //int num = Convert.ToInt32(Console.ReadLine());
                //int a, b, c, d, e, f;
                //a = num / 100000 % 10;
                //b = num / 10000 % 10;
                //c = num / 1000 % 10;
                //d = num / 100 % 10;
                //e = num / 10 % 10;
                //f = num  % 10;
                //Console.WriteLine($"Reversed num: {f}{e}{d}{c}{b}{a}");

                // 2 variant
                Console.WriteLine("Enter nums: ");
                string Snums = Convert.ToString(Console.ReadLine());
                for (int i = 5; i >= 0; i--)
                {
                    Console.Write(Snums[i]);
                }




            }
            
            // task4:
            void Task4()
            {
                Console.WriteLine("Enter diapazone: ");
                int start, end;
                start = Convert.ToInt32(Console.ReadLine());
                end = Convert.ToInt32(Console.ReadLine());
                int a = 0, b = 1;
                int tmp = a + b;
                Console.Write($"Fibonacci: {a}, {b}, ");
                while (tmp < end)
                {
                    if (tmp >= start)
                    {
                        Console.Write(tmp + ", ");
                    }
                    a = b;
                    b = tmp;
                    tmp = a + b;
                    
                }
            }
           
            // task5:
            void PrintNums(int num)
            {
                for (int i = 0; i < num; i++)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
            void Task5()
            {
                int a, b;
                Console.Write("Enter A: ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnter B: ");
                b = Convert.ToInt32(Console.ReadLine());
                if(a>b)
                {
                    int tmp = a;
                    a = b; b = tmp;
                }
                for (int i = a; i <= b; i++)
                {
                    PrintNums(i);
                }
            }
            
            // task6:
            void Task6()
            {
                int lenght, direction; char symb;  
                Console.Write("Enter lenght: ");
                lenght = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter symbol: ");
                symb = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter direction(0 - horizontal, 1 - vertical): ");
                direction = Convert.ToInt32(Console.ReadLine());
                for(int i = 0; i < lenght; i++)
                {
                    if(direction == 0)
                    {
                        Console.Write(symb);
                    }
                    else if (direction == 1)
                    {
                        Console.WriteLine(symb);
                    }
                }
            }


            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            Task6();
        }
    }
}


//Завдання 1
//Виведіть на екран цитату Б'ярна Страуструпа: It's easy
//to win forgiveness for being wrong; being right is what gets you
//into real trouble.
//Приклад виводу:
//It's easy to win forgiveness for being wrong;
//being right is what gets you into real trouble.
//Bjarne Stroustrup

//Завдання 2
//Користувач вводить з клавіатури п'ять чисел. Необхідно знайти суму чисел, максимум і мінімум з п'яти чисел,
//добуток чисел. Результат обчислень вивести на екран.

//Завдання 3
//Користувач з клавіатури вводить шестизначне число.
//Необхідно перевернути число і відобразити результат.
//Наприклад, якщо введено 341256, результат 652143.

//Завдання 4
//Користувач вводить з клавіатури межі числового діапазону. Потрібно показати усі числа Фібоначчі з цього
//діапазону. Числа Фібоначчі — елементи числової послідовності, у якій перші два числа дорівнюють 0 і 1, а кожне
//наступне число дорівнює сумі двох попередніх чисел.
//Наприклад, якщо вказано діапазон 0–20, результат буде:
//0, 1, 1, 2, 3, 5, 8, 13.

//Завдання 5
//Дано цілі додатні числа A і B (A < B). Вивести усі цілі
//числа від A до B включно; кожне число має виводитися у
//новому рядку; при цьому кожне число має виводитися у
//кількість разів, рівну його значенню. Наприклад: якщо А
//= 3, а В = 7, то програма має сформувати в консолі такий
//висновок:
//3 3 3
//4 4 4 4
//5 5 5 5 5
//6 6 6 6 6 6
//7 7 7 7 7 7 7

//Завдання 6
//Користувач з клавіатури вводить довжину лінії, символ
//заповнювач, напрямок лінії (горизонтальна, вертикальна).
//Програма відображає лінію по заданих параметрах.
//Наприклад: +++++.
//Параметри лінії: горизонтальна лінія, довжина дорівнює п'яти, символ заповнювач +.